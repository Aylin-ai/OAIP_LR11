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
    public partial class Регистрация : Form
    {
        public Регистрация()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (UserContext db = new UserContext())
            {
                User user = new User(textBoxLog.Text,
                this.GetHashString(textBoxPass.Text),
                textBoxEmail.Text, "User");
                if (db.Users.Count() > 0)
                {
                    foreach (User user1 in db.Users)
                    {
                        if (user.Login != user1.Login || user.Email != user1.Email)
                        {
                            db.Users.Add(user);
                            MessageBox.Show("Аккаунт " + textBoxLog.Text + " успешно добавлен");
                            textBoxPass.Clear();
                            textBoxLog.Clear();
                            textBoxEmail.Clear();

                            Авторизация auto = new Авторизация();
                            this.Hide();
                            auto.Show();
                        }
                        else
                        {
                            MessageBox.Show("Пользователь с таким логином или email уже существует");
                            textBoxEmail.Clear();
                            textBoxLog.Clear();
                            continue;
                        }
                    }
                }
                else
                {
                    db.Users.Add(user);
                    db.SaveChanges();
                    MessageBox.Show("Аккаунт " + textBoxLog.Text + " успешно добавлен");
                    textBoxPass.Clear();
                    textBoxLog.Clear();
                    textBoxEmail.Clear();

                    Авторизация auto = new Авторизация();
                    this.Hide();
                    auto.Show();
                }
                db.SaveChanges();
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

        private void Регистрация_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
