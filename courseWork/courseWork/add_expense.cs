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

namespace courseWork
{
    public partial class add_expense : Form
    {
        private MySqlConnection connection;
        private string connStr = "server=localhost; user = root ;database = household_DB; port = 3306;password =;";
        //private string connStr = "server=sql4.freemysqlhosting.net; user = sql499293 ;database = sql499293; port = 3306;password =dGxpPhJZAk;";
        Dictionary<string, int> expenses = new Dictionary<string, int>();

        public add_expense()
        {
            InitializeComponent();
            this.connection = new MySqlConnection(this.connStr);
            this.connection.Open();
            MySqlCommand com = new MySqlCommand("Select name, ID FROM transaction_types Where type = 0", this.connection);

            MySqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    string result = reader.GetString(0);
                    comboBox1.Items.Add(result);
                    comboBox1.Text = result;
                    expenses.Add(reader.GetString(0), reader.GetInt32(1));
                }
                catch { }

            }
            this.connection.Close();
        }

        private void add_expense_Load(object sender, EventArgs e)
        {

        }

        private bool Validate_fields()
        {
            try
            {
                int i = Int32.Parse(textBox1.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            return true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Validate_fields())
            {
                int expense_id = this.expenses[comboBox1.SelectedItem.ToString()];
                int amount = Int32.Parse(textBox1.Text);
                DateTime rawDate = dateTimePicker1.Value.Date;
                string date = rawDate.ToString("yyyy-MM-dd");

                this.connection.Open();
                try
                {
                    string Query = "insert into transactions (ID, date, type_id, type, amount) values(NULL ,'" + date + "','" + expense_id + "', 0, '" + amount + "');";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, this.connection);
                    MySqlDataReader MyReader2;
                    MyReader2 = MyCommand2.ExecuteReader();
                    MessageBox.Show("Запис додано");
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
                
            }
            else
                MessageBox.Show("Введіть правильну суму");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            add_expense_type add_expense_type_form = new add_expense_type();
            add_expense_type_form.Show();
        }
    }
}
