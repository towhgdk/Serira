using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using System.Diagnostics;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

using WinColor = System.Drawing.Color;
using ScottColor = ScottPlot.Color;
using WinFont = System.Drawing.Font;
using WinFontStyle = System.Drawing.FontStyle;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private ScottPlot.Plottables.Scatter scatter;
        private List<double> xData = new List<double>();
        private List<double> yData = new List<double>();
        private bool isStopping = false;
        private bool isRunning = false;
        private Timer ledTimer = new Timer();
        private int colorPhase = 0;

        [DllImport("Kernel32.dll", SetLastError = true, CharSet = CharSet.Auto)]
        static extern bool DeviceIoControl(SafeFileHandle hDevice, uint dwIoControlCode, IntPtr lpInBuffer, uint nInBufferSize, IntPtr lpOutBuffer, uint nOutBufferSize, out uint lpBytesReturned, IntPtr lpOverlapped);
        const uint FSCTL_SET_SPARSE = 0x000900C4;

        public Form1()
        {
            InitializeComponent();
            formsPlot1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            ConnectStopButton();
            SetupLEDLabel();
        }

        private void ConnectStopButton()
        {
            Control[] stopButtons = this.Controls.Find("buttonStop", true);
            if (stopButtons.Length > 0) ((Button)stopButtons[0]).Click += ButtonStop_Click;
            Control[] btn2 = this.Controls.Find("button2", true);
            if (btn2.Length > 0) ((Button)btn2[0]).Click += ButtonStop_Click;
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            if (isRunning) { isStopping = true; if (label1 != null) label1.Text = "⛔ 중지 중..."; }
        }

        private void SetupLEDLabel()
        {
            if (label4 != null) { label4.Text = "제작 : DC 저장장치 갤러리\r\n무기를ㅡ접자 / Gemini"; label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter; label4.Font = new WinFont("맑은 고딕", 9, WinFontStyle.Bold); }
            ledTimer.Interval = 100; ledTimer.Tick += (s, e) => {
                if (label4 == null) return;
                colorPhase = (colorPhase + 1) % 4;
                label4.ForeColor = (colorPhase == 0) ? WinColor.DeepSkyBlue : (colorPhase == 2) ? WinColor.Blue : WinColor.DodgerBlue;
            };
            ledTimer.Start();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            foreach (DriveInfo drive in DriveInfo.GetDrives()) { if (drive.IsReady) comboBox1.Items.Add($"{drive.VolumeLabel} ({drive.Name})"); }
            if (comboBoxUnit.Items.Count == 0) { comboBoxUnit.Items.Add("GB"); comboBoxUnit.Items.Add("MB"); }
            comboBoxUnit.SelectedIndex = 0;
            radioall_CheckedChanged(null, null);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isRunning) return;
            if (comboBox1.SelectedItem == null) { MessageBox.Show("드라이브를 선택해주세요!"); return; }

            bool isReadMode = (radioButtonRead != null && radioButtonRead.Checked);
            bool isRandomMode = checkBoxRandom != null && checkBoxRandom.Checked;
            bool isAllMode = (radioall != null && radioall.Checked);

            isRunning = true; isStopping = false;
            button1.Enabled = false; groupBox1.Enabled = false; groupBox2.Enabled = false;

            xData.Clear(); yData.Clear(); formsPlot1.Plot.Clear();

            string selectedDrive = comboBox1.SelectedItem.ToString();
            string driveLetter = selectedDrive.Substring(selectedDrive.LastIndexOf('(') + 1, 1);
            long totalBytes = 0;
            try
            {
                DriveInfo dInfo = new DriveInfo($@"{driveLetter}:\");
                totalBytes = isAllMode ? (isReadMode ? dInfo.TotalSize : dInfo.AvailableFreeSpace - (300 * 1024 * 1024)) : (long)numericUpDown1.Value * (comboBoxUnit.Text == "GB" ? 1024L * 1024 * 1024 : 1024L * 1024);
            }
            catch { isRunning = false; return; }

            int totalMB = (int)(totalBytes / 1024 / 1024);
            string path = isReadMode ? $@"\\.\{driveLetter}:" : Path.Combine($@"{driveLetter}:\", "DensityTest.bin");
            int bufferSize = (totalMB <= 32768) ? 4 * 1024 * 1024 : 32 * 1024 * 1024;
            byte[] buffer = new byte[bufferSize];
            Stopwatch sw = new Stopwatch(); Random rnd = new Random();

            // 1. 색상 변수 선언 (에러 해결 핵심)
            byte r = (byte)rnd.Next(60, 190);
            byte g = (byte)rnd.Next(60, 190);
            byte b = (byte)rnd.Next(60, 190);

            // 2. 타이틀 및 축 레이블 복구
            string modeStr = isReadMode ? "Raw Read" : "Write";
            string typeStr = isRandomMode ? "Random" : "Sequential";
            formsPlot1.Plot.Title($"{typeStr} {modeStr} (Block: {bufferSize / 1024 / 1024}MB)");
            formsPlot1.Plot.XLabel("Capacity (MB)");
            formsPlot1.Plot.YLabel("Speed (MB/s)");

            scatter = formsPlot1.Plot.Add.Scatter(xData, yData);

            // 3. 점과 선 색상 일치화 (투명도 조절로 안개 효과 극대화)
            scatter.MarkerColor = new ScottColor(r, g, b, 180);
            scatter.LineColor = new ScottColor(r, g, b, 40); // 선은 연하게
            scatter.MarkerSize = 5;
            scatter.LineWidth = 1;

            try
            {
                FileStream fs = isReadMode ? new FileStream(path, FileMode.Open, FileAccess.Read, FileShare.ReadWrite, bufferSize, FileOptions.WriteThrough)
                                           : new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, bufferSize, FileOptions.WriteThrough);
                if (!isReadMode && isRandomMode)
                {
                    uint outB; DeviceIoControl(fs.SafeFileHandle, FSCTL_SET_SPARSE, IntPtr.Zero, 0, IntPtr.Zero, 0, out outB, IntPtr.Zero);
                    fs.SetLength(totalBytes); rnd.NextBytes(buffer);
                }
                else if (!isReadMode) Array.Clear(buffer, 0, buffer.Length);

                using (fs)
                {
                    int loops = (int)(totalBytes / bufferSize);
                    for (int i = 0; i < loops; i++)
                    {
                        if (isStopping) break;

                        // (중략: 랜덤 모드 Seek 및 실제 Read/Write 로직)
                        if (isRandomMode) fs.Seek((long)(rnd.NextDouble() * (totalBytes / bufferSize)) * bufferSize, SeekOrigin.Begin);

                        sw.Restart();
                        if (isReadMode) fs.Read(buffer, 0, buffer.Length); else fs.Write(buffer, 0, buffer.Length);
                        sw.Stop();

                        double mb = (i + 1) * (bufferSize / 1024.0 / 1024.0);
                        double spd = (bufferSize / 1024.0 / 1024.0) / sw.Elapsed.TotalSeconds;

                        xData.Add(mb);
                        yData.Add(spd);

                        label1.Text = $"진행: {mb:F0}/{totalMB} MB | {spd:F0} MB/s";

                        // --- 바로 이 지점에 삽입하세요! ---
                        // 4MB 단위(4194304)일 때는 25번마다, 32MB 단위일 때는 10번마다 갱신
                        int refreshRate = (bufferSize == 4 * 1024 * 1024) ? 25 : 10;

                        if (i % refreshRate == 0 || i == loops - 1)
                        {
                            formsPlot1.Plot.Axes.AutoScale();
                            formsPlot1.Plot.Axes.SetLimits(bottom: 0);
                            formsPlot1.Refresh();
                        }
                        // --------------------------------

                        Application.DoEvents();
                    }
                }
                if (!isReadMode && File.Exists(path)) File.Delete(path);
                MessageBox.Show(isStopping ? "중지됨" : "완료!");
            }
            catch (Exception ex) { MessageBox.Show("에러: " + ex.Message); }
            finally
            {
                isRunning = false; button1.Enabled = true; groupBox1.Enabled = true; groupBox2.Enabled = true;
                radioall_CheckedChanged(null, null); label1.Text = "대기 중...";
            }
        }

        private void radioall_CheckedChanged(object sender, EventArgs e)
        {
            bool isAll = radioall != null && radioall.Checked;
            if (numericUpDown1 != null) numericUpDown1.Enabled = !isAll;
            if (comboBoxUnit != null) comboBoxUnit.Enabled = !isAll;
        }

        private void buttonSaveGraph_Click(object sender, EventArgs e)
        {
            SaveFileDialog s = new SaveFileDialog { Filter = "PNG|*.png", FileName = $"Result_{DateTime.Now:HHmmss}.png" };
            if (s.ShowDialog() == DialogResult.OK) { formsPlot1.Plot.SavePng(s.FileName, 1920, 1080); MessageBox.Show("고화질로 저장 완료!"); }
        }

        private void radioButtonRead_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxRandom != null) checkBoxRandom.Text = radioButtonRead.Checked ? "랜덤 읽기 (영향 없음)" : "랜덤 쓰기";
        }

        // 껍데기 함수들
        private void button2_Click(object sender, EventArgs e) => ButtonStop_Click(sender, e);
        private void formsPlot1_Load(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void numericUpDown1_ValueChanged(object sender, EventArgs e) { }
        private void radioButtonWrite_CheckedChanged(object sender, EventArgs e) { }
        private void comboBoxUnit_SelectedIndexChanged(object sender, EventArgs e) { }
        private void groupBox2_Enter(object sender, EventArgs e) { }
    }
}