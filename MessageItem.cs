using System.Drawing;

namespace I_mPulse
{
    public partial class MessageItem : RoundPanel
    {
        public MessageItem()
        {
            InitializeComponent();
        }

        public string MsgText
        {
            get => msg.Text;
            set => msg.Text = value;
        }

        public string MsgTime
        {
            get => time.Text;
            set => time.Text = value;
        }

        public Color MsgColor
        {
            get => msgBG.BackColor;
            set => msgBG.BackColor = value;
        }

        private void label1_SizeChanged(object sender, System.EventArgs e)
        {
            msgBG.Size = new System.Drawing.Size(msg.Size.Width + 17, msg.Size.Height + 31);
            //time.Size = new System.Drawing.Size(msg.Size.Width, time.Size.Height);
        }

        private void msgBG_BackColorChanged(object sender, System.EventArgs e)
        {
            msg.BackColor = msgBG.BackColor;
            time.BackColor = msgBG.BackColor;
        }

        private void MessageItem_Load(object sender, System.EventArgs e)
        {
            msgBG.Controls.Add(time);
        }
    }
}
