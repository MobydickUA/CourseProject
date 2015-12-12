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
    public partial class sell : Form
    {
        private MySqlConnection connection;
        private MySqlDataReader reader;
        //private string connStr = "server=sql4.freemysqlhosting.net; user = sql499293 ;database = sql499293; port = 3306;password =dGxpPhJZAk;";
        private string connStr = "server=localhost; user = root ;database = household_DB; port = 3306;password =;";
        Dictionary<string, int> names = new Dictionary<string, int>();
        Dictionary<string, int> prices = new Dictionary<string, int>();
        Dictionary<string, int> owners = new Dictionary<string, int>();

        public sell()
        {
            InitializeComponent();
            this.connection = new MySqlConnection(this.connStr);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            label2.Text = this.prices[comboBox1.SelectedItem.ToString()].ToString();
        }
        
        private void sell_Load(object sender, EventArgs e)
        {
            this.connection = new MySqlConnection(this.connStr);
            this.connection.Open();
            MySqlCommand com = new MySqlCommand("select inventory_types.type, inventory.ID, inventory.price from inventory inner join inventory_types on inventory.type_id = inventory_types.id;", this.connection);
            this.reader = com.ExecuteReader();
            while (this.reader.Read())
            {
                try
                {
                    string result = this.reader.GetString(0);
                    int name = this.reader.GetInt32(1);
                    int price = this.reader.GetInt32(2);
                    this.names.Add(result, name);
                    this.prices.Add(result, price);
                    comboBox1.Items.Add(result);
                    comboBox1.Text = result;
                }
                catch { }

            }
            this.connection.Close();
        }

        private void sell_button_Click(object sender, EventArgs e)
        {
            int type_id = this.names[comboBox1.SelectedItem.ToString()];
            int price = Int32.Parse(this.prices[comboBox1.SelectedItem.ToString()].ToString());
            string name = "Продаж '" + comboBox1.SelectedItem.ToString() + "'";
            this.connection.Open();
            try
            {
                string Q = "select count(*) from transaction_types where name = \"" + name + "\";";
                MySqlCommand Command = new MySqlCommand(Q, this.connection);
                int val = Int32.Parse(Command.ExecuteScalar().ToString());
                string Query = "";

                if (val == 0)
                {
                    string Query1 = "START TRANSACTION; \n";
                    string Query2 = "insert into transaction_types (ID, name, type, owner_id) values(NULL, \"" + name + "\", 1, " + 5 + "); \n";
                    string Query3 = "insert into transactions(ID, date, type, amount, type_id) values(NULL, NULL, 1, " + price + ", (SELECT ID FROM transaction_types Where name = \"" + name + "\")); \n";
                    string Query4 = "delete from inventory where type_id = (select id from inventory_types where type = \"" + comboBox1.SelectedItem.ToString() + "\"); \n";
                    string Query5 = "COMMIT; ";
                    Query = Query1 + Query2 + Query3 + Query4 + Query5;
                }
                else
                {
                    string Query1 = "START TRANSACTION; \n";
                    string Query2 = "insert into transactions(ID, date, type, amount, type_id) values(NULL, NULL, 1, " + price + ", (SELECT ID FROM transaction_types Where name = \"" + name + "\")); \n";
                    string Query3 = "delete from inventory where type_id = (select id from inventory_types where type = \"" + comboBox1.SelectedItem.ToString() + "\"); \n";
                    string Query4 = "COMMIT; ";
                    Query = Query1 + Query2 + Query3 + Query4;
                }

                MySqlCommand MyCommand = new MySqlCommand(Query, this.connection);
                MySqlDataReader MyReader;
                MyReader = MyCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.Close();
            MessageBox.Show("Запис додано");
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
