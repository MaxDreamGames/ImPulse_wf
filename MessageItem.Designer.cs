
namespace I_mPulse
{
    partial class MessageItem
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
            this.msg = new System.Windows.Forms.Label();
            this.msgBG = new System.Windows.Forms.Panel();
            this.time = new System.Windows.Forms.Label();
            this.msgBG.SuspendLayout();
            this.SuspendLayout();
            // 
            // msg
            // 
            this.msg.AutoSize = true;
            this.msg.BackColor = System.Drawing.Color.Black;
            this.msg.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.msg.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            this.msg.ForeColor = System.Drawing.Color.White;
            this.msg.Location = new System.Drawing.Point(5, 4);
            this.msg.MaximumSize = new System.Drawing.Size(430, 530);
            this.msg.MinimumSize = new System.Drawing.Size(21, 17);
            this.msg.Name = "msg";
            this.msg.Size = new System.Drawing.Size(21, 17);
            this.msg.TabIndex = 1;
            this.msg.Text = "W";
            this.msg.SizeChanged += new System.EventHandler(this.label1_SizeChanged);
            // 
            // msgBG
            // 
            this.msgBG.AutoSize = true;
            this.msgBG.BackColor = System.Drawing.Color.Black;
            this.msgBG.Controls.Add(this.msg);
            this.msgBG.Controls.Add(this.time);
            this.msgBG.Location = new System.Drawing.Point(13, 4);
            this.msgBG.MaximumSize = new System.Drawing.Size(450, 550);
            this.msgBG.MinimumSize = new System.Drawing.Size(55, 48);
            this.msgBG.Name = "msgBG";
            this.msgBG.Size = new System.Drawing.Size(55, 48);
            this.msgBG.TabIndex = 0;
            this.msgBG.BackColorChanged += new System.EventHandler(this.msgBG_BackColorChanged);
            // 
            // time
            // 
            this.time.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.time.BackColor = System.Drawing.Color.Black;
            this.time.ForeColor = System.Drawing.Color.White;
            this.time.Location = new System.Drawing.Point(14, 29);
            this.time.MaximumSize = new System.Drawing.Size(35, 13);
            this.time.Name = "time";
            this.time.Size = new System.Drawing.Size(35, 13);
            this.time.TabIndex = 2;
            this.time.Text = "06:09";
            this.time.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MessageItem
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoSize = true;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.msgBG);
            this.MaximumSize = new System.Drawing.Size(805, 550);
            this.MinimumSize = new System.Drawing.Size(805, 35);
            this.Name = "MessageItem";
            this.Size = new System.Drawing.Size(875, 55);
            this.Load += new System.EventHandler(this.MessageItem_Load);
            this.msgBG.ResumeLayout(false);
            this.msgBG.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel msgBG;
        private System.Windows.Forms.Label msg;
        private System.Windows.Forms.Label time;
    }
}
