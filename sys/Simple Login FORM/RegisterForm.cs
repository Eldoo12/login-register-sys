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

namespace Simple_Login_FORM
{
    public partial class RegisterForm : Form
    {
        MySqlConnection con = new MySqlConnection("datasource = localhost; database=login_register_sys;port=3306; username = root; password= root");
        public RegisterForm()
        {
            InitializeComponent();
        }

        private void ReturnButton_Click(object sender, EventArgs e)
        {
            this.Hide();
            LoginForm fm = new LoginForm();
            fm.Show();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            con.Open();
            MySqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "INSERT INTO users (email,username, pass) VALUES ('" + EmailBox.Text + "', '" + PasswordBox.Text + "','" + UsernameBox.Text + "');";
            DataTable de = new DataTable();
            MySqlDataAdapter dp = new MySqlDataAdapter(cmd);
            dp.Fill(de);
            con.Close();
            MessageBox.Show("Uspjesno ste registrovani");
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}


