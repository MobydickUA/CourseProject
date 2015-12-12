namespace courseWork
{
    partial class main_form
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.statistic = new System.Windows.Forms.Button();
            this.add_income_transaction = new System.Windows.Forms.Button();
            this.add_expense_transaction = new System.Windows.Forms.Button();
            this.sell = new System.Windows.Forms.Button();
            this.buy = new System.Windows.Forms.Button();
            this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.incomes = new System.Windows.Forms.Button();
            this.expenses = new System.Windows.Forms.Button();
            this.inventory = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // statistic
            // 
            this.statistic.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.statistic.Location = new System.Drawing.Point(492, 93);
            this.statistic.Name = "statistic";
            this.statistic.Size = new System.Drawing.Size(75, 43);
            this.statistic.TabIndex = 4;
            this.statistic.Text = "Статистика";
            this.statistic.UseVisualStyleBackColor = true;
            this.statistic.Click += new System.EventHandler(this.statistic_Click);
            // 
            // add_income_transaction
            // 
            this.add_income_transaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add_income_transaction.Location = new System.Drawing.Point(492, 40);
            this.add_income_transaction.Name = "add_income_transaction";
            this.add_income_transaction.Size = new System.Drawing.Size(75, 43);
            this.add_income_transaction.TabIndex = 3;
            this.add_income_transaction.Text = "Додати запис";
            this.add_income_transaction.UseVisualStyleBackColor = true;
            this.add_income_transaction.Click += new System.EventHandler(this.add_income_transaction_Click);
            // 
            // add_expense_transaction
            // 
            this.add_expense_transaction.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.add_expense_transaction.Location = new System.Drawing.Point(492, 40);
            this.add_expense_transaction.Name = "add_expense_transaction";
            this.add_expense_transaction.Size = new System.Drawing.Size(75, 43);
            this.add_expense_transaction.TabIndex = 5;
            this.add_expense_transaction.Text = "Додати запис";
            this.add_expense_transaction.UseVisualStyleBackColor = true;
            this.add_expense_transaction.Click += new System.EventHandler(this.add_expense_transaction_Click);
            // 
            // sell
            // 
            this.sell.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.sell.Location = new System.Drawing.Point(492, 93);
            this.sell.Name = "sell";
            this.sell.Size = new System.Drawing.Size(75, 43);
            this.sell.TabIndex = 7;
            this.sell.Text = "Продати речі";
            this.sell.UseVisualStyleBackColor = true;
            this.sell.Click += new System.EventHandler(this.sell_Click);
            // 
            // buy
            // 
            this.buy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buy.Location = new System.Drawing.Point(492, 40);
            this.buy.Name = "buy";
            this.buy.Size = new System.Drawing.Size(75, 43);
            this.buy.TabIndex = 6;
            this.buy.Text = "Придбати речі";
            this.buy.UseVisualStyleBackColor = true;
            this.buy.Click += new System.EventHandler(this.buy_Click);
            // 
            // bindingSource1
            // 
            this.bindingSource1.CurrentChanged += new System.EventHandler(this.bindingSource1_CurrentChanged);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridView1.Location = new System.Drawing.Point(12, 40);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(474, 352);
            this.dataGridView1.StandardTab = true;
            this.dataGridView1.TabIndex = 6;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick_1);
            // 
            // incomes
            // 
            this.incomes.Location = new System.Drawing.Point(12, 11);
            this.incomes.Name = "incomes";
            this.incomes.Size = new System.Drawing.Size(75, 23);
            this.incomes.TabIndex = 8;
            this.incomes.Text = "Прибутки";
            this.incomes.UseVisualStyleBackColor = true;
            this.incomes.Click += new System.EventHandler(this.incomes_Click);
            // 
            // expenses
            // 
            this.expenses.Location = new System.Drawing.Point(93, 11);
            this.expenses.Name = "expenses";
            this.expenses.Size = new System.Drawing.Size(75, 23);
            this.expenses.TabIndex = 9;
            this.expenses.Text = "Витрати";
            this.expenses.UseVisualStyleBackColor = true;
            this.expenses.Click += new System.EventHandler(this.expenses_Click);
            // 
            // inventory
            // 
            this.inventory.Location = new System.Drawing.Point(174, 11);
            this.inventory.Name = "inventory";
            this.inventory.Size = new System.Drawing.Size(87, 23);
            this.inventory.TabIndex = 10;
            this.inventory.Text = "Список речей";
            this.inventory.UseVisualStyleBackColor = true;
            this.inventory.Click += new System.EventHandler(this.inventory_Click);
            // 
            // main_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(579, 404);
            this.Controls.Add(this.inventory);
            this.Controls.Add(this.expenses);
            this.Controls.Add(this.incomes);
            this.Controls.Add(this.sell);
            this.Controls.Add(this.buy);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.add_expense_transaction);
            this.Controls.Add(this.statistic);
            this.Controls.Add(this.add_income_transaction);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "main_form";
            this.Text = "Household";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingSource1;
        private System.Windows.Forms.Button add_income_transaction;
        private System.Windows.Forms.Button add_expense_transaction;
        private System.Windows.Forms.Button statistic;
        private System.Windows.Forms.Button buy;
        private System.Windows.Forms.Button sell;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button incomes;
        private System.Windows.Forms.Button expenses;
        private System.Windows.Forms.Button inventory;
    }
}

