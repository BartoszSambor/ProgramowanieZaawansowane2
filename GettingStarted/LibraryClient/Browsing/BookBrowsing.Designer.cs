namespace LibraryClient
{
    partial class BookBrowsing
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.authorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Id = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.currencyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pagesDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.priceDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.titleDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Borrowed = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboBoxAuthorFilter = new System.Windows.Forms.ComboBox();
            this.buttonClearFilters = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.comboBoxTypeFilter = new System.Windows.Forms.ComboBox();
            this.comboBoxCurrencyFilter = new System.Windows.Forms.ComboBox();
            this.comboBoxTitleFilter = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBoxAuthor = new System.Windows.Forms.CheckBox();
            this.checkBoxType = new System.Windows.Forms.CheckBox();
            this.checkBoxCurrency = new System.Windows.Forms.CheckBox();
            this.checkBoxTitle = new System.Windows.Forms.CheckBox();
            this.numericUpDownPriceDown = new System.Windows.Forms.NumericUpDown();
            this.label5 = new System.Windows.Forms.Label();
            this.numericUpDownPriceUp = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownPagesUp = new System.Windows.Forms.NumericUpDown();
            this.label6 = new System.Windows.Forms.Label();
            this.numericUpDownPagesDown = new System.Windows.Forms.NumericUpDown();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonBorrow = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriceDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriceUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPagesUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPagesDown)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.authorDataGridViewTextBoxColumn,
            this.Id,
            this.currencyDataGridViewTextBoxColumn,
            this.pagesDataGridViewTextBoxColumn,
            this.priceDataGridViewTextBoxColumn,
            this.titleDataGridViewTextBoxColumn,
            this.typeDataGridViewTextBoxColumn,
            this.Borrowed});
            this.dataGridView1.DataSource = this.bookBindingSource;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(935, 403);
            this.dataGridView1.TabIndex = 0;
            // 
            // authorDataGridViewTextBoxColumn
            // 
            this.authorDataGridViewTextBoxColumn.DataPropertyName = "Author";
            this.authorDataGridViewTextBoxColumn.HeaderText = "Author";
            this.authorDataGridViewTextBoxColumn.Name = "authorDataGridViewTextBoxColumn";
            this.authorDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Id
            // 
            this.Id.DataPropertyName = "Id";
            this.Id.HeaderText = "Id";
            this.Id.Name = "Id";
            this.Id.ReadOnly = true;
            // 
            // currencyDataGridViewTextBoxColumn
            // 
            this.currencyDataGridViewTextBoxColumn.DataPropertyName = "Currency";
            this.currencyDataGridViewTextBoxColumn.HeaderText = "Currency";
            this.currencyDataGridViewTextBoxColumn.Name = "currencyDataGridViewTextBoxColumn";
            this.currencyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // pagesDataGridViewTextBoxColumn
            // 
            this.pagesDataGridViewTextBoxColumn.DataPropertyName = "Pages";
            this.pagesDataGridViewTextBoxColumn.HeaderText = "Pages";
            this.pagesDataGridViewTextBoxColumn.Name = "pagesDataGridViewTextBoxColumn";
            this.pagesDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // priceDataGridViewTextBoxColumn
            // 
            this.priceDataGridViewTextBoxColumn.DataPropertyName = "Price";
            this.priceDataGridViewTextBoxColumn.HeaderText = "Price";
            this.priceDataGridViewTextBoxColumn.Name = "priceDataGridViewTextBoxColumn";
            this.priceDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // titleDataGridViewTextBoxColumn
            // 
            this.titleDataGridViewTextBoxColumn.DataPropertyName = "Title";
            this.titleDataGridViewTextBoxColumn.HeaderText = "Title";
            this.titleDataGridViewTextBoxColumn.Name = "titleDataGridViewTextBoxColumn";
            this.titleDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeDataGridViewTextBoxColumn
            // 
            this.typeDataGridViewTextBoxColumn.DataPropertyName = "Type";
            this.typeDataGridViewTextBoxColumn.HeaderText = "Type";
            this.typeDataGridViewTextBoxColumn.Name = "typeDataGridViewTextBoxColumn";
            this.typeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // Borrowed
            // 
            this.Borrowed.DataPropertyName = "Borrowed";
            this.Borrowed.HeaderText = "Borrowed";
            this.Borrowed.Name = "Borrowed";
            this.Borrowed.ReadOnly = true;
            // 
            // bookBindingSource
            // 
            this.bookBindingSource.DataSource = typeof(LibraryClient.ServiceReference1.Book);
            // 
            // comboBoxAuthorFilter
            // 
            this.comboBoxAuthorFilter.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBoxAuthorFilter.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxAuthorFilter.FormattingEnabled = true;
            this.comboBoxAuthorFilter.Location = new System.Drawing.Point(12, 439);
            this.comboBoxAuthorFilter.Name = "comboBoxAuthorFilter";
            this.comboBoxAuthorFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxAuthorFilter.TabIndex = 1;
            // 
            // buttonClearFilters
            // 
            this.buttonClearFilters.Location = new System.Drawing.Point(611, 437);
            this.buttonClearFilters.Name = "buttonClearFilters";
            this.buttonClearFilters.Size = new System.Drawing.Size(75, 23);
            this.buttonClearFilters.TabIndex = 2;
            this.buttonClearFilters.Text = "Clear filters";
            this.buttonClearFilters.UseVisualStyleBackColor = true;
            this.buttonClearFilters.Click += new System.EventHandler(this.buttonClearFilters_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(530, 437);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 3;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // comboBoxTypeFilter
            // 
            this.comboBoxTypeFilter.FormattingEnabled = true;
            this.comboBoxTypeFilter.Location = new System.Drawing.Point(139, 438);
            this.comboBoxTypeFilter.Name = "comboBoxTypeFilter";
            this.comboBoxTypeFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTypeFilter.TabIndex = 4;
            // 
            // comboBoxCurrencyFilter
            // 
            this.comboBoxCurrencyFilter.FormattingEnabled = true;
            this.comboBoxCurrencyFilter.Location = new System.Drawing.Point(266, 439);
            this.comboBoxCurrencyFilter.Name = "comboBoxCurrencyFilter";
            this.comboBoxCurrencyFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxCurrencyFilter.TabIndex = 5;
            // 
            // comboBoxTitleFilter
            // 
            this.comboBoxTitleFilter.FormattingEnabled = true;
            this.comboBoxTitleFilter.Location = new System.Drawing.Point(393, 439);
            this.comboBoxTitleFilter.Name = "comboBoxTitleFilter";
            this.comboBoxTitleFilter.Size = new System.Drawing.Size(121, 21);
            this.comboBoxTitleFilter.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 423);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "Author";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(175, 423);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(303, 423);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "Currency";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(429, 423);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(27, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Title";
            // 
            // checkBoxAuthor
            // 
            this.checkBoxAuthor.AutoSize = true;
            this.checkBoxAuthor.Location = new System.Drawing.Point(12, 466);
            this.checkBoxAuthor.Name = "checkBoxAuthor";
            this.checkBoxAuthor.Size = new System.Drawing.Size(92, 17);
            this.checkBoxAuthor.TabIndex = 11;
            this.checkBoxAuthor.Text = "Include empty";
            this.checkBoxAuthor.UseVisualStyleBackColor = true;
            // 
            // checkBoxType
            // 
            this.checkBoxType.AutoSize = true;
            this.checkBoxType.Location = new System.Drawing.Point(139, 465);
            this.checkBoxType.Name = "checkBoxType";
            this.checkBoxType.Size = new System.Drawing.Size(92, 17);
            this.checkBoxType.TabIndex = 12;
            this.checkBoxType.Text = "Include empty";
            this.checkBoxType.UseVisualStyleBackColor = true;
            // 
            // checkBoxCurrency
            // 
            this.checkBoxCurrency.AutoSize = true;
            this.checkBoxCurrency.Location = new System.Drawing.Point(266, 465);
            this.checkBoxCurrency.Name = "checkBoxCurrency";
            this.checkBoxCurrency.Size = new System.Drawing.Size(92, 17);
            this.checkBoxCurrency.TabIndex = 13;
            this.checkBoxCurrency.Text = "Include empty";
            this.checkBoxCurrency.UseVisualStyleBackColor = true;
            // 
            // checkBoxTitle
            // 
            this.checkBoxTitle.AutoSize = true;
            this.checkBoxTitle.Location = new System.Drawing.Point(393, 465);
            this.checkBoxTitle.Name = "checkBoxTitle";
            this.checkBoxTitle.Size = new System.Drawing.Size(92, 17);
            this.checkBoxTitle.TabIndex = 14;
            this.checkBoxTitle.Text = "Include empty";
            this.checkBoxTitle.UseVisualStyleBackColor = true;
            // 
            // numericUpDownPriceDown
            // 
            this.numericUpDownPriceDown.DecimalPlaces = 2;
            this.numericUpDownPriceDown.Location = new System.Drawing.Point(38, 522);
            this.numericUpDownPriceDown.Name = "numericUpDownPriceDown";
            this.numericUpDownPriceDown.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPriceDown.TabIndex = 15;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(103, 506);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Price ( from - to )";
            // 
            // numericUpDownPriceUp
            // 
            this.numericUpDownPriceUp.DecimalPlaces = 2;
            this.numericUpDownPriceUp.Location = new System.Drawing.Point(164, 522);
            this.numericUpDownPriceUp.Name = "numericUpDownPriceUp";
            this.numericUpDownPriceUp.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPriceUp.TabIndex = 17;
            // 
            // numericUpDownPagesUp
            // 
            this.numericUpDownPagesUp.Location = new System.Drawing.Point(451, 522);
            this.numericUpDownPagesUp.Name = "numericUpDownPagesUp";
            this.numericUpDownPagesUp.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPagesUp.TabIndex = 20;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(390, 506);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 13);
            this.label6.TabIndex = 19;
            this.label6.Text = "Pages ( from - to )";
            // 
            // numericUpDownPagesDown
            // 
            this.numericUpDownPagesDown.Location = new System.Drawing.Point(325, 522);
            this.numericUpDownPagesDown.Name = "numericUpDownPagesDown";
            this.numericUpDownPagesDown.Size = new System.Drawing.Size(120, 20);
            this.numericUpDownPagesDown.TabIndex = 18;
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(583, 517);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(103, 23);
            this.buttonSave.TabIndex = 21;
            this.buttonSave.Text = "Save Changes";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // buttonBorrow
            // 
            this.buttonBorrow.Location = new System.Drawing.Point(583, 488);
            this.buttonBorrow.Name = "buttonBorrow";
            this.buttonBorrow.Size = new System.Drawing.Size(75, 23);
            this.buttonBorrow.TabIndex = 22;
            this.buttonBorrow.Text = "Borrow";
            this.buttonBorrow.UseVisualStyleBackColor = true;
            this.buttonBorrow.Click += new System.EventHandler(this.buttonBorrow_Click);
            // 
            // buttonRemove
            // 
            this.buttonRemove.Location = new System.Drawing.Point(692, 519);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(75, 23);
            this.buttonRemove.TabIndex = 23;
            this.buttonRemove.Text = "Delete";
            this.buttonRemove.UseVisualStyleBackColor = true;
            this.buttonRemove.Click += new System.EventHandler(this.buttonRemove_Click);
            // 
            // BookBrowsing
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(949, 552);
            this.Controls.Add(this.buttonRemove);
            this.Controls.Add(this.buttonBorrow);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.numericUpDownPagesUp);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.numericUpDownPagesDown);
            this.Controls.Add(this.numericUpDownPriceUp);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.numericUpDownPriceDown);
            this.Controls.Add(this.checkBoxTitle);
            this.Controls.Add(this.checkBoxCurrency);
            this.Controls.Add(this.checkBoxType);
            this.Controls.Add(this.checkBoxAuthor);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTitleFilter);
            this.Controls.Add(this.comboBoxCurrencyFilter);
            this.Controls.Add(this.comboBoxTypeFilter);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.buttonClearFilters);
            this.Controls.Add(this.comboBoxAuthorFilter);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "BookBrowsing";
            this.Text = "BookBrowsing";
            this.Load += new System.EventHandler(this.BookBrowsing_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriceDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPriceUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPagesUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownPagesDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookPriceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn bookTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn boughtCurrencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagesCountDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bookBindingSource;
        private System.Windows.Forms.ComboBox comboBoxAuthorFilter;
        private System.Windows.Forms.Button buttonClearFilters;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.ComboBox comboBoxTypeFilter;
        private System.Windows.Forms.ComboBox comboBoxCurrencyFilter;
        private System.Windows.Forms.ComboBox comboBoxTitleFilter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox checkBoxAuthor;
        private System.Windows.Forms.CheckBox checkBoxType;
        private System.Windows.Forms.CheckBox checkBoxCurrency;
        private System.Windows.Forms.CheckBox checkBoxTitle;
        private System.Windows.Forms.NumericUpDown numericUpDownPriceDown;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.NumericUpDown numericUpDownPriceUp;
        private System.Windows.Forms.NumericUpDown numericUpDownPagesUp;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numericUpDownPagesDown;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonBorrow;
        private System.Windows.Forms.DataGridViewTextBoxColumn authorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Id;
        private System.Windows.Forms.DataGridViewTextBoxColumn currencyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn pagesDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn priceDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn titleDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn Borrowed;
        private System.Windows.Forms.Button buttonRemove;
    }
}