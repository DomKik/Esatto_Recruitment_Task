namespace Esatto_Recruitment_WinForms
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ProductsDataGridView = new DataGridView();
            PrevPageButton = new Button();
            NextPageButton = new Button();
            PageNumericUpDown = new NumericUpDown();
            PageLabel = new Label();
            label1 = new Label();
            PageSizeNumericUpDown = new NumericUpDown();
            RemoveButton = new Button();
            AddButton = new Button();
            CurrencyLabel = new Label();
            CurrencyComboBox = new ComboBox();
            FilterNameTextBox = new TextBox();
            SearchNameLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)ProductsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PageNumericUpDown).BeginInit();
            ((System.ComponentModel.ISupportInitialize)PageSizeNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // ProductsDataGridView
            // 
            ProductsDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            ProductsDataGridView.Location = new Point(67, 68);
            ProductsDataGridView.Name = "ProductsDataGridView";
            ProductsDataGridView.Size = new Size(556, 444);
            ProductsDataGridView.TabIndex = 0;
            // 
            // PrevPageButton
            // 
            PrevPageButton.Location = new Point(155, 545);
            PrevPageButton.Name = "PrevPageButton";
            PrevPageButton.Size = new Size(123, 23);
            PrevPageButton.TabIndex = 1;
            PrevPageButton.Text = "<";
            PrevPageButton.UseVisualStyleBackColor = true;
            PrevPageButton.Click += PrevPageButton_Click;
            // 
            // NextPageButton
            // 
            NextPageButton.Location = new Point(415, 545);
            NextPageButton.Name = "NextPageButton";
            NextPageButton.Size = new Size(123, 23);
            NextPageButton.TabIndex = 2;
            NextPageButton.Text = ">";
            NextPageButton.UseVisualStyleBackColor = true;
            NextPageButton.Click += NextPageButton_Click;
            // 
            // PageNumericUpDown
            // 
            PageNumericUpDown.Location = new Point(303, 545);
            PageNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PageNumericUpDown.Name = "PageNumericUpDown";
            PageNumericUpDown.Size = new Size(88, 23);
            PageNumericUpDown.TabIndex = 3;
            PageNumericUpDown.Value = new decimal(new int[] { 1, 0, 0, 0 });
            PageNumericUpDown.ValueChanged += PageNumericUpDown_ValueChanged;
            // 
            // PageLabel
            // 
            PageLabel.AutoSize = true;
            PageLabel.Location = new Point(303, 527);
            PageLabel.Name = "PageLabel";
            PageLabel.Size = new Size(36, 15);
            PageLabel.TabIndex = 4;
            PageLabel.Text = "Page:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(301, 580);
            label1.Name = "label1";
            label1.Size = new Size(59, 15);
            label1.TabIndex = 5;
            label1.Text = "Page Size:";
            // 
            // PageSizeNumericUpDown
            // 
            PageSizeNumericUpDown.Location = new Point(303, 598);
            PageSizeNumericUpDown.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            PageSizeNumericUpDown.Name = "PageSizeNumericUpDown";
            PageSizeNumericUpDown.Size = new Size(88, 23);
            PageSizeNumericUpDown.TabIndex = 6;
            PageSizeNumericUpDown.Value = new decimal(new int[] { 5, 0, 0, 0 });
            PageSizeNumericUpDown.ValueChanged += PageSizeNumericUpDown_ValueChanged;
            // 
            // RemoveButton
            // 
            RemoveButton.Font = new Font("Segoe UI", 10F);
            RemoveButton.Location = new Point(696, 294);
            RemoveButton.Name = "RemoveButton";
            RemoveButton.Size = new Size(111, 43);
            RemoveButton.TabIndex = 7;
            RemoveButton.Text = "Remove";
            RemoveButton.UseVisualStyleBackColor = true;
            RemoveButton.Click += RemoveButton_Click;
            // 
            // AddButton
            // 
            AddButton.Font = new Font("Segoe UI", 10F);
            AddButton.Location = new Point(696, 230);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(111, 41);
            AddButton.TabIndex = 8;
            AddButton.Text = "Add";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CurrencyLabel
            // 
            CurrencyLabel.AutoSize = true;
            CurrencyLabel.Font = new Font("Segoe UI", 11F);
            CurrencyLabel.Location = new Point(696, 68);
            CurrencyLabel.Name = "CurrencyLabel";
            CurrencyLabel.Size = new Size(69, 20);
            CurrencyLabel.TabIndex = 9;
            CurrencyLabel.Text = "Currency:";
            // 
            // CurrencyComboBox
            // 
            CurrencyComboBox.FormattingEnabled = true;
            CurrencyComboBox.Location = new Point(696, 110);
            CurrencyComboBox.Name = "CurrencyComboBox";
            CurrencyComboBox.Size = new Size(202, 23);
            CurrencyComboBox.TabIndex = 10;
            CurrencyComboBox.SelectedIndexChanged += CurrencyComboBox_SelectedIndexChanged;
            // 
            // FilterNameTextBox
            // 
            FilterNameTextBox.Location = new Point(167, 39);
            FilterNameTextBox.Name = "FilterNameTextBox";
            FilterNameTextBox.Size = new Size(142, 23);
            FilterNameTextBox.TabIndex = 11;
            FilterNameTextBox.TextChanged += FilterNameTextBox_TextChanged;
            // 
            // SearchNameLabel
            // 
            SearchNameLabel.AutoSize = true;
            SearchNameLabel.Location = new Point(167, 13);
            SearchNameLabel.Name = "SearchNameLabel";
            SearchNameLabel.Size = new Size(71, 15);
            SearchNameLabel.TabIndex = 12;
            SearchNameLabel.Text = "Filter Name:";
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(953, 633);
            Controls.Add(SearchNameLabel);
            Controls.Add(FilterNameTextBox);
            Controls.Add(CurrencyComboBox);
            Controls.Add(CurrencyLabel);
            Controls.Add(AddButton);
            Controls.Add(RemoveButton);
            Controls.Add(PageSizeNumericUpDown);
            Controls.Add(label1);
            Controls.Add(PageLabel);
            Controls.Add(PageNumericUpDown);
            Controls.Add(NextPageButton);
            Controls.Add(PrevPageButton);
            Controls.Add(ProductsDataGridView);
            Name = "MainForm";
            Text = "Products Viewer";
            ((System.ComponentModel.ISupportInitialize)ProductsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)PageNumericUpDown).EndInit();
            ((System.ComponentModel.ISupportInitialize)PageSizeNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView ProductsDataGridView;
        private Button PrevPageButton;
        private Button NextPageButton;
        private NumericUpDown PageNumericUpDown;
        private Label PageLabel;
        private Label label1;
        private NumericUpDown PageSizeNumericUpDown;
        private Button RemoveButton;
        private Button AddButton;
        private Label CurrencyLabel;
        private ComboBox CurrencyComboBox;
        private TextBox FilterNameTextBox;
        private Label SearchNameLabel;
    }
}
