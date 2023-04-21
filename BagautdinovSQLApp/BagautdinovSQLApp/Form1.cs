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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BagautdinovSQLApp
{
    public partial class Form1 : Form
    {

        

        public Form1()
        {
            InitializeComponent();


            textBox1.Text = "Введите логин";
            textBox2.Text = "Введите пароль";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String loginUser= textBox1.Text;
            String passUser = textBox2.Text;

            DB db= new DB();
            DataTable table=new DataTable();
            MySqlDataAdapter adapter = new MySqlDataAdapter();
            MySqlCommand command= new MySqlCommand("SELECT * FROM `users` WHERE`login`=@ul AND `pass`= @up", db.get());
            command.Parameters.Add("@ul",MySqlDbType.VarChar).Value=loginUser;
            command.Parameters.Add("@up", MySqlDbType.VarChar).Value = passUser;
            adapter.SelectCommand= command;
            adapter.Fill(table);
            if (textBox1.Text == "Введите логин")
            {
                MessageBox.Show("Введите логин!",
                     "Предупреждение",
                      MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }
            if (textBox2.Text == "Введите пароль")
            {
                MessageBox.Show("Введите пароль!",
                     "Предупреждение",
                      MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }



            if (table.Rows.Count > 0)


                {

                    MessageBox.Show("Вы успешно вошли!",
                        "Сообщение",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Asterisk);
                    this.Hide();
                    Form3 login = new Form3();
                    login.Show();

                }

                else
                {
                    MessageBox.Show("Неверные данные!",
                        "Ошибка",
                          MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                }

            
               




        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Form2 f2 = new Form2();
            f2.ShowDialog();
        }

        private void textBox1_Enter(object sender, EventArgs e)
        {
            if (textBox1.Text == "Введите логин")
            {
                textBox1.Text = "";
                textBox1.ForeColor = Color.Black;
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if (textBox2.Text == "Введите пароль")
            {
                
                    textBox2.Text = "";
                textBox2.ForeColor = Color.Black;
            }
        }

        private void textBox2_Leave(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {


                textBox2.Text = "Введите пароль";
                textBox2.ForeColor = Color.Gray;
            }
        }

        private void textBox1_Leave(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {


                textBox1.Text = "Введите логин";
                textBox1.ForeColor = Color.Gray;
            }
        }

        private void выйтиToolStripMenuItem_Click(object sender, EventArgs e)
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar= '\0';
            }
            else
            {
                textBox2.PasswordChar= '*';
            }
        }


        Point lastPoint;
        private void panel2_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void panel2_MouseDown(object sender, MouseEventArgs e)
        {
           lastPoint= new Point(e.X,e.Y);
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            lastPoint = new Point(e.X, e.Y);
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Left += e.X - lastPoint.X;
                this.Top += e.Y - lastPoint.Y;
            }
        }
    }
    }

