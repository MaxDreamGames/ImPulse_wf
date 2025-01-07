using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using Serilog;

namespace I_mPulse
{
    public partial class MainWindow : Form
    {
        public Dictionary<string, string> currentUserData = new Dictionary<string, string>();

        Color closeBtnColor;
        bool isDraging = false;
        Point startPoint = new Point(0, 0);
        DatabaseManager databaseManager = new DatabaseManager();
        List<ChatItem> searchChatItems = new List<ChatItem>();
        List<string[]> userChatItemsInfo = new List<string[]>();
        List<ChatItem> userChatItems = new List<ChatItem>();

        TCPClient client;
        Chat currentChat;
        DataTable allUsersInDb;
        private bool isSearching;
        int connectionTryings;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            Log.Information("\nNew session has been started.");
            closeBtnColor = closeBtn.BackColor;
            windowName.Text = Text;
            bufferBtn.Focus();
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("Jura-VariableFont_wght.ttf");
            fontCollection.AddFontFile("Play-Regular.ttf");
            windowName.Font = new Font(fontCollection.Families[0], windowName.Font.Size, FontStyle.Bold);
            foreach (var controlItem in this.Controls.OfType<Label>())
            {
                if (controlItem == windowName) continue;
                controlItem.Font = new Font(fontCollection.Families[1], controlItem.Font.Size, FontStyle.Regular);

            }
            openedChatInfoChatName.Font = new Font(fontCollection.Families[1], openedChatInfoChatName.Font.Size, FontStyle.Bold);
            openedChatInfoStatus.Font = new Font(fontCollection.Families[1], openedChatInfoStatus.Font.Size, FontStyle.Regular);

            RegistrationDiologWindow rdw = new RegistrationDiologWindow();
            rdw.mainWindow = this;
            rdw.ShowDialog();
            if (rdw.isExiting)
                return;
            allUsersInDb = databaseManager.Request($"select UserID, Username from Users;");
        }


        private void hat_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (WindowState == FormWindowState.Maximized)
                WindowState = FormWindowState.Normal;
            else if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
        }

        private void closeBtn_Click(object sender, EventArgs e)
        {
            client?.CloseConnection();
            Log.Information("Session has been ended.");
            Application.Exit();
            bufferBtn.Focus();
        }

        private void minimizeBtn_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
            bufferBtn.Focus();
        }

        private void closeBtn_MouseEnter(object sender, EventArgs e)
        {
            closeBtn.BackColor = Color.FromArgb(25, Color.White);
        }

        private void closeBtn_MouseLeave(object sender, EventArgs e)
        {
            closeBtn.BackColor = closeBtnColor;
        }

        private void hat_MouseDown(object sender, MouseEventArgs e)
        {
            isDraging = true;
            startPoint = new Point(e.X, e.Y);
        }

        private void hat_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDraging)
            {
                Point p = PointToScreen(e.Location);
                Point delta = new Point(p.X - startPoint.X, p.Y - startPoint.Y);
                Location = delta;
                if ((delta.X != 0 || delta.Y != 0) && WindowState == FormWindowState.Maximized)
                    WindowState = FormWindowState.Normal;
            }
        }

        private void hat_MouseUp(object sender, MouseEventArgs e)
        {
            isDraging = false;
        }

        private void minmaxBtn_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
                WindowState = FormWindowState.Maximized;
            else
                WindowState = FormWindowState.Normal;
            bufferBtn.Focus();
        }
        protected override CreateParams CreateParams
        {
            get
            {
                const int WS_SIZEBOX = 0x40000;

                var cp = base.CreateParams;
                cp.Style |= WS_SIZEBOX;

                return cp;
            }
        }


        public async void TCPConnect()
        {
            client = new TCPClient();
            await client.Connect("185.233.187.93", 9090);
            if (!client.IsConnected)
            {
                MessageBox.Show("Подключение к серверу не удалось!", "Ошибка подключения", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                RegistrationDiologWindow rdw = new RegistrationDiologWindow();
                rdw.mainWindow = this;
                currentUserData.Clear();
                rdw.ShowDialog();
                return;
            }
            Log.Information($"User \"{currentUserData["Username"]}\" has been signed in on {currentUserData["IP"]}.");
            client.MessageReceived += OnMessageReceived;
            SetUserChatItems();
        }


        private void searchSparkText_TextChanged(object sender, EventArgs e)
        {
            //if (searchSparkText.Text.Length == 0) return;
            SearchUser(searchSparkText.Text);
        }

        private void searchSparkText_Enter(object sender, EventArgs e)
        {
            if (searchSparkText.Text == "Поиск")
            {
                searchSparkText.ForeColor = Color.Black;
                searchSparkText.Text = string.Empty;
            }
        }

        private void searchSparkText_Leave(object sender, EventArgs e)
        {
            if (searchSparkText.Text == string.Empty)
            {
                searchSparkText.ForeColor = Color.Gray;
                searchSparkText.Text = "Поиск";
            }
            //allUsersInDb.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SendMsg(currentChat.GetChatItem());
        }

        private void msgSendText_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && e.Shift)
            {
                e.Handled = true;
            }
            else if (e.KeyCode == Keys.Enter)
            {
                int enterIndex = msgSendText.Text.LastIndexOf('\r');
                if (enterIndex >= 0)
                    msgSendText.Text = msgSendText.Text.Remove(enterIndex, 2);
                SendMsg(currentChat.GetChatItem());
                e.Handled = true;
            }
        }


        #region MyGeneralMethods
        private void SetUserChatItems()
        {
            chatsLayoutPanel.Visible = false;
            chatsLayoutPanel.SuspendLayout();
            var chatsList = databaseManager.Request($"SELECT Chats.ChatID, Chats.ChatName, Chats.LastMsgID, Chats.IsGroup FROM Chats JOIN UserChats ON Chats.ChatID = UserChats.ChatID WHERE UserChats.UserID = {currentUserData["UserID"]};");
            if (chatsList.Rows.Count == 0) return;
            DateTime date = DateTime.MinValue;
            foreach (DataRow row in chatsList.Rows)
            {
                Invoke(new Action(() =>
                {
                    ChatItem chatItem = new ChatItem();
                    chatItem.ChatID = int.Parse(row[0].ToString());
                    int getterID = int.Parse(databaseManager.Request($"SELECT UserID FROM UserChats WHERE ChatID = {chatItem.ChatID} AND NOT UserID = {currentUserData["UserID"]};").Rows[0][0].ToString());
                    Console.WriteLine(chatsList.Rows[0][3].ToString());
                    if (chatsList.Rows[0][3].ToString() == "True")
                        chatItem.ChatName = row[1].ToString();
                    else
                        chatItem.ChatName = databaseManager.Request($"SELECT Username FROM Users WHERE UserID = {getterID};").Rows[0][0].ToString();
                    chatItem.UserID = getterID;
                    DataTable msgs = databaseManager.Request($"SELECT * FROM Messages WHERE ChatID = {chatItem.ChatID};");
                    DataRow lastMsg = msgs.Rows[msgs.Rows.Count - 1];
                    chatItem.LastMessage = lastMsg[3].ToString();
                    chatItem.LastMessageTime = lastMsg[4].ToString().Substring(11, 5);
                    string lastMsgTime = lastMsg[4].ToString();
                    string[] dateTime = lastMsgTime.Split(' ');
                    string[] d = dateTime[0].Split('.');
                    string[] t = dateTime[1].Split(':');
                    DateTime dtime = new DateTime(int.Parse(d[2]), int.Parse(d[1]), int.Parse(d[0]), int.Parse(t[0]), int.Parse(t[1]), int.Parse(t[2]));
                    chatItem.Click += (sender, args) => OpenChat(chatItem);
                    string[] chatInfo = { chatItem.ChatName, chatItem.UserID.ToString(), chatItem.LastMessage, chatItem.LastMessageTime };
                    userChatItemsInfo.Add(chatInfo);
                    chatsLayoutPanel.Controls.Add(chatItem);
                    if (dtime > date)
                    {
                        userChatItems.Insert(0, chatItem);
                        chatsLayoutPanel.Controls.SetChildIndex(chatItem, 0);
                        date = dtime;
                    }
                    else
                        userChatItems.Add(chatItem);
                }));
            }
            chatsLayoutPanel.ResumeLayout();
            chatsLayoutPanel.Visible = true;
        }

        private void SetChatsMessages(int chatID)
        {
            msgsLayout.SuspendLayout();
            if (InvokeRequired)
            {
                Invoke(new Action(() => SetChatsMessages(chatID)));
                return;
            }
            DataTable msgs = databaseManager.Request($"SELECT * FROM Messages WHERE ChatID = {chatID};");
            for (int i = msgs.Rows.Count - 1; i >= 0; i--)
            {
                DataRow msg = msgs.Rows[i];
                ShowMessage(msg[3].ToString(), msg[4].ToString().Substring(11, 5), msg[2].ToString() == currentUserData["UserID"], true);
            }
            msgsLayout.ResumeLayout();
            msgsLayout.VerticalScroll.Value = msgsLayout.VerticalScroll.Maximum;
            msgsLayout.PerformLayout();
            msgsLayout.VerticalScroll.Value = msgsLayout.VerticalScroll.Maximum;
            msgsLayout.PerformLayout();
        }

        private void OnMessageReceived(string obj)
        {
            Log.Debug(obj);
            string[] strings = obj.Split(' ');
            string date = strings[0];
            string ip = strings[1].Replace(":", "");
            string msg = obj.Remove(0, strings[0].Length + 1 + ip.Length + 2).Replace("\\\'", "\'").Replace("\\\"", "\"");
            Console.WriteLine(msg);
            string companionName = Chat.GetInfoFromIP("Username", ip);
            var chatsList = databaseManager.Request($"SELECT Chats.ChatID, Chats.ChatName, Chats.IsGroup FROM Chats JOIN UserChats ON Chats.ChatID = UserChats.ChatID WHERE UserChats.UserID = {currentUserData["UserID"]} AND ChatName = '{companionName}';");
            if (userChatItems.Find(item => item.ChatID == int.Parse(chatsList.Rows[0][0].ToString())) == null)
            {
                ChatItem chatItem = new ChatItem();
                chatItem.ChatName = companionName;
                chatItem.UserID = int.Parse(Chat.GetInfoFromIP("UserID", ip));
                chatItem.LastMessage = msg;
                chatItem.LastMessageTime = date.Split('/')[1].Remove(5, 3);
                int chatId = databaseManager.Request($"select ChatID from Chats;").Rows.Count;
                chatItem.ChatID = chatId;
                chatItem.Click += (sender, args) => OpenChat(chatItem);
                string[] chatInfo = { chatItem.ChatName, chatItem.UserID.ToString(), chatItem.LastMessage, chatItem.LastMessageTime };
                userChatItemsInfo.Add(chatInfo);
                userChatItems.Insert(0, chatItem);

                if (chatsLayoutPanel.InvokeRequired)
                    chatsLayoutPanel.Invoke(new Action(() => chatsLayoutPanel.Controls.SetChildIndex(chatItem, 0)));
                else
                    chatsLayoutPanel.Controls.SetChildIndex(chatItem, 0);
            }
            else
            {
                UpdateChat(userChatItems.FirstOrDefault(item => item.ChatID == int.Parse(databaseManager.Request($"SELECT Chats.ChatID FROM Chats JOIN UserChats ON Chats.ChatID = UserChats.ChatID WHERE Chats.ChatID = {chatsList.Rows[0][0]} AND NOT UserChats.UserID = {currentUserData["UserID"]};").Rows[0][0].ToString())), msg, chatsList.Rows[0][1].ToString());

            }
        }

        void UpdateChat(ChatItem chatItem, string message, string chatName)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => UpdateChat(chatItem, message, chatName)));
                return;
            }



            if (chatItem != null)
            {
                //chatsLayoutPanel.Controls.Clear();
                if (userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID) != null) userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID).LastMessage = message;
                if (userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID) != null) userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID).LastMessageTime = DateTime.Now.ToString("HH:mm");

                string chatId = databaseManager.Request($"select ChatID from Chats where ChatName = '{chatName}';").Rows[0][0].ToString();

                //SetUserChatItems();
                if (currentChat.GetChatID().ToString() == chatId)
                {
                    currentChat.SetLastMsg(message);
                    ShowMessage(message, chatItem.LastMessageTime, false);
                }

                SwapElements(userChatItems, chatItem);
                chatsLayoutPanel.Controls.SetChildIndex(userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID), 0);
            }
            else
            {
                Log.Error($"Chat with Name \"{chatItem.ChatName}\" hasn't been found.");
            }
        }


        void SearchUser(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                SearchChatItemsClear();
                SetUserChatItems();
                return;
            }
            //chatsLayoutPanel.Visible = false;
            //chatsLayoutPanel.SuspendLayout();
            isSearching = true;
            SearchChatItemsClear();
            List<Control> controls = new List<Control>();
            for (int i = 0; i < allUsersInDb.Rows.Count; i++)
            {
                if (allUsersInDb.Rows[i][1].ToString() == currentUserData["Username"]) continue;
                if (!allUsersInDb.Rows[i][1].ToString().ToLower().StartsWith(username.ToLower())) continue;
                Invoke(new Action(() =>
                {
                    if (userChatItems.FirstOrDefault(item => item.ChatName == allUsersInDb.Rows[i][1].ToString()) != null)
                    {
                        ChatItem chati = userChatItems.FirstOrDefault(item => item.ChatName == allUsersInDb.Rows[i][1].ToString());
                        controls.Add(chati);
                        return;
                    }
                    ChatItem chatItem = new ChatItem();
                    chatItem.UserID = int.Parse(allUsersInDb.Rows[i][0].ToString());
                    chatItem.ChatName = allUsersInDb.Rows[i][1].ToString();
                    int chatId = databaseManager.Request($"select ChatID from Chats;").Rows.Count + 1;
                    chatItem.ChatID = chatId;
                    chatItem.Click += (sender, args) => OpenChat(chatItem);
                    controls.Add(chatItem);
                }));
            }
            //chatsLayoutPanel.ResumeLayout();
            chatsLayoutPanel.Visible = true;
            chatsLayoutPanel.Controls.AddRange(controls.ToArray());
        }

        private void SearchChatItemsClear()
        {
            chatsLayoutPanel.Controls.Clear();
            foreach (var item in searchChatItems)
            {
                item.Dispose();
                searchChatItems.Remove(item);
            }
        }

        private void OpenChat(ChatItem chatItem)
        {
            if (chatItem != null)
            {
                ClearChatArea();
            }
            if (currentChat?.GetChatID() == chatItem.ChatID) return;

            openedChatPanel.Visible = true;
            openedChatInfoChatName.Text = chatItem.ChatName;

            string chatId = chatItem.ChatID.ToString();
            currentChat = new Chat(chatItem.ChatName, chatItem.UserID, int.Parse(chatId), chatItem);
            SetChatsMessages(int.Parse(chatId));
            noChatPanel.Visible = false;
        }

        private void ShowMessage(string msg, string msgTime, bool isMine, bool isFilling = false)
        {
            if (InvokeRequired)
            {
                Invoke(new Action(() => ShowMessage(msg, msgTime, isMine, isFilling)));
                return;
            }

            if (msg == string.Empty) return;
            //msgsLayout.SuspendLayout();
            MessageItem messageItem = new MessageItem();
            messageItem.MsgText = @msg;
            messageItem.MsgTime = msgTime;
            msgsLayout.Controls.Add(messageItem);
            if (!isFilling)
                msgsLayout.Controls.SetChildIndex(messageItem, 0);
            if (isMine)
            {
                messageItem.MsgColor = Color.DarkBlue;
                msgSendText.Text = string.Empty;
            }
            msgsLayout.VerticalScroll.Value = msgsLayout.VerticalScroll.Maximum;
            msgsLayout.PerformLayout();
            //msgsLayout.ResumeLayout();
        }

        private void SendMsg(ChatItem chatItem)
        {
            if (currentChat == null) return;
            if (isSearching && string.IsNullOrEmpty(chatItem.LastMessage))
            {
                databaseManager.Request($"INSERT INTO Chats (ChatID, ChatName, IsGroup, Created) VALUES ({chatItem.ChatID}, '{chatItem.ChatName}', FALSE, '{DateTime.Now:yyyy-MM-dd HH:mm:ss}');");
                databaseManager.Request($"INSERT INTO UserChats (UserID, ChatID) VALUES ({chatItem.UserID}, {chatItem.ChatID});");
                databaseManager.Request($"INSERT INTO UserChats (UserID, ChatID) VALUES ({currentUserData["UserID"]}, {chatItem.ChatID});");
                chatsLayoutPanel.Controls.Clear();
            }
            string msg = msgSendText.Text.Replace("\'", "\\\'").Replace("\"", "\\\"");
            Console.WriteLine(msg);
            client.SendMessageTo(currentChat.GetIpAddress(), msg);
            int msgId = databaseManager.Request($"select MessageID from Messages;").Rows.Count + 1;
            databaseManager.Request($"INSERT INTO Messages (MessageID, ChatID, SenderID, Content, Timestamp) VALUES ({msgId}, {currentChat.GetChatID()}, {currentUserData["UserID"]}, '{msg}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}');");
            if (userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID) != null) userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID).LastMessage = msgSendText.Text;
            if (userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID) != null) userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID).LastMessageTime = DateTime.Now.ToString("HH:mm");
            ShowMessage(msgSendText.Text, DateTime.Now.ToString("HH:mm"), true);
            if (isSearching)
            {
                searchSparkText.Text = string.Empty;
                SetUserChatItems();
                RemoveDuplicates(userChatItems);
                RemoveUIDuplicates();
                isSearching = false;
            }
            SwapElements(userChatItems, userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID));
            chatsLayoutPanel.Controls.SetChildIndex(userChatItems.FirstOrDefault(item => item.ChatID == chatItem.ChatID), 0);
        }

        private void ClearChatArea()
        {
            //openedChatInfoChatName.Text = "";
            msgsLayout.Controls.Clear();
        }

        private void RemoveDuplicates(List<ChatItem> list)
        {
            List<ChatItem> temp = new List<ChatItem>();
            for (int i = 0; i < list.Count; i++)
            {
                if (temp.FirstOrDefault(item => item.ChatID == list[i].ChatID) != null)
                {
                    list.RemoveAt(i);
                    continue;
                }
                temp.Add(list[i]);
            }
        }

        private void RemoveUIDuplicates()
        {
            List<string> names = new List<string>();
            for (int i = 0; i < chatsLayoutPanel.Controls.Count; i++)
            {
                ChatItem chatItem = chatsLayoutPanel.Controls[i] as ChatItem;
                if (names.Contains(chatItem.ChatName))
                {
                    chatsLayoutPanel.Controls.RemoveAt(i);
                    i--;
                    continue;
                }
                names.Add(chatItem.ChatName);
            }
        }

        #endregion


        #region MyAdditionalMethods
        private void SwapElements<T>(List<T> list, T el)
        {
            int index = list.IndexOf(el);
            if (index == -1) return;
            list.RemoveAt(index);
            list.Insert(0, el);
        }
        #endregion
    }
}
