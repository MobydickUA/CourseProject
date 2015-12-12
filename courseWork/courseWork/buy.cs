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
    public partial class buy : Form
    {
        private MySqlConnection connection;
        private string connStr = "server=localhost; user = root ;database = household_DB; port = 3306;password =;";
        //private string connStr = "server=sql4.freemysqlhosting.net; user = sql499293 ;database = sql499293; port = 3306;password =dGxpPhJZAk;";
        Dictionary<string, int> names = new Dictionary<string, int>();
        Dictionary<string, int> users = new Dictionary<string, int>();

        public buy()
        {
            InitializeComponent();
            this.connection = new MySqlConnection(this.connStr);
            this.connection.Open();
            MySqlCommand com = new MySqlCommand("Select type, ID FROM inventory_types", this.connection);
            MySqlCommand com2 = new MySqlCommand("Select name, ID FROM owners", this.connection);

            MySqlDataReader reader;
            reader = com.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    string result = reader.GetString(0);
                    comboBox1.Items.Add(result);
                    comboBox1.Text = result;
                    names.Add(reader.GetString(0), reader.GetInt32(1));
                }
                catch { }

            }

            this.connection.Close();

            this.connection.Open();
            reader = com2.ExecuteReader();
            while (reader.Read())
            {
                try
                {
                    string result = reader.GetString(0);
                    comboBox2.Items.Add(result);
                    comboBox2.Text = result;
                    users.Add(reader.GetString(0), reader.GetInt32(1));
                }
                catch { }

            }

            this.connection.Close();
        }

        private void buy_Load(object sender, EventArgs e)
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

        private void buyButton_Click(object sender, EventArgs e)
        {
            if (Validate_fields())
            {
                int type_id = this.names[comboBox1.SelectedItem.ToString()];
                int owner_id = this.users[comboBox2.SelectedItem.ToString()];
                int price = Int32.Parse(textBox1.Text);
                string name = "Купівля '"+ comboBox1.SelectedItem.ToString() + "'";
                this.connection.Open();
                try
                {
                    string Q = "select count(*) from transaction_types where name = \"" + name + "\";";
                    MySqlCommand Command = new MySqlCommand(Q, this.connection);
                    int val = Int32.Parse(Command.ExecuteScalar().ToString());

                    if (val == 0)
                    {
                        string Query2 = "insert into transaction_types (ID, name, type, owner_id) values(NULL, \"" + name + "\", 0, " + owner_id + "); \n";
                        MySqlCommand MyCommand = new MySqlCommand(Query2, this.connection);
                        MySqlDataReader MyReader;
                        MyReader = MyCommand.ExecuteReader();
                        this.connection.Close();
                        this.connection.Open();
                    }
                    string Query1 = "START TRANSACTION; \n";
                    string Query3 = "insert into inventory (ID, type_id, date_of_buy, price) values(NULL ," + type_id + ", NULL, " + price + "); \n";
                    string Query4 = "insert into transactions(ID, date, type, amount, type_id) values(NULL, NULL, 0, " + price + ", (SELECT ID FROM transaction_types Where name = \"" + name + "\" AND owner_id = " + owner_id + ")); \n";
                    string Query5 = "COMMIT; ";
                    string Query = Query1 + Query3 + Query4 + Query5;
                   
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
                MessageBox.Show("Введіть правильну суму");
        }
    }
}
