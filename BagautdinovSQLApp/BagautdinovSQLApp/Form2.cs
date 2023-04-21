using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace BagautdinovSQLApp
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            textBox1.Text = "Введите имя";
            textBox2.Text = "Введите фамилию";
            textBox3.Text = "Введите логин";
            textBox4.Text = "Введите пароль";

        }



        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form1 login = new Form1();
            login.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите имя")
            {
                MessageBox.Show("Введите имя ",
                     "Ошибка",
                      MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (textBox2.Text == "Введите фамилию")
            {
                MessageBox.Show("Введите фамилию ",
                     "Ошибка",
                      MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (textBox3.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин",
                     "Ошибка",
                      MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (textBox4.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль ",
                     "Ошибка",
                      MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            if (checkUser())
            {
                return;
            }

            DB db = new DB();
            MySqlCommand command = new MySqlCommand("INSERT INTO `users` (`login`, `pass`, `name`, `surname`) VALUES (@login, @pass, @name, @surname);", db.get());
            command.Parameters.Add("@name", MySqlDbType.VarChar).Value = textBox1.Text;
            command.Parameters.Add("@surname", MySqlDbType.VarChar).Value = textBox2.Text;
            command.Parameters.Add("@login", MySqlDbType.VarChar).Value = textBox3.Text;
            command.Parameters.Add("@pass", MySqlDbType.VarChar).Value = textBox4.Text;
            db.open();
            if (command.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("Аккаунт создан!",
                    "Сообщение",
                      MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }

            else
            {
                MessageBox.Show("Аккаунт не создан!",
                    "Ошибка",
                      MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                db.close();
            }
        }
        public Boolean checkUser()
        {

            DB db = new DB();

            DataTable table = new DataTable();

            MySqlDataAdapter adapter = new MySqlDataAdapter();

            MySqlCommand command = new MySqlCommand("SELECT * FROM `users` WHERE `login` = @uL", db.get());

            command.Parameters.Add("@uL", MySqlDbType.VarChar).Value = textBox3.Text;

            adapter.SelectCommand = command;
            adapter.Fill(table);

            if (table.Rows.Count > 0)
            {
                MessageBox.Show("Такой логин уже есть, введите другой!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return true;
            }


            else

                return false;
        }


        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите имя")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Введите фамилию")
            {
                textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox3_Enter(object sender, EventArgs e)
        {
            if (textBox3.Text == "Введите логин")
            {
                textBox3.Text = "";
                textBox3.ForeColor = Color.Black;
            }
        }

        private void textBox4_Enter(object sender, EventArgs e)
        {
            if (textBox4.Text == "Введите пароль")
            {
                textBox4.Text = "";
                textBox4.ForeColor = Color.Black;
            }
        }


        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {


                textBox1.Text = "Введите имя";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {


                textBox2.Text = "Введите фамилию";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox3_Leave(object sender, EventArgs e)
        {
            if (textBox3.Text == "")
            {


                textBox3.Text = "Введите логин";
                textBox3.ForeColor = Color.Gray;
            }
        }

        private void textBox4_Leave(object sender, EventArgs e)
        {
            if (textBox4.Text == "")
            {


                textBox4.Text = "Введите пароль";
                textBox4.ForeColor = Color.Gray;
            }
        }



        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.PasswordChar = '\0';
            }
            else
            {
                textBox4.PasswordChar = '*';
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                
            }

                if (result == DialogResult.No)
                {

                }
            }

        private void button5_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотите выйти из приложения?", "Сообщение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                this.Close();
            }
            if (result == DialogResult.No)
            {

            }
        }
        Point lastPoint;
        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
    }

