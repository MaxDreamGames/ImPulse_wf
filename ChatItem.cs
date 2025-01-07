using System;
using System.Drawing;
using System.Windows.Forms;

namespace I_mPulse
{
    public partial class ChatItem : UserControl
    {
        public ChatItem()
        {
            InitializeComponent();

            chatItemName.Click += RedirectClick;
            chatItemLastMsg.Click += RedirectClick;
            chatItemLastTime.Click += RedirectClick;
            chatItemAvatar.Click += RedirectClick;
        }

        ~ChatItem() { }

        private void ChatItem_Load(object sender, EventArgs e)
        {

        }

        public Image ChatAvatar
        {
            get => chatItemAvatar.Image;
            set => chatItemAvatar.Image = value;
        }

        public string ChatName
        {
            get => chatItemName.Text;
            set => chatItemName.Text = value;
        }

        public string LastMessage
        {
            get => chatItemLastMsg.Text;
            set => chatItemLastMsg.Text = value;
        }

        public string LastMessageTime
        {
            get => chatItemLastTime.Text;
            set => chatItemLastTime.Text = value;
        }

        public int UserID { set; get; }

        public int ChatID { set; get; }

        private void RedirectClick(object sender, EventArgs e)
        {
            this.OnClick(e); // Вызываем событие Click для UserControl
        }

        private void chatItemLastMsg_Click(object sender, EventArgs e)
        {

        }

        private void chatItemLastMsg_TextChanged(object sender, EventArgs e)
        {
            chatItemLastMsg.Text = LastMessage;
        }
    }
}
