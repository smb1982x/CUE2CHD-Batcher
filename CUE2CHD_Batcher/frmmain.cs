using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CUE2CHD_Batcher
{
    public partial class frmMain : Form
    {
        Boolean bKill;
        int intCurrentProcess;
        ArrayList alCUENames;

        public frmMain()
        {
            InitializeComponent();
            bKill = false;            
            alCUENames = new ArrayList();
        }

        public Process process_CUE_to_CHD(string strCUE, string strOutDirectory)
        {
            Process pOut = new Process();

            pOut.StartInfo.FileName = Application.StartupPath + "\\chdman.exe";
            pOut.StartInfo.WorkingDirectory = Path.GetDirectoryName(strCUE);
            string strArgs = "createcd -c4 -i \"" + strCUE + "\" -o \"" + strOutDirectory + "\\" + Path.GetFileNameWithoutExtension(strCUE) + ".chd\"";
            pOut.StartInfo.Arguments = strArgs;

            return pOut;
        }

        private void createCHDMAN()
        {
            string path = Path.Combine(Application.StartupPath, "chdman.exe");

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }
            }
            catch { }

            File.WriteAllBytes(path, CUE2CHD_Batcher.Properties.Resources.chdman);

        }

        public void process_CHD_to_CUE(string strCHD, string strOutDirectory)
        {
            string path = Path.Combine(Path.GetTempPath(), "chdman.exe");
            File.WriteAllBytes(path, CUE2CHD_Batcher.Properties.Resources.chdman);

            string strOutPath = strOutDirectory + "\\" + Path.GetFileNameWithoutExtension(strCHD) + "\\" + Path.GetFileNameWithoutExtension(strCHD) + ".cue";

            try
            {
                Directory.CreateDirectory(Path.GetDirectoryName(strOutPath));
            }
            catch { }

            Process pCHDMAN = new Process();
            pCHDMAN.StartInfo.FileName = path;
            pCHDMAN.StartInfo.WorkingDirectory = Path.GetDirectoryName(strCHD);
            string strArgs = "extractcd -i \"" + strCHD + "\" -o \"" + strOutPath + "\"";
            pCHDMAN.StartInfo.Arguments = strArgs;
            pCHDMAN.Start();
            pCHDMAN.WaitForExit();
        }

        private void btnCUE_Click(object sender, EventArgs e)
        {
            fbdCUE.ShowDialog();
            if (Directory.Exists(fbdCUE.SelectedPath))
            {
                txtCUE.Text = fbdCUE.SelectedPath;
            }
        }

        private void btnCHD_Click(object sender, EventArgs e)
        {
            fbdCHD.ShowDialog();
            if (Directory.Exists(fbdCHD.SelectedPath))
            {
                txtCHD.Text = fbdCHD.SelectedPath;
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (chkReverse.CheckState == CheckState.Checked)
            {
                CHD_TO_CUE();
            }
            else
            {
                CUE_TO_CHD();
            }
        }

        private void CUE_TO_CHD()
        {
            Dictionary<string, Process> dictOut;
            alCUENames.Clear();

            if ((Directory.Exists(txtCUE.Text)) && (Directory.Exists(txtCHD.Text)))
            {
                txtOut.Clear();
                string[] files = Directory.GetFiles(txtCUE.Text, "*.cue", SearchOption.AllDirectories);

                if (files.Length > 0)
                {
                    dictOut = new Dictionary<string, Process>();

                    for (int i = 0; i < files.Length; i++)
                    {
                        btnStart.Enabled = false;                        
                        chkReverse.Enabled = false;
                        btnCHD.Enabled = false;
                        btnCUE.Enabled = false;


                        if (!File.Exists(txtCHD.Text + "\\" + Path.GetFileNameWithoutExtension(files[i]) + ".chd"))
                        {
                            // CreateCHD

                            string strOut = "[ " + (i + 1).ToString().PadLeft(files.Length.ToString().Length, '0') + " / " + files.Length.ToString().PadLeft(files.Length.ToString().Length, '0') + " ] :: Processing: " + Path.GetFileNameWithoutExtension(files[i]) + Environment.NewLine;
                            Process pOut = process_CUE_to_CHD(files[i], txtCHD.Text);
                            alCUENames.Add(files[i]);
                            dictOut.Add(strOut, pOut);                                                    
                        }
                        else
                        {
                            // CHD Already Exists!!

                            string strOut = "[ " + (i + 1).ToString().PadLeft(files.Length.ToString().Length, '0') + " / " + files.Length.ToString().PadLeft(files.Length.ToString().Length, '0') + " ] :: Error: " + Path.GetFileNameWithoutExtension(files[i]) + ".chd  Already Exists!" + Environment.NewLine;
                            Process pOut = null;
                            alCUENames.Add(files[i]);
                            dictOut.Add(strOut, pOut);
                        }
                    }

                    // PROCESS ALL JOBS
                    doProcesses(dictOut);
                }
                else
                {
                    txtOut.AppendText(Environment.NewLine + "No CUE Files found!");
                }
            } 
        }

        private void doProcesses(Dictionary<string,Process> dictProcesses)
        {
            ArrayList alProcessDesc = new ArrayList();
            List<Process> ProcessList = new List<Process>();  

            foreach (KeyValuePair<string, Process> kvpDict in dictProcesses)
            {
                alProcessDesc.Add(kvpDict.Key.ToString());
                ProcessList.Add(kvpDict.Value);
            }

            createCHDMAN();

            Thread th = new Thread(() =>
            {
                for (int i = 0; i < ProcessList.Count; i++)
                {
                    try
                    {
                        if (!ProcessList[i].Equals(null))
                        {                           

                            if (bKill == true)
                            {
                                break;
                            }
                            AppendTextBox(alProcessDesc[i].ToString());
                            
                            ProcessList[i].StartInfo.RedirectStandardOutput = true;
                            ProcessList[i].StartInfo.RedirectStandardError = true;                            
                            ProcessList[i].EnableRaisingEvents = true;
                            ProcessList[i].StartInfo.CreateNoWindow = true;
                            ProcessList[i].StartInfo.UseShellExecute = false;
                            ProcessList[i].ErrorDataReceived += proc_DataReceived;
                            ProcessList[i].OutputDataReceived += proc_DataReceived;

                            setCurrentCUE(alCUENames[i].ToString(),false);

                            ProcessList[i].Start();
                            intCurrentProcess = ProcessList[i].Id;

                            ProcessList[i].BeginErrorReadLine();
                            ProcessList[i].BeginOutputReadLine();

                            ProcessList[i].WaitForExit();

                            ConversionStats(alProcessDesc[i].ToString().Split(':')[0].Trim(), alCUENames[i].ToString().Trim());



                        }
                    }catch//(Exception Ex)
                    {
                        AppendTextBox(alProcessDesc[i].ToString());
                    }
                }

                setCurrentCUE("", true);
                AppendTextBox(Environment.NewLine + "Job done!");
                finished();
            });
            th.Start(); 

        }

        private void ConversionStats(string strFirstPart, string strCUEName)
        {
            string strCUE = strCUEName;
            string strCHD = txtCHD.Text + "\\" + Path.GetFileNameWithoutExtension(strCUEName) + ".chd";
            string strBIN = Path.GetDirectoryName(strCUE) + "\\" + Path.GetFileNameWithoutExtension(strCUE) + ".bin";

            double cueMB = Math.Round(ConvertBytesToMegabytes(new FileInfo(strBIN).Length));
            double chdMB = Math.Round(ConvertBytesToMegabytes(new FileInfo(strCHD).Length));

            AppendTextBox("".PadRight(strFirstPart.Length, ' ') + " -> Complete." + Environment.NewLine);

        }

        static long GetDirectorySize(string p)
        {
            // 1.
            // Get array of all file names.
            string[] a = Directory.GetFiles(p, "*.*");

            // 2.
            // Calculate total bytes of all files in a loop.
            long b = 0;
            foreach (string name in a)
            {
                // 3.
                // Use FileInfo to get length of each file.
                FileInfo info = new FileInfo(name);
                b += info.Length;
            }
            // 4.
            // Return total size
            return b;
        }

        static double ConvertBytesToMegabytes(long bytes)
        {
            return (bytes / 1024f) / 1024f;
        }

        void proc_DataReceived(object sender, DataReceivedEventArgs e)
        {
            try
            {

                string strLine = e.Data.ToString();
                
                if (strLine.StartsWith("Compressing"))
                {
                    
                    string strCurrentPercentage = strLine.Split(' ')[1].Replace("%", string.Empty);
                    string strRatio = strLine.Split(' ')[3].Split('=')[1].Replace("%)", string.Empty).Trim();

                    double dCurrentPercentage = Convert.ToDouble(strCurrentPercentage);
                    double dRatio = Convert.ToDouble(strRatio);

                    strCurrentPercentage = Math.Round(dCurrentPercentage).ToString();
                    strRatio = Math.Round(dRatio).ToString();
                    
                    setProgressBar(strCurrentPercentage, "100");
                    setCurrentRatio(strRatio);
                }
            }
            catch { }
        }


        public void setProgressBar(string strCurrent, string strTotal)
        {
            if (pbCurrent.InvokeRequired)
            {
                pbCurrent.Invoke(new MethodInvoker(
                delegate ()
                {
                    pbCurrent.Maximum = Convert.ToInt32(strTotal);
                    pbCurrent.Value = Convert.ToInt32(strCurrent);
                }));
            }
            else
            {
                pbCurrent.Maximum = Convert.ToInt32(strTotal);
                pbCurrent.Value = Convert.ToInt32(strCurrent);
            }
        }

        public void setCurrentRatio(string strRatio)
        {
            if (lblCurrentCompression.InvokeRequired)
            {
                lblCurrentCompression.Invoke(new MethodInvoker(
                delegate ()
                {
                    lblCurrentCompression.Text = strRatio + "%";
                }));
            }
            else
            {
                lblCurrentCompression.Text = strRatio + "%";
            }
        }

        public void setCurrentCUE(string strCUE, bool bFinished)
        {
            try
            {
                if (bFinished == false)
                {
                    if (gbCurrent.InvokeRequired)
                    {
                        gbCurrent.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            gbCurrent.Text = "Progress:" + Path.GetFileNameWithoutExtension(strCUE);
                        }));
                    }
                    else
                    {
                        gbCurrent.Text = "Progress:" + Path.GetFileNameWithoutExtension(strCUE);
                    }
                }
                else
                {
                    if (gbCurrent.InvokeRequired)
                    {
                        gbCurrent.Invoke(new MethodInvoker(
                        delegate ()
                        {
                            gbCurrent.Text = "Progress";
                        }));
                    }
                    else
                    {
                        gbCurrent.Text = "Progress";
                    }
                }
            }
            catch { }
            
        }

        public void AppendTextBox(string value)
        {
            if (txtOut.InvokeRequired)
            {
                txtOut.Invoke(new MethodInvoker(
                delegate ()
                {
                    txtOut.Text += value;
                    txtOut.SelectionStart = txtOut.Text.Length;
                    txtOut.ScrollToCaret();
                }));
            }
            else
            {
                txtOut.Text += value;
                txtOut.SelectionStart = txtOut.Text.Length;
                txtOut.ScrollToCaret();
            }
        }

        public void finished()
        {
            if (lblCurrentCompression.InvokeRequired)
            {
                lblCurrentCompression.Invoke(new MethodInvoker(
                delegate ()
                {
                    lblCurrentCompression.Text = string.Empty;
                }));
            }
            else
            {
                lblCurrentCompression.Text = string.Empty;
            }

            if (btnCHD.InvokeRequired)
            {
                btnCHD.Invoke(new MethodInvoker(
                delegate ()
                {
                    btnCHD.Enabled = true;
                }));
            }
            else
            {
                btnCHD.Enabled = true;
            }

            if (btnCUE.InvokeRequired)
            {
                btnCUE.Invoke(new MethodInvoker(
                delegate ()
                {
                    btnCUE.Enabled = true;
                }));
            }
            else
            {
                btnCUE.Enabled = true;
            }

            if (btnStart.InvokeRequired)
            {
                btnStart.Invoke(new MethodInvoker(
                delegate ()
                {
                    btnStart.Enabled = true;
                }));
            }
            else
            {
                btnStart.Enabled = true;
            }
            
            if (chkReverse.InvokeRequired)
            {
                chkReverse.Invoke(new MethodInvoker(
                delegate ()
                {
                    chkReverse.Enabled = true;
                }));
            }
            else
            {
                chkReverse.Enabled = true;
            }

            if (pbCurrent.InvokeRequired)
            {
                pbCurrent.Invoke(new MethodInvoker(
                delegate ()
                {
                    pbCurrent.Maximum = 100;
                    pbCurrent.Value = 0;
                }));
            }
            else
            {
                pbCurrent.Maximum = 100;
                pbCurrent.Value = 0;
            }
        }
        
        private void CHD_TO_CUE()
        {
            if ((Directory.Exists(txtCUE.Text)) && (Directory.Exists(txtCHD.Text)))
            {
                txtOut.Clear();
                string[] files = Directory.GetFiles(txtCHD.Text, "*.chd", SearchOption.AllDirectories);

                if (files.Length > 0)
                {
                    for (int i = 0; i < files.Length; i++)
                    {
                        btnStart.Enabled = false;                        
                        chkReverse.Enabled = false; btnStart.Enabled = false;
                        if (!File.Exists(txtCUE.Text + "\\" + Path.GetFileNameWithoutExtension(files[i]) + "\\" + Path.GetFileNameWithoutExtension(files[i]) + ".cue"))
                        {
                            txtOut.AppendText("[ " + (i + 1).ToString().PadLeft(2, '0') + " / " + files.Length.ToString().PadLeft(2, '0') + " ] :: Processing: " + files[i] + Environment.NewLine);
                            process_CHD_to_CUE(files[i], txtCUE.Text);
                        }
                        else
                        {
                            txtOut.AppendText("[ " + (i + 1).ToString().PadLeft(2, '0') + " / " + files.Length.ToString().PadLeft(2, '0') + " ] :: Error: " + Path.GetFileNameWithoutExtension(files[i]) + ".cue  Already Exists!" + Environment.NewLine);
                        }


                    }

                    txtOut.AppendText(Environment.NewLine + "Job done!");
                    btnStart.Enabled = true;
                    chkReverse.Enabled = true;
                }
                else
                {
                    txtOut.AppendText(Environment.NewLine + "No CHD Files found!");
                }
            }
        }
        
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            KILL();
        }        

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            KILL();
        }

        private void KILL()
        {
            bKill = true;
            try
            {
                //

                Process p = Process.GetProcessById(intCurrentProcess);
                p.Kill();
            }
            catch { }

            try
            {
                foreach (var process in Process.GetProcessesByName("chdman"))
                {
                    process.Kill();
                }
            }
            catch { }

            while(File.Exists(Application.StartupPath + "\\chdman.exe"))
            {
                try
                {
                    File.Delete(Application.StartupPath + "\\chdman.exe");
                }
                catch { }
                Thread.Sleep(100);
            }

            Application.Exit();
        }
    }
}