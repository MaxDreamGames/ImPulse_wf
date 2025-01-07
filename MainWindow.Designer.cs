namespace I_mPulse
{
    partial class MainWindow
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainWindow));
            this.bufferBtn = new System.Windows.Forms.Button();
            this.chatsPanel = new System.Windows.Forms.Panel();
            this.chatsLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.searchSparkText = new System.Windows.Forms.TextBox();
            this.openedChatPanel = new System.Windows.Forms.Panel();
            this.msgsLayout = new System.Windows.Forms.FlowLayoutPanel();
            this.sendMsgPanel = new System.Windows.Forms.Panel();
            this.msgSendText = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.openedChatInfoPanel = new System.Windows.Forms.Panel();
            this.openedChatInfoStatus = new System.Windows.Forms.Label();
            this.openedChatInfoChatName = new System.Windows.Forms.Label();
            this.noChatPanel = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.hat = new System.Windows.Forms.Panel();
            this.minimiseBtn = new System.Windows.Forms.Panel();
            this.minmaxBtn = new System.Windows.Forms.Panel();
            this.closeBtn = new System.Windows.Forms.Panel();
            this.windowName = new System.Windows.Forms.Label();
            this.hatImage = new System.Windows.Forms.PictureBox();
            this.chatsPanel.SuspendLayout();
            this.openedChatPanel.SuspendLayout();
            this.sendMsgPanel.SuspendLayout();
            this.openedChatInfoPanel.SuspendLayout();
            this.noChatPanel.SuspendLayout();
            this.hat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hatImage)).BeginInit();
            this.SuspendLayout();
            // 
            // bufferBtn
            // 
            this.bufferBtn.Location = new System.Drawing.Point(0, 37);
            this.bufferBtn.Name = "bufferBtn";
            this.bufferBtn.Size = new System.Drawing.Size(1, 1);
            this.bufferBtn.TabIndex = 3;
            this.bufferBtn.TabStop = false;
            this.bufferBtn.UseVisualStyleBackColor = true;
            // 
            // chatsPanel
            // 
            this.chatsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.chatsPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.chatsPanel.Controls.Add(this.chatsLayoutPanel);
            this.chatsPanel.Controls.Add(this.searchSparkText);
            this.chatsPanel.Location = new System.Drawing.Point(0, 34);
            this.chatsPanel.Name = "chatsPanel";
            this.chatsPanel.Size = new System.Drawing.Size(359, 686);
            this.chatsPanel.TabIndex = 9;
            // 
            // chatsLayoutPanel
            // 
            this.chatsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatsLayoutPanel.AutoScroll = true;
            this.chatsLayoutPanel.Location = new System.Drawing.Point(0, 41);
            this.chatsLayoutPanel.Name = "chatsLayoutPanel";
            this.chatsLayoutPanel.Size = new System.Drawing.Size(357, 643);
            this.chatsLayoutPanel.TabIndex = 10;
            // 
            // searchSparkText
            // 
            this.searchSparkText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchSparkText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.searchSparkText.ForeColor = System.Drawing.Color.Gray;
            this.searchSparkText.Location = new System.Drawing.Point(51, 9);
            this.searchSparkText.Name = "searchSparkText";
            this.searchSparkText.Size = new System.Drawing.Size(251, 26);
            this.searchSparkText.TabIndex = 10;
            this.searchSparkText.TabStop = false;
            this.searchSparkText.Text = "Поиск";
            this.searchSparkText.TextChanged += new System.EventHandler(this.searchSparkText_TextChanged);
            this.searchSparkText.Enter += new System.EventHandler(this.searchSparkText_Enter);
            this.searchSparkText.Leave += new System.EventHandler(this.searchSparkText_Leave);
            // 
            // openedChatPanel
            // 
            this.openedChatPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openedChatPanel.BackColor = System.Drawing.Color.Transparent;
            this.openedChatPanel.Controls.Add(this.msgsLayout);
            this.openedChatPanel.Controls.Add(this.sendMsgPanel);
            this.openedChatPanel.Controls.Add(this.openedChatInfoPanel);
            this.openedChatPanel.Location = new System.Drawing.Point(360, 38);
            this.openedChatPanel.Name = "openedChatPanel";
            this.openedChatPanel.Size = new System.Drawing.Size(920, 682);
            this.openedChatPanel.TabIndex = 10;
            // 
            // msgsLayout
            // 
            this.msgsLayout.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgsLayout.AutoScroll = true;
            this.msgsLayout.BackColor = System.Drawing.Color.DarkSlateBlue;
            this.msgsLayout.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.msgsLayout.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.msgsLayout.Location = new System.Drawing.Point(10, 46);
            this.msgsLayout.Name = "msgsLayout";
            this.msgsLayout.Size = new System.Drawing.Size(903, 561);
            this.msgsLayout.TabIndex = 5;
            this.msgsLayout.WrapContents = false;
            // 
            // sendMsgPanel
            // 
            this.sendMsgPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sendMsgPanel.AutoSize = true;
            this.sendMsgPanel.Controls.Add(this.msgSendText);
            this.sendMsgPanel.Controls.Add(this.button1);
            this.sendMsgPanel.Location = new System.Drawing.Point(10, 640);
            this.sendMsgPanel.Name = "sendMsgPanel";
            this.sendMsgPanel.Size = new System.Drawing.Size(906, 37);
            this.sendMsgPanel.TabIndex = 3;
            // 
            // msgSendText
            // 
            this.msgSendText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.msgSendText.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.msgSendText.Location = new System.Drawing.Point(0, 0);
            this.msgSendText.Margin = new System.Windows.Forms.Padding(3, 6, 3, 6);
            this.msgSendText.Multiline = true;
            this.msgSendText.Name = "msgSendText";
            this.msgSendText.Size = new System.Drawing.Size(827, 37);
            this.msgSendText.TabIndex = 1;
            this.msgSendText.KeyDown += new System.Windows.Forms.KeyEventHandler(this.msgSendText_KeyDown);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.button1.Location = new System.Drawing.Point(833, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(70, 31);
            this.button1.TabIndex = 2;
            this.button1.Text = "Отпр";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // openedChatInfoPanel
            // 
            this.openedChatInfoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openedChatInfoPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.openedChatInfoPanel.Controls.Add(this.openedChatInfoStatus);
            this.openedChatInfoPanel.Controls.Add(this.openedChatInfoChatName);
            this.openedChatInfoPanel.Location = new System.Drawing.Point(0, 0);
            this.openedChatInfoPanel.Name = "openedChatInfoPanel";
            this.openedChatInfoPanel.Size = new System.Drawing.Size(920, 40);
            this.openedChatInfoPanel.TabIndex = 0;
            // 
            // openedChatInfoStatus
            // 
            this.openedChatInfoStatus.AutoSize = true;
            this.openedChatInfoStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F);
            this.openedChatInfoStatus.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(55)))), ((int)(((byte)(237)))));
            this.openedChatInfoStatus.Location = new System.Drawing.Point(3, 17);
            this.openedChatInfoStatus.Name = "openedChatInfoStatus";
            this.openedChatInfoStatus.Size = new System.Drawing.Size(47, 20);
            this.openedChatInfoStatus.TabIndex = 1;
            this.openedChatInfoStatus.Text = "None";
            // 
            // openedChatInfoChatName
            // 
            this.openedChatInfoChatName.AutoSize = true;
            this.openedChatInfoChatName.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold);
            this.openedChatInfoChatName.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(228)))), ((int)(((byte)(55)))), ((int)(((byte)(237)))));
            this.openedChatInfoChatName.Location = new System.Drawing.Point(3, -3);
            this.openedChatInfoChatName.Name = "openedChatInfoChatName";
            this.openedChatInfoChatName.Size = new System.Drawing.Size(61, 24);
            this.openedChatInfoChatName.TabIndex = 0;
            this.openedChatInfoChatName.Text = "None";
            // 
            // noChatPanel
            // 
            this.noChatPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.noChatPanel.BackColor = System.Drawing.Color.Transparent;
            this.noChatPanel.Controls.Add(this.label1);
            this.noChatPanel.Location = new System.Drawing.Point(360, 380);
            this.noChatPanel.Name = "noChatPanel";
            this.noChatPanel.Size = new System.Drawing.Size(921, 682);
            this.noChatPanel.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(245, 304);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(430, 54);
            this.label1.TabIndex = 0;
            this.label1.Text = "Вы еще не начали общение =)";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // hat
            // 
            this.hat.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.hat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(158)))), ((int)(((byte)(155)))), ((int)(((byte)(173)))));
            this.hat.BackgroundImage = global::I_mPulse.Properties.Resources.Hat;
            this.hat.Controls.Add(this.minimiseBtn);
            this.hat.Controls.Add(this.minmaxBtn);
            this.hat.Controls.Add(this.closeBtn);
            this.hat.Controls.Add(this.windowName);
            this.hat.Controls.Add(this.hatImage);
            this.hat.Location = new System.Drawing.Point(0, 0);
            this.hat.MaximumSize = new System.Drawing.Size(1920, 37);
            this.hat.MinimumSize = new System.Drawing.Size(420, 37);
            this.hat.Name = "hat";
            this.hat.Size = new System.Drawing.Size(1280, 37);
            this.hat.TabIndex = 11;
            this.hat.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.hat_MouseDoubleClick);
            this.hat.MouseDown += new System.Windows.Forms.MouseEventHandler(this.hat_MouseDown);
            this.hat.MouseMove += new System.Windows.Forms.MouseEventHandler(this.hat_MouseMove);
            this.hat.MouseUp += new System.Windows.Forms.MouseEventHandler(this.hat_MouseUp);
            // 
            // minimiseBtn
            // 
            this.minimiseBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.minimiseBtn.BackColor = System.Drawing.Color.Transparent;
            this.minimiseBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minimiseBtn.Location = new System.Drawing.Point(1171, 0);
            this.minimiseBtn.Name = "minimiseBtn";
            this.minimiseBtn.Padding = new System.Windows.Forms.Padding(3);
            this.minimiseBtn.Size = new System.Drawing.Size(37, 37);
            this.minimiseBtn.TabIndex = 5;
            this.minimiseBtn.Click += new System.EventHandler(this.minimizeBtn_Click);
            // 
            // minmaxBtn
            // 
            this.minmaxBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.minmaxBtn.BackColor = System.Drawing.Color.Transparent;
            this.minmaxBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.minmaxBtn.Location = new System.Drawing.Point(1207, 0);
            this.minmaxBtn.Name = "minmaxBtn";
            this.minmaxBtn.Padding = new System.Windows.Forms.Padding(3);
            this.minmaxBtn.Size = new System.Drawing.Size(37, 37);
            this.minmaxBtn.TabIndex = 4;
            this.minmaxBtn.Click += new System.EventHandler(this.minmaxBtn_Click);
            // 
            // closeBtn
            // 
            this.closeBtn.Anchor = System.Windows.Forms.AnchorStyles.Right;
            this.closeBtn.BackColor = System.Drawing.Color.Transparent;
            this.closeBtn.BackgroundImage = global::I_mPulse.Properties.Resources.CloseBtn;
            this.closeBtn.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.closeBtn.Location = new System.Drawing.Point(1244, 0);
            this.closeBtn.Name = "closeBtn";
            this.closeBtn.Padding = new System.Windows.Forms.Padding(3);
            this.closeBtn.Size = new System.Drawing.Size(37, 37);
            this.closeBtn.TabIndex = 3;
            this.closeBtn.Click += new System.EventHandler(this.closeBtn_Click);
            this.closeBtn.MouseEnter += new System.EventHandler(this.closeBtn_MouseEnter);
            this.closeBtn.MouseLeave += new System.EventHandler(this.closeBtn_MouseLeave);
            // 
            // windowName
            // 
            this.windowName.AutoSize = true;
            this.windowName.BackColor = System.Drawing.Color.Transparent;
            this.windowName.Font = new System.Drawing.Font("Comic Sans MS", 16F, System.Drawing.FontStyle.Bold);
            this.windowName.ForeColor = System.Drawing.Color.Yellow;
            this.windowName.Location = new System.Drawing.Point(41, 5);
            this.windowName.Name = "windowName";
            this.windowName.Size = new System.Drawing.Size(76, 31);
            this.windowName.TabIndex = 2;
            this.windowName.Text = "label2";
            // 
            // hatImage
            // 
            this.hatImage.BackColor = System.Drawing.Color.Transparent;
            this.hatImage.BackgroundImage = global::I_mPulse.Properties.Resources.ImpulseIcon;
            this.hatImage.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.hatImage.Location = new System.Drawing.Point(3, 3);
            this.hatImage.Name = "hatImage";
            this.hatImage.Size = new System.Drawing.Size(32, 32);
            this.hatImage.TabIndex = 1;
            this.hatImage.TabStop = false;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::I_mPulse.Properties.Resources.Bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1280, 720);
            this.Controls.Add(this.noChatPanel);
            this.Controls.Add(this.hat);
            this.Controls.Add(this.openedChatPanel);
            this.Controls.Add(this.chatsPanel);
            this.Controls.Add(this.bufferBtn);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainWindow";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.chatsPanel.ResumeLayout(false);
            this.chatsPanel.PerformLayout();
            this.openedChatPanel.ResumeLayout(false);
            this.openedChatPanel.PerformLayout();
            this.sendMsgPanel.ResumeLayout(false);
            this.sendMsgPanel.PerformLayout();
            this.openedChatInfoPanel.ResumeLayout(false);
            this.openedChatInfoPanel.PerformLayout();
            this.noChatPanel.ResumeLayout(false);
            this.hat.ResumeLayout(false);
            this.hat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hatImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button bufferBtn;
        private System.Windows.Forms.Panel chatsPanel;
        private System.Windows.Forms.TextBox searchSparkText;
        private System.Windows.Forms.FlowLayoutPanel chatsLayoutPanel;
        private System.Windows.Forms.Panel openedChatPanel;
        private System.Windows.Forms.Panel openedChatInfoPanel;
        private System.Windows.Forms.Label openedChatInfoChatName;
        private System.Windows.Forms.Label openedChatInfoStatus;
        private System.Windows.Forms.TextBox msgSendText;
        private System.Windows.Forms.Panel sendMsgPanel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.FlowLayoutPanel msgsLayout;
        private System.Windows.Forms.Panel noChatPanel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel hat;
        private System.Windows.Forms.Panel closeBtn;
        private System.Windows.Forms.Label windowName;
        private System.Windows.Forms.PictureBox hatImage;
        private System.Windows.Forms.Panel minmaxBtn;
        private System.Windows.Forms.Panel minimiseBtn;
    }
}

