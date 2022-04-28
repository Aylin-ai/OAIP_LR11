using System;
using System.Security.Cryptography;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛР11
{
    public partial class Авторизация : Form
    {
        public Авторизация()
        {
            InitializeComponent();
        }

        private void buttonLogIn_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                User user1 = new User("", "");
                if (db.Users.Count() > 0)
                {
                    foreach (User user in db.Users)
                    {
                        if (textBoxLog.Text == user.Login &&
                            this.GetHashString(textBoxPass.Text) == user.Password)
                        {
                            user1 = new User(textBoxLog.Text, textBoxPass.Text);
                            MessageBox.Show("Вы вошли под учетной записью: " + user.Login);
                            ФормаПользователя userForm = new ФормаПользователя();
                            this.Hide();
                            userForm.Show();
                            break;
                        }
                    }
                    if (user1.Login == "" && user1.Password == "")
                        MessageBox.Show("Логин или пароль указан неверно!");
                }
            }
        }
        private string GetHashString(string s)
        {
            byte[] bytes = Encoding.Unicode.GetBytes(s);
            MD5CryptoServiceProvider CSP = new MD5CryptoServiceProvider();
            byte[] byteHash = CSP.ComputeHash(bytes);
            string hash = "";
            foreach (byte b in byteHash)
            {
                hash += string.Format("{0:x2}", b);
            }
            return hash;
        }

        private void label4_Click(object sender, EventArgs e)
        {
            Регистрация reg = new Регистрация();
            reg.Show();
            this.Hide();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            ВосстановлениеПароля recover = new ВосстановлениеПароля();
            recover.Show();
            this.Hide();
        }

        private void Авторизация_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBoxPass.UseSystemPasswordChar = true;
            }
            else
                textBoxPass.UseSystemPasswordChar = false;
        }
    }
}
