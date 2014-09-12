using System;
using System.IO;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
//using SpeechLib;
using System.Net;
using System.Text;
using System.Runtime.InteropServices;
using System.Media;


namespace EnglishWords
{
	/// <summary>
	/// Form1에 대한 요약 설명입니다.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		public System.Windows.Forms.Timer timer1;
        private System.ComponentModel.IContainer components;

		//사용자 정의변수
        private WordFileControl WFC;
		private Form2 form2;
        private Form3 form3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
		public Config m_config;
		private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private ContextMenuStrip contextMenuStrip1;
        private ToolStripMenuItem loadNewWordFileToolStripMenuItem;
        private ToolStripMenuItem settingToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem showFrameToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        public Label labelWord;
        private ToolStripMenuItem CheckShowWordToolStripMenuItem;
        private Label labelMean;
        private ToolStripMenuItem 위치고정ToolStripMenuItem;
		private bool m_bLoadFile = false;

		public Form1()
		{
			//
			// Windows Form 디자이너 지원에 필요합니다.
			//
			InitializeComponent();

			//
			// TODO: InitializeComponent를 호출한 다음 생성자 코드를 추가합니다.
			//
			m_config = new Config();
			timer1.Enabled = m_config.bAutoScroll;
			this.TopMost = m_config.bAlwaysOnTop;
            FontSizeChanged();

            SetStyle(ControlStyles.SupportsTransparentBackColor, true);

			WFC = new WordFileControl(this);
			m_bLoadFile = WFC.LoadNewFile(m_config.DefaultFileName);

			form2 = new Form2(this);

            form3 = new Form3(WFC);

            toolTip1.SetToolTip(labelWord, "Click");

            if (File.Exists(".\\LearnWords.ico"))
            {
                notifyIcon1.Icon = new Icon(".\\LearnWords.ico");
                notifyIcon1.Text = this.Text;
            }
		}

		/// <summary>
		/// 사용 중인 모든 리소스를 정리합니다.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form 디자이너에서 생성한 코드
		/// <summary>
		/// 디자이너 지원에 필요한 메서드입니다.
		/// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.CheckShowWordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadNewWordFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.showFrameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.위치고정ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelWord = new System.Windows.Forms.Label();
            this.labelMean = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 4000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.CheckShowWordToolStripMenuItem,
            this.loadNewWordFileToolStripMenuItem,
            this.toolStripSeparator1,
            this.showFrameToolStripMenuItem,
            this.settingToolStripMenuItem,
            this.toolStripSeparator2,
            this.위치고정ToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.ShowCheckMargin = true;
            this.contextMenuStrip1.ShowImageMargin = false;
            this.contextMenuStrip1.Size = new System.Drawing.Size(184, 170);
            this.contextMenuStrip1.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStrip1_Opening);
            // 
            // CheckShowWordToolStripMenuItem
            // 
            this.CheckShowWordToolStripMenuItem.Name = "CheckShowWordToolStripMenuItem";
            this.CheckShowWordToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.CheckShowWordToolStripMenuItem.Text = "Check Show Word";
            this.CheckShowWordToolStripMenuItem.Click += new System.EventHandler(this.CheckShowWordToolStripMenuItem_Click);
            // 
            // loadNewWordFileToolStripMenuItem
            // 
            this.loadNewWordFileToolStripMenuItem.Name = "loadNewWordFileToolStripMenuItem";
            this.loadNewWordFileToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.loadNewWordFileToolStripMenuItem.Text = "Load New Word File";
            this.loadNewWordFileToolStripMenuItem.Click += new System.EventHandler(this.loadNewWordFileToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(180, 6);
            // 
            // showFrameToolStripMenuItem
            // 
            this.showFrameToolStripMenuItem.CheckOnClick = true;
            this.showFrameToolStripMenuItem.Name = "showFrameToolStripMenuItem";
            this.showFrameToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.showFrameToolStripMenuItem.Text = "Hide Frame";
            this.showFrameToolStripMenuItem.Click += new System.EventHandler(this.showFrameToolStripMenuItem_Click);
            // 
            // settingToolStripMenuItem
            // 
            this.settingToolStripMenuItem.Name = "settingToolStripMenuItem";
            this.settingToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.settingToolStripMenuItem.Text = "Setting";
            this.settingToolStripMenuItem.Click += new System.EventHandler(this.settingToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(180, 6);
            // 
            // 위치고정ToolStripMenuItem
            // 
            this.위치고정ToolStripMenuItem.CheckOnClick = true;
            this.위치고정ToolStripMenuItem.Name = "위치고정ToolStripMenuItem";
            this.위치고정ToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.위치고정ToolStripMenuItem.Text = "위치고정";
            this.위치고정ToolStripMenuItem.Click += new System.EventHandler(this.위치고정ToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // labelWord
            // 
            this.labelWord.AutoSize = true;
            this.labelWord.BackColor = System.Drawing.Color.Black;
            this.labelWord.ContextMenuStrip = this.contextMenuStrip1;
            this.labelWord.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelWord.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelWord.ForeColor = System.Drawing.Color.Yellow;
            this.labelWord.Location = new System.Drawing.Point(0, 0);
            this.labelWord.Name = "labelWord";
            this.labelWord.Size = new System.Drawing.Size(46, 19);
            this.labelWord.TabIndex = 1;
            this.labelWord.Text = "Start!";
            this.labelWord.SizeChanged += new System.EventHandler(this.labelWord_SizeChanged);
            this.labelWord.Click += new System.EventHandler(this.labelWord_Click);
            this.labelWord.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelWord_MouseDown);
            this.labelWord.MouseEnter += new System.EventHandler(this.labelWord_MouseEnter);
            this.labelWord.MouseMove += new System.Windows.Forms.MouseEventHandler(this.labelWord_MouseMove);
            this.labelWord.MouseUp += new System.Windows.Forms.MouseEventHandler(this.labelWord_MouseUp);
            // 
            // labelMean
            // 
            this.labelMean.AutoSize = true;
            this.labelMean.BackColor = System.Drawing.Color.Black;
            this.labelMean.ContextMenuStrip = this.contextMenuStrip1;
            this.labelMean.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelMean.ForeColor = System.Drawing.Color.Aqua;
            this.labelMean.Location = new System.Drawing.Point(52, 0);
            this.labelMean.Name = "labelMean";
            this.labelMean.Size = new System.Drawing.Size(18, 19);
            this.labelMean.TabIndex = 2;
            this.labelMean.Text = "...";
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 14);
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(556, 86);
            this.ContextMenuStrip = this.contextMenuStrip1;
            this.Controls.Add(this.labelMean);
            this.Controls.Add(this.labelWord);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.Text = "Learn Words";
            this.DragDrop += new System.Windows.Forms.DragEventHandler(this.Form1_DragDrop);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private int m_nSequence = 0;
		private string m_strTmp;
        private string [] m_strWordMean;
        //public SpVoice vox = new SpVoice(); // TTS엔진 사용

		// 설정된 시간마다 불려지는 타이머
        [DllImport("winmm.dll")]
        private static extern bool mciGetErrorString(long fdwError, string lpszErrorText, long cchErrorText);

        [DllImport("winmm.dll")]
        private static extern Int32 mciSendString(string command, StringBuilder returnValue, int returnLength, IntPtr winHandle);

        bool m_isReading = false;
		private void timer1_Tick(object sender, System.EventArgs e)
        {
            // 파일을 로딩성공한 상태면
            if (m_bLoadFile)
            {
                if (m_nSequence == 0)
                {
                    m_strTmp = WFC.GetWord();
                    m_strWordMean = m_strTmp.Split('/');
                    labelMean.Text = " ?";
                    //int nCutPos = m_strTmp.IndexOf("/");
                    //// 파일이 형식에 맞지 않다면
                    //if(nCutPos == -1)
                    //{
                    //    labelWord.Text = "잘못된 파일입니다!";
                    //    return;
                    //}
                    labelWord.Text = m_strWordMean[0].Substring(1);  // * 표시 제외
                    //m_strTmp = m_strTmp.Remove(0, nCutPos + 1);
                    timer1.Interval = 1;
                }
                else if (m_nSequence == 1)  // 읽어줌
                {
                    // 설정파일에서 읽어줄것인지 얻어옴
                    m_isReading = m_config.bRead;
                    Int32 err = mciSendString("close MediaFile", null, 0, IntPtr.Zero);

                    // mp3파일이 있으면 읽어주고, 없으면 다운
                    // 다운말고 실시간 인터넷에서 읽어주는처리도...
                    if (m_isReading)
                    {
                        string fileName = "mp3\\e_" + labelWord.Text + ".mp3";
                        err = mciSendString("open \"" + fileName + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                        if (err == 275)
                        {
                            WebClient web = new WebClient();
                            web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 9.0; Windows;)");
                            string encstr = string.Empty;
                            encstr = Uri.EscapeDataString(labelWord.Text.Trim());
                            Console.WriteLine(encstr);
                            web.DownloadFile("http://translate.google.com/translate_tts?tl=en&q=" + encstr, ".\\" + fileName);
                            //byte[] mp3Bytes = web.DownloadData("http://translate.google.com/translate_tts?tl=en&q=" + encstr);
                            //string fileOut = ".\\" + fileName;
                            //FileStream fs = new FileStream(fileOut, FileMode.Create);
                            //fs.Write(mp3Bytes, 0, (int)mp3Bytes.Length);
                            //fs.Close();

                            // 다시 오픈
                            err = mciSendString("open \"" + fileName + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                        }

                        if (err == 0)
                            err = mciSendString("play MediaFile", null, 0, IntPtr.Zero);
                    }

                    timer1.Interval = m_config.GetWordTime();
                }
                else  // 뜻 보여줌
                {
                    Int32 err = mciSendString("close MediaFile", null, 0, IntPtr.Zero);

                    labelMean.Text = m_strWordMean[1];
                    timer1.Interval = m_config.GetMeanTime();

                    if (m_isReading)
                    {
                        string fileName = "mp3\\k_" + labelWord.Text + ".mp3";
                        err = mciSendString("open \"" + fileName + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                        if (err == 275)
                        {
                            WebClient web = new WebClient();
                            web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/4.0 (compatible; MSIE 9.0; Windows;)");
                            string encstr = string.Empty;
                            //string filename = "tts.mp3";
                            //string s = "우리나라";
                            encstr = Uri.EscapeDataString(labelMean.Text);
                            Console.WriteLine(encstr);
                            web.DownloadFile("http://translate.google.com/translate_tts?tl=ko&q=" + encstr, ".\\" + fileName);

                            // 다시 오픈
                            err = mciSendString("open \"" + fileName + "\" type mpegvideo alias MediaFile", null, 0, IntPtr.Zero);
                        }

                        if (err == 0)
                            err = mciSendString("play MediaFile", null, 0, IntPtr.Zero);
                    }
                }


                m_nSequence++;
                if (m_nSequence == 3)
                    m_nSequence = 0;
            }
            else
            {
                labelWord.Text = "파일로딩 실패! 파일 형식을 확인바랍니다!";
            }

            // 위치가 변경된 상태면, 되돌아갈 위치 근처에 마우스가 없으면 위치를 되돌린다.
            if (m_restoreLeft != 0)
            {
                if (100 < Math.Abs(Cursor.Position.X - m_restoreLeft)
                    && 50 < Math.Abs(Cursor.Position.Y - m_restoreTop))
                {
                    this.Left = m_restoreLeft;
                    this.Top = m_restoreTop;

                    m_restoreLeft = 0;
                    m_restoreTop = 0;
                }
            }
        }

        private void labelWord_Click(object sender, EventArgs e)
        {
            if (m_config.bAutoScroll == false)
                timer1_Tick(sender, e);
        }

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			form2.InitSettingWindow();
			form2.ShowDialog();
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			openFileDialog1.InitialDirectory = ".\\";
			openFileDialog1.ShowDialog();
		}

        bool LoadNewWordFile(string strFileName)
        {
            m_bLoadFile = WFC.LoadNewFile(strFileName);
            if (m_bLoadFile == false)
                return false;

            int nCutPos = strFileName.LastIndexOf("\\");
            m_config.DefaultFileName = strFileName.Substring(nCutPos + 1);
            m_config.SaveConfigToFile();

            labelWord.Text = m_config.DefaultFileName + " 파일을 로딩했습니다.";
            timer1.Interval = 3000;
            m_nSequence = 0;

            return true;
        }

		private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
		{
            LoadNewWordFile(openFileDialog1.FileName);
		}

		private void Form1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			char key = e.KeyChar;
			// Space or enter
			if(key == 32 || key == 13)
			{
				if(m_config.bAutoScroll == false)
					timer1_Tick(sender, e);
			}
		}

		private void notifyIcon1_DoubleClick(object sender, System.EventArgs e)
		{
			this.Show();
		}

        bool m_bMoving = false;
        int m_ClickX = 0;
        int m_ClickY = 0;

        private void labelWord_MouseDown(object sender, MouseEventArgs e)
        {
            m_ClickX = e.X;
            m_ClickY = e.Y;
            m_bMoving = true;
        }

        private void labelWord_MouseUp(object sender, MouseEventArgs e)
        {
            m_bMoving = false;
        }

        private void labelWord_MouseMove(object sender, MouseEventArgs e)
        {
            if (m_bMoving)
            {
                int X = e.Location.X;
                this.Left = (this.Left + e.X - m_ClickX);
                this.Top = (this.Top + e.Y - m_ClickY);
            }
        }


        private void loadNewWordFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            openFileDialog1.InitialDirectory = ".\\";
            openFileDialog1.ShowDialog();
        }

        private void settingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form2.InitSettingWindow();
            form2.ShowDialog();
        }

        private void CheckShowWordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            form3.ShowDialog();
        }

        

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void showFrameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.FormBorderStyle == FormBorderStyle.None)
            {
                this.FormBorderStyle = FormBorderStyle.Sizable;
                
                this.Left -= 4;
                this.Top -= 30;
            }
            else
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.Left += 4;
                this.Top += 30;
            }

            this.contextMenuStrip1.Show();
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] file = (string[])e.Data.GetData(DataFormats.FileDrop);
                LoadNewWordFile(file[0]);
            }
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy | DragDropEffects.Scroll;
            }
        }

        public void FontSizeChanged()
        {
            labelWord.Font = new System.Drawing.Font("맑은 고딕", m_config.fFontSize, FontStyle.Bold);
            labelMean.Font = new System.Drawing.Font("맑은 고딕", m_config.fFontSize, FontStyle.Bold);
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {

        }

        private void labelWord_SizeChanged(object sender, EventArgs e)
        {
            labelMean.SetBounds(labelWord.Location.X + labelWord.Size.Width, labelMean.Location.Y, labelMean.Size.Width, labelMean.Size.Height);
            //labelMean.Location.X = labelWord.Location.X + labelWord.Size.Width;
        }

        int m_restoreLeft = 0;
        int m_restoreTop = 0;

        bool m_isFixedPos = false;
        private void 위치고정ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            m_isFixedPos = !m_isFixedPos;
        }

        private void labelWord_MouseEnter(object sender, EventArgs e)
        {
            if (m_restoreLeft != 0)
            {
                ToolStripItem[] aa = contextMenuStrip1.Items.Find("위치고정ToolStripMenuItem", true);
                ((ToolStripMenuItem)aa[0]).Checked = false;
                m_isFixedPos = false;
                m_restoreLeft = 0;
            }
            if (false == m_isFixedPos)
                return;

            m_restoreLeft = this.Left;
            m_restoreTop = this.Top;

            this.Left = 1;
            this.Top = 600;
        }
	}
}
