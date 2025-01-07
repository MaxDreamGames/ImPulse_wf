using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Forms;
using Serilog;

namespace I_mPulse
{
    public partial class RegistrationDiologWindow : Form
    {
        public MainWindow mainWindow;
        public bool isExiting;



        Color closeBtnColor;
        bool isDraging = false;
        Point startPoint = new Point(0, 0);
        DatabaseManager databaseManager = new DatabaseManager();

        public RegistrationDiologWindow()
        {
            InitializeComponent();
        }
        private void RegistrationDiologWindow_Load(object sender, EventArgs e)
        {
            closeBtnColor = closeBtn.BackColor;
            windowName.Text = Text;
            bufferBtn.Focus();
            PrivateFontCollection fontCollection = new PrivateFontCollection();
            fontCollection.AddFontFile("Jura-VariableFont_wght.ttf");
            fontCollection.AddFontFile("Play-Regular.ttf");
            windowName.Font = new Font(fontCollection.Families[0], windowName.Font.Size, FontStyle.Bold);
            foreach (var controlItem in signInPanel.Controls.OfType<Label>())
            {
                controlItem.Font = new Font(fontCollection.Families[1], controlItem.Font.Size, FontStyle.Regular);

            }
            foreach (var controlItem in signUpPanel.Controls.OfType<Label>())
            {
                controlItem.Font = new Font(fontCollection.Families[1], controlItem.Font.Size, FontStyle.Regular);

            }
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
            Log.Information("Session has been ended.");
            Application.Exit();
            isExiting = true;
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

        private void signUpAlreadyIsSparkBtn_Click(object sender, EventArgs e)
        {
            signUpPanel.Hide();
            signInPanel.Show();
        }

        private async void createBtn_Click(object sender, EventArgs e)
        {
            if (!CheckPass()) return;

            string ip = await GetActiveIp();

            if (ip == null)
            {
                MessageBox.Show("Вы не подключены к сети!", "I'mPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Warning("User isn't in Net.");
                return;
            }
            if (databaseManager.Request($"select * from Users where Username = '{signUpLoginText.Text}' and PasswordHash = '{signUpPassText.Text}'").Rows.Count > 0)
            {
                MessageBox.Show("Такая Искра уже существует!", "I'mPulse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Log.Warning($"Access denied! User \"{signUpLoginText.Text}\" has already been created.");
                return;
            }
            Console.WriteLine(ip);
            databaseManager.Request($"INSERT INTO Users (Username, PasswordHash, Salt, IPAddress, LogUp) VALUES ('{signUpLoginText.Text}', '{signUpPassText.Text}', 'exampleSalt', '{ip}', '{DateTime.Now:yyyy-MM-dd HH:mm:ss}');");


            Log.Information($"User \"{signUpLoginText.Text}\" has been signed up on {ip}.");
            MessageBox.Show("Вы создали Искру! Активируйте Ее, чтобы начать общение!", "I'mPulse", MessageBoxButtons.OK, MessageBoxIcon.Information);

            signUpPanel.Hide();
            signInPanel.Show();
        }

        private void signInNotSparkBtn_Click(object sender, EventArgs e)
        {
            signInPanel.Hide();
            signUpPanel.Show();
        }

        private async void signInActivateBtn_Click(object sender, EventArgs e)
        {
            signInActivateBtn.Enabled = false;
            var user = databaseManager.Request($"select * from Users where Username = '{signInLoginText.Text}' and PasswordHash = '{signInPassText.Text}'");
            if (user.Rows.Count == 0)
            {
                MessageBox.Show("Такой Искры не существует!", "I'mPulse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Log.Warning($"Access denied! User \"{signInLoginText.Text}\" hasn't been created yet.");
                signInActivateBtn.Enabled = true;
                return;
            }
            string ip = await GetActiveIp();

            if (ip == null)
            {
                MessageBox.Show("Вы не подключены к сети!", "I'mPulse", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.Warning("User isn't in Net.");
                signInActivateBtn.Enabled = true;
                return;
            }
            databaseManager.Request($"update Users set IPAddress = '{ip}' where Username = '{signInLoginText.Text}';");
            mainWindow.currentUserData.Add("UserID", user.Rows[0][0].ToString());
            mainWindow.currentUserData.Add("Username", user.Rows[0][1].ToString());
            mainWindow.currentUserData.Add("IP", ip);
            mainWindow.TCPConnect();
            mainWindow.WindowState = FormWindowState.Normal;
            Close();
        }


        async Task<string> GetActiveIp()
        {
            string ip = null;
            using (HttpClient client = new HttpClient())
            {
                ip = await client.GetStringAsync("https://api.ipify.org");
            }
            return ip;
        }

        bool CheckPass()
        {
            if (signUpPassText.Text != signUpAccessPassText.Text)
            {
                MessageBox.Show("Пароли не совпадают!", "I'mPulse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            if (signUpPassText.Text.Length < 5 && signUpPassText.Text.Any(char.IsDigit))
            {
                MessageBox.Show("Пароль слишком слабый!", "I'mPulse", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}
