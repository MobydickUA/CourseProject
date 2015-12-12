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
    public partial class income_stat : Form
    {
        private MySqlConnection connection;
        private string connStr = "server=localhost; user = root ;database = household_DB; port = 3306;password =;";
        //private string connStr = "server=sql4.freemysqlhosting.net; user = sql499293 ;database = sql499293; port = 3306;password =dGxpPhJZAk;";

        public income_stat()
        {
            InitializeComponent();
            this.connection = new MySqlConnection(this.connStr);
            
            int year = 2016;
            for (int i = 0; i < 5; i++)
            {
                comboBox2.Items.Add(year - i);
                comboBox2.Text = (year - i).ToString();
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void user_stat_Click(object sender, EventArgs e)
        {
            int type = 0;
            if (income_rbtn.Checked == true)
                type = 1;
            else
                type = 0;
            this.Text = "Статистика - за користувачами";

            this.connection.Open();
            try
            {
                string Query = "SELECT owners.name as 'Користувач', sum(transactions.amount) as 'Сума' from transaction_types inner join transactions on transactions.type_id = transaction_types.id inner join owners on owners.id = transaction_types.owner_id where transactions.type = '" + type + "' group by owners.name";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(Query, this.connection);
                DataSet DS = new DataSet();
                dataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
        }

        private void type_stat_Click(object sender, EventArgs e)
        {
            this.Text = "Статистика - за типами";
            int type = 0;
            if (income_rbtn.Checked == true)
                type = 1;
            else
                type = 0;

            this.connection.Open();
            try
            {
                string Query = "SELECT transaction_types.name as 'Витрата', sum(transactions.amount) as 'Сума' from transaction_types inner join transactions on transactions.type_id = transaction_types.id inner join owners on owners.id = transaction_types.owner_id where transactions.type = '" + type + "' group by transaction_types.name";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(Query, this.connection);
                DataSet DS = new DataSet();
                dataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
        }

        private void date_stat_Click(object sender, EventArgs e)
        {
            this.Text = "Статистика - по інтервалу дат";
            DateTime rawDate1 = dateTimePicker1.Value.Date;
            DateTime rawDate2 = dateTimePicker2.Value.Date;
            string date1 = rawDate1.ToString("yyyy-MM-dd");
            string date2 = rawDate2.ToString("yyyy-MM-dd");

            

            int type = 0;
            if (income_rbtn.Checked == true)
                type = 1;
            else
                type = 0;
            if (rawDate1 < rawDate2)
            {
                this.connection.Open();
                try
                {
                    string Query = "SELECT transaction_types.name as 'Витрата', sum(transactions.amount) as 'Сума' from transaction_types inner join transactions on transactions.type_id = transaction_types.id inner join owners on owners.id = transaction_types.owner_id where transactions.type = '" + type + "'AND transactions.date BETWEEN '" + date1 + "' and '" + date2 + "' group by transaction_types.name";
                    MySqlDataAdapter dataAdapter = new MySqlDataAdapter(Query, this.connection);
                    DataSet DS = new DataSet();
                    dataAdapter.Fill(DS);
                    dataGridView1.DataSource = DS.Tables[0];
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.connection.Close();
            }
            else
                MessageBox.Show("Введіть корректний інтервал дат");
        }

        private void month_stat_btn_Click(object sender, EventArgs e)
        {
            this.Text = "Статистика - за місяцями";
            int type = 0;
            if (income_rbtn.Checked == true)
                type = 1;
            else
                type = 0;

            this.connection.Open();

            try
            {
                string Query = "select months.name as 'Місяць', sum(amount) as 'Сума' from transactions inner join months on months.id = MONTH(transactions.date) where type = " + type + " and  YEAR(`date`) = " + comboBox2.SelectedItem + " group by MONTH(`date`);";
                MySqlDataAdapter dataAdapter = new MySqlDataAdapter(Query, this.connection);
                DataSet DS = new DataSet();
                dataAdapter.Fill(DS);
                dataGridView1.DataSource = DS.Tables[0];
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            this.connection.Close();
        }

        private void income_stat_Load(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}
