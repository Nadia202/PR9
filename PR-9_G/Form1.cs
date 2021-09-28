using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;
using System.Data.Linq.Mapping;

namespace PR_9_G
{
    public partial class Form1 : Form
    {
        static string conStr = @"Data Source=DESKTOP-12447FP\SQLEXPRESS;Initial Catalog=pro-41 GNE;Integrated Security=True"; 
        DataContext context = new DataContext(conStr);
        public Form1()
        {
            InitializeComponent();
            Table<User> users = context.GetTable<User>();
            dataGridView1.DataSource = users.ToList();
            Table<Order> orders = context.GetTable<Order>();
            dataGridView2.DataSource = orders.ToList();
            Table<Order_status> order_Staruses = context.GetTable<Order_status>();
            dataGridView3.DataSource = order_Staruses.ToList();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            User user = new User()
            {
                user_name = textBox1.Text,
                password = textBox2.Text,
                creater = Convert.ToDateTime(textBox3.Text),
                phone = Convert.ToInt64(textBox4.Text),
                email = textBox5.Text,
                first_name = textBox6.Text,
                last_name = textBox7.Text
            };
            context.GetTable<User>().InsertOnSubmit(user);
            context.SubmitChanges();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Order orders = new Order()
            {
                creater = Convert.ToDateTime(textBox13.Text),
                customer_id = Convert.ToInt32(textBox8.Text),
                point_id = Convert.ToInt32(textBox9.Text),
                sum = Convert.ToInt32(textBox10.Text),
                status_id = Convert.ToInt32(textBox11.Text),
                delivery_service_id = Convert.ToInt32(textBox12.Text),
            };
            context.GetTable<Order>().InsertOnSubmit(orders);
            context.SubmitChanges();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            User currentUser = context.GetTable<User>().FirstOrDefault(
                x => x.user_id == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            textBox1.Text = currentUser.user_name;
            textBox2.Text = currentUser.password;
            textBox3.Text = currentUser.creater.ToString();
            textBox4.Text = currentUser.phone.ToString();
            textBox5.Text = currentUser.email;
            textBox6.Text = currentUser.first_name;
            textBox7.Text = currentUser.last_name;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            User currentUser = context.GetTable<User>().FirstOrDefault(
               x => x.user_id == Convert.ToInt32(dataGridView1.CurrentRow.Cells[0].Value));
            currentUser.user_name = textBox1.Text;
            currentUser.password = textBox2.Text;
            currentUser.creater = Convert.ToDateTime(textBox3.Text);
            currentUser.phone = Convert.ToInt64(textBox4.Text);
            currentUser.email = textBox5.Text;
            currentUser.first_name = textBox6.Text;
            currentUser.last_name = textBox7.Text;
            context.SubmitChanges();
        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {
            if (textBox14.Text == "")
            {
                Table<User> users = context.GetTable<User>();
                dataGridView1.DataSource = users.ToList();
            }
            else
            {
                Table<User> users = context.GetTable<User>();
                string last_name = textBox14.Text;
                var selectUser = from user in users where user.last_name == last_name select user;
                dataGridView1.DataSource = selectUser.ToList();
            }
        }
    }
}
