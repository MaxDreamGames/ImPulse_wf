using System.Data;

namespace I_mPulse
{
    internal class Chat
    {
        private string username;
        private int userID;
        private int chatID;
        private string lastMsg;
        private string ipAddress;
        private bool isGroup;
        private ChatItem chatItem;
        private DataRow user;

        private DatabaseManager databaseManager = new DatabaseManager();


        public Chat(string username, int userID, int chatId, ChatItem chatItem, bool isGroup = false)
        {
            this.username = username;
            this.userID = userID;
            this.isGroup = isGroup;
            this.chatID = chatId;
            this.chatItem = chatItem;

            this.user = databaseManager.Request($"select * from Users where UserID = {this.userID.ToString()} and Username = '{this.username}';").Rows?[0];
            this.ipAddress = user[4].ToString();
        }

        public string GetIpAddress()
        {
            return ipAddress;
        }

        public int GetChatID() { return chatID; }

        public string GetLastMsg() { return lastMsg; }

        public ChatItem GetChatItem() { return chatItem; }

        public void SetLastMsg(string lastMsg) { this.lastMsg = lastMsg; }

        public static string GetInfoFromIP(string column, string ipAddress)
        {
            DatabaseManager databaseManager = new DatabaseManager();

            string username = databaseManager.Request($"select {column} from Users where IPAddress = '{ipAddress}';")?.Rows[0][0].ToString();
            return username;
        }
    }
}
