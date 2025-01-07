namespace I_mPulse
{
    partial class ChatItem
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.chatItemAvatar = new System.Windows.Forms.PictureBox();
            this.chatItemName = new System.Windows.Forms.Label();
            this.chatItemLastMsg = new System.Windows.Forms.Label();
            this.chatItemLastTime = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chatItemAvatar)).BeginInit();
            this.SuspendLayout();
            // 
            // chatItemAvatar
            // 
            this.chatItemAvatar.Location = new System.Drawing.Point(12, 12);
            this.chatItemAvatar.Name = "chatItemAvatar";
            this.chatItemAvatar.Size = new System.Drawing.Size(60, 60);
            this.chatItemAvatar.TabIndex = 0;
            this.chatItemAvatar.TabStop = false;
            // 
            // chatItemName
            // 
            this.chatItemName.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatItemName.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Bold);
            this.chatItemName.Location = new System.Drawing.Point(78, 9);
            this.chatItemName.Name = "chatItemName";
            this.chatItemName.Size = new System.Drawing.Size(254, 19);
            this.chatItemName.TabIndex = 1;
            this.chatItemName.Text = "chatItemName";
            // 
            // chatItemLastMsg
            // 
            this.chatItemLastMsg.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatItemLastMsg.Location = new System.Drawing.Point(79, 32);
            this.chatItemLastMsg.Name = "chatItemLastMsg";
            this.chatItemLastMsg.Size = new System.Drawing.Size(253, 37);
            this.chatItemLastMsg.TabIndex = 2;
            this.chatItemLastMsg.TextChanged += new System.EventHandler(this.chatItemLastMsg_TextChanged);
            this.chatItemLastMsg.Click += new System.EventHandler(this.chatItemLastMsg_Click);
            // 
            // chatItemLastTime
            // 
            this.chatItemLastTime.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.chatItemLastTime.Location = new System.Drawing.Point(281, 68);
            this.chatItemLastTime.Name = "chatItemLastTime";
            this.chatItemLastTime.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chatItemLastTime.Size = new System.Drawing.Size(52, 13);
            this.chatItemLastTime.TabIndex = 3;
            this.chatItemLastTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ChatItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.chatItemLastTime);
            this.Controls.Add(this.chatItemLastMsg);
            this.Controls.Add(this.chatItemName);
            this.Controls.Add(this.chatItemAvatar);
            this.Name = "ChatItem";
            this.Size = new System.Drawing.Size(335, 83);
            this.Load += new System.EventHandler(this.ChatItem_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chatItemAvatar)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox chatItemAvatar;
        private System.Windows.Forms.Label chatItemName;
        private System.Windows.Forms.Label chatItemLastMsg;
        private System.Windows.Forms.Label chatItemLastTime;
    }
}
