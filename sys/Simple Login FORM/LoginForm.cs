using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using System.Reflection;

namespace Simple_Login_FORM
{
    public partial class LoginForm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = localhost; database=login_register_sys;port=3306; username = root; password= root");
        int i;
        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            RegisterForm fm = new RegisterForm();
            fm.Show();
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            i = 0;
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * from users where username='" + UsernameBox.Text + "' and pass ='" + PasswordBox.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            da.Fill(dt);
            i = Convert.ToInt32(dt.Rows.Count.ToString());

            if (i == 0)
            {
                MessageBox.Show("Pogresna sifra ili password");
            }
            else
            {
                this.Hide();
                Main fm = new Main();
                fm.Show();
            }
            con.Close();
        }
    }
}
