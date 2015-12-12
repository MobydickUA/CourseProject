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
    public partial class addIncomeType : Form
    {
        private MySqlConnection connection;
        private string connStr = "server=localhost; user = root ;database = household_DB; port = 3306;password =;";
        //private string connStr = "server=sql4.freemysqlhosting.net; user = sql499293 ;database = sql499293; port = 3306;password =dGxpPhJZAk;";
        Dictionary<string, int> incomes = new Dictionary<string, int>();

        public addIncomeType()
        {
            InitializeComponent();
            this.connection = new MySqlConnection(this.connStr);
            this.connection.Open();
            MySqlCommand com = new MySqlCommand("Select name, ID FROM owners", this.connection);

            MySqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    string result = reader.GetString(0);
                    comboBox1.Items.Add(result);
                    comboBox1.Text = result;
                    incomes.Add(reader.GetString(0), reader.GetInt32(1));
                }
                catch { }

            }
            this.connection.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void add_income_type_Click(object sender, EventArgs e)
        {
            if (textBox1.Text != "")
            {
                int owner_id = this.incomes[comboBox1.SelectedItem.ToString()];
                this.connection.Open();
                try
                {
                    string Query = "insert into transaction_types (ID, type, name, owner_id) values(NULL , 1, '" + textBox1.Text + "', '" + owner_id + "');";
                    MySqlCommand MyCommand2 = new MySqlCommand(Query, this.connection);
                    MySqlDataReader MyReader2;

                    MyReader2 = MyCommand2.ExecuteReader();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.Close();
                MessageBox.Show("Запис додано");
            }
            else
                MessageBox.Show("Введіть назву прибутку");
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
