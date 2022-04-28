using System;
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
    public partial class ФормаПользователя : Form
    {
        public ФормаПользователя()
        {
            InitializeComponent();
        }

        private void ФормаПользователя_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }
}
