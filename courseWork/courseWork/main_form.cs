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
    public partial class main_form : Form
    {
        private MySqlConnection connection;
        private string connStr = "server=localhost; user = root ;database = household_DB; port = 3306;password =;";
        //private string connStr = "server=sql4.freemysqlhosting.net; user = sql499293 ;database = sql499293; port = 3306;password =dGxpPhJZAk;";

        public main_form()
        {
            InitializeComponent();
            this.Text = "Household - прибутки";
            this.connection = new MySqlConnection(this.connStr);
        }
        
        

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void bindingSource1_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            buy.Visible = false;
            sell.Visible = false;
            add_expense_transaction.Visible = false;
            add_income_transaction.Visible = true;
            statistic.Visible = true;

            MySqlDataAdapter mySqlDataAdapter = new MySqlDataAdapter();

            /*string serverName = "localhost";
            string userName = "root";
            string dbName = "household_DB";
            string port = "3306";
            string password = "";
            string connStr = "server=" + serverName +
                ";user=" + userName +
                ";database=" + dbName +
                ";port=" + port +
                ";password=" + password + ";";
             * */
            this.connection = new MySqlConnection(this.connStr);

            

            try
            {
                connection.Open();
                string sql = "SELECT transaction_types.name as 'Опис', owners.name as 'Користувач', transactions.date as 'Дата', transactions.amount as 'Сума' from transaction_types inner join transactions on transactions.type_id = transaction_types.id inner join owners on owners.id = transaction_types.owner_id where transactions.type = 1  order by transactions.date";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, this.connection);
                DataSet DS = new DataSet();
                dataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void add_income_transaction_Click(object sender, EventArgs e)
        {
            add add_form = new add();
            add_form.Show();
            
        }


        private void add_expense_transaction_Click(object sender, EventArgs e)
        {
            add_expense add_expense_form = new add_expense();
            add_expense_form.Show();
        }

        private void statistic_Click(object sender, EventArgs e)
        {
            income_stat Statistic_form = new income_stat();
            Statistic_form.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void buy_Click(object sender, EventArgs e)
        {
            buy buy_form = new buy();
            buy_form.Show();
        }

        private void sell_Click(object sender, EventArgs e)
        {
            sell sell_form = new sell();
            sell_form.Show();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void incomes_Click(object sender, EventArgs e)
        {
            buy.Visible = false;
            sell.Visible = false;
            add_expense_transaction.Visible = false;
            add_income_transaction.Visible = true;
            statistic.Visible = true;
            this.Text = "Household - прибутки";
            
            try
            {
                string sql = "SELECT transaction_types.name as 'Опис', owners.name as 'Користувач', transactions.date as 'Дата', transactions.amount as 'Сума' from transaction_types inner join transactions on transactions.type_id = transaction_types.id inner join owners on owners.id = transaction_types.owner_id where transactions.type = 1 order by transactions.date";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, this.connection);
                DataSet DS = new DataSet();
                dataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        private void expenses_Click(object sender, EventArgs e)
        {
            buy.Visible = false;
            sell.Visible = false;
            add_expense_transaction.Visible = true;
            add_income_transaction.Visible = false;
            statistic.Visible = true;
            this.Text = "Household - витрати";
            try
            {
                string sql = "SELECT transaction_types.name as 'Опис', owners.name as 'Користувач', transactions.date as 'Дата', transactions.amount as 'Сума' from transaction_types inner join transactions on transactions.type_id = transaction_types.id inner join owners on owners.id = transaction_types.owner_id where transactions.type = 0 order by transactions.date";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, this.connection);
                DataSet DS = new DataSet();
                dataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        private void inventory_Click(object sender, EventArgs e)
        {
            buy.Visible = true;
            sell.Visible = true;
            add_expense_transaction.Visible = false;
            add_income_transaction.Visible = false;
            statistic.Visible = false;
            this.Text = "Household - список речей";

            try
            {
                string sql = "SELECT inventory_types.type as 'Опис', inventory.date_of_buy as 'Дата покупки', inventory.price as 'Ціна' FROM inventory inner join inventory_types on inventory_types.id = inventory.type_id  order by inventory.date_of_buy";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, this.connection);
                DataSet DS = new DataSet();
                dataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Cannot connect to server. Contact administrator");
                        break;
                    case 1045:
                        MessageBox.Show("Invalid username/password, please try again");
                        break;
                    default:
                        MessageBox.Show(ex.Message);
                        break;
                }
            }
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}