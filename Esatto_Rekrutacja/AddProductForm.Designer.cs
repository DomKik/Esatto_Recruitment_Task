namespace Esatto_Recruitment_WinForms
{
    partial class AddProductForm
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
            NameLabel = new Label();
            PriceLabel = new Label();
            AddButton = new Button();
            CancelButton = new Button();
            NameTextBox = new TextBox();
            IsArchivedCheckBox = new CheckBox();
            PriceNumericUpDown = new NumericUpDown();
            CurrencyLabel = new Label();
            CurrencyComboBox = new ComboBox();
            ((System.ComponentModel.ISupportInitialize)PriceNumericUpDown).BeginInit();
            SuspendLayout();
            // 
            // NameLabel
            // 
            NameLabel.AutoSize = true;
            NameLabel.Location = new Point(57, 78);
            NameLabel.Name = "NameLabel";
            NameLabel.Size = new Size(42, 15);
            NameLabel.TabIndex = 0;
            NameLabel.Text = "Name:";
            // 
            // PriceLabel
            // 
            PriceLabel.AutoSize = true;
            PriceLabel.Location = new Point(198, 78);
            PriceLabel.Name = "PriceLabel";
            PriceLabel.Size = new Size(36, 15);
            PriceLabel.TabIndex = 1;
            PriceLabel.Text = "Price:";
            // 
            // AddButton
            // 
            AddButton.Location = new Point(82, 148);
            AddButton.Name = "AddButton";
            AddButton.Size = new Size(104, 25);
            AddButton.TabIndex = 3;
            AddButton.Text = "Add Product";
            AddButton.UseVisualStyleBackColor = true;
            AddButton.Click += AddButton_Click;
            // 
            // CancelButton
            // 
            CancelButton.Location = new Point(226, 148);
            CancelButton.Name = "CancelButton";
            CancelButton.Size = new Size(80, 25);
            CancelButton.TabIndex = 4;
            CancelButton.Text = "Cancel";
            CancelButton.UseVisualStyleBackColor = true;
            CancelButton.Click += CancelButton_Click;
            // 
            // NameTextBox
            // 
            NameTextBox.Location = new Point(30, 94);
            NameTextBox.Name = "NameTextBox";
            NameTextBox.Size = new Size(100, 23);
            NameTextBox.TabIndex = 5;
            // 
            // IsArchivedCheckBox
            // 
            IsArchivedCheckBox.AutoSize = true;
            IsArchivedCheckBox.Location = new Point(304, 97);
            IsArchivedCheckBox.Name = "IsArchivedCheckBox";
            IsArchivedCheckBox.Size = new Size(84, 19);
            IsArchivedCheckBox.TabIndex = 6;
            IsArchivedCheckBox.Text = "Is Archived";
            IsArchivedCheckBox.UseVisualStyleBackColor = true;
            // 
            // PriceNumericUpDown
            // 
            PriceNumericUpDown.DecimalPlaces = 2;
            PriceNumericUpDown.Location = new Point(163, 96);
            PriceNumericUpDown.Maximum = new decimal(new int[] { 9999999, 0, 0, 0 });
            PriceNumericUpDown.Name = "PriceNumericUpDown";
            PriceNumericUpDown.Size = new Size(106, 23);
            PriceNumericUpDown.TabIndex = 7;
            // 
            // CurrencyLabel
            // 
            CurrencyLabel.AutoSize = true;
            CurrencyLabel.Location = new Point(185, 18);
            CurrencyLabel.Name = "CurrencyLabel";
            CurrencyLabel.Size = new Size(58, 15);
            CurrencyLabel.TabIndex = 8;
            CurrencyLabel.Text = "Currency:";
            // 
            // CurrencyComboBox
            // 
            CurrencyComboBox.FormattingEnabled = true;
            CurrencyComboBox.Location = new Point(131, 36);
            CurrencyComboBox.Name = "CurrencyComboBox";
            CurrencyComboBox.Size = new Size(175, 23);
            CurrencyComboBox.TabIndex = 9;
            CurrencyComboBox.SelectedIndexChanged += CurrencyComboBox_SelectedIndexChanged;
            // 
            // AddProductForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(438, 184);
            Controls.Add(CurrencyComboBox);
            Controls.Add(CurrencyLabel);
            Controls.Add(PriceNumericUpDown);
            Controls.Add(IsArchivedCheckBox);
            Controls.Add(NameTextBox);
            Controls.Add(CancelButton);
            Controls.Add(AddButton);
            Controls.Add(PriceLabel);
            Controls.Add(NameLabel);
            Name = "AddProductForm";
            Text = "AddProductForm";
            ((System.ComponentModel.ISupportInitialize)PriceNumericUpDown).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label NameLabel;
        private Label PriceLabel;
        private Button AddButton;
        private Button CancelButton;
        private TextBox NameTextBox;
        private CheckBox IsArchivedCheckBox;
        private NumericUpDown PriceNumericUpDown;
        private Label CurrencyLabel;
        private ComboBox CurrencyComboBox;
    }
}