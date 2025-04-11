using Esatto_Recruitment_WinForms.Models;
using Esatto_Recruitment_WinForms.Services;
using Esatto_Recruitment_WinForms.Interfaces;
using Esatto_Recruitment_WinForms.Utils;
using Esatto_Recruitment_WinForms;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace Esatto_Recruitment_WinForms
{
    public partial class MainForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyExchangeAPIService _currencyExchangeAPIService;

        private DataTable productsDataTable;

        public int pageSize { get { return (int)PageSizeNumericUpDown.Value; } }
        public int actualPage { get { return (int)PageNumericUpDown.Value; } }
        public string? actualCurrencyCode { get { return CurrencyComboBox.SelectedValue as string; } }
        public string nameFiltered { get { return FilterNameTextBox.Text; } }
        public FilterOptions filterOptions 
        { 
            get 
            {
                return new FilterOptions 
                {
                    searchedName = nameFiltered,
                    pageSize = pageSize,
                    pageNum = actualPage,
                };
            } 
        }

        public MainForm(IProductService productService, ICurrencyService currencyService, ICurrencyExchangeAPIService currencyExchangeAPIService)
        {
            _productService = productService;
            _currencyService = currencyService;
            _currencyExchangeAPIService = currencyExchangeAPIService;

            InitializeComponent();

            PageSizeNumericUpDown.Value = 5;

            ProductsDataGridView.ReadOnly = false;
            ProductsDataGridView.AllowUserToAddRows = false;
            ProductsDataGridView.CellEndEdit += dataGridView1_CellEndEdit;

            InitializeDataGridViewColumns();
            LoadProducts();

            AdjustDataGridViewWidth();

            this.Load += MainForm_Load;
        }

        private async void MainForm_Load(object? sender, EventArgs e)
        {
            await UpdateCurrencies();

            CurrencyComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            CurrencyComboBox.AutoCompleteSource = AutoCompleteSource.ListItems;

            var currenciesList = _currencyService.GetAllCurrencies();

            AutoCompleteStringCollection customSource = new AutoCompleteStringCollection();
            foreach (var currency in currenciesList)
            {
                customSource.Add($"({currency.Code}) {currency.Name}");
            }
            CurrencyComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;
            CurrencyComboBox.AutoCompleteCustomSource = customSource;
            CurrencyComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            CurrencyComboBox.DisplayMember = "FormattedDisplay";
            CurrencyComboBox.ValueMember = "Code";
            CurrencyComboBox.DataSource = currenciesList;

            CurrencyComboBox.SelectedValue = "USD";
        }

        private async Task UpdateCurrencies()
        {
            int currenciesNum = _currencyService.CountCurrencies();
            if (currenciesNum < 2)
            {
                await _currencyService.UpdateCurrencies(await _currencyExchangeAPIService.GetAllCurrenciesInfo());
            }
        }

        private void InitializeDataGridViewColumns()
        {
            ProductsDataGridView.AutoGenerateColumns = false;

            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Id", HeaderText = "Id", DataPropertyName = "Id", ReadOnly = true });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Name", HeaderText = "Name", DataPropertyName = "Name" });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "Price", HeaderText = "Price", DataPropertyName = "Price" });
            ProductsDataGridView.Columns.Add(new DataGridViewTextBoxColumn { Name = "CreationDate", HeaderText = "Creation Date", DataPropertyName = "CreationDate", ReadOnly = true });
            ProductsDataGridView.Columns.Add(new DataGridViewCheckBoxColumn { Name = "Archived", HeaderText = "Archived", DataPropertyName = "IsArchived" });

            foreach (DataGridViewColumn column in ProductsDataGridView.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.Automatic;
            }
        }

        private void LoadProducts()
        {
            IEnumerable<Product> products = _productService.ListPaged(filterOptions);

            productsDataTable = DataTableConverter.ConvertToDataTable(products);
            productsDataTable.Columns.Add("originalPrice", typeof(decimal));

            foreach (DataRow row in productsDataTable.Rows)
            {
                row["originalPrice"] = row["Price"];
            }

            UpdatePrices();

            ProductsDataGridView.DataSource = productsDataTable;
        }

        private void AdjustDataGridViewWidth()
        {
            int totalColumnWidth = 0;
            foreach (DataGridViewColumn column in ProductsDataGridView.Columns)
            {
                if (column.Visible) 
                { 
                    totalColumnWidth += column.Width;
                }
            }
            ProductsDataGridView.Width = totalColumnWidth + ProductsDataGridView.RowHeadersWidth + 2;
        }

        private void NextPageButton_Click(object sender, EventArgs e)
        {
            PageNumericUpDown.Value += 1;
            LoadProducts();
        }

        private void PrevPageButton_Click(object sender, EventArgs e)
        {
            PageNumericUpDown.Value = Math.Max(actualPage - 1, 1);
            LoadProducts();
        }

        private void dataGridView1_CellEndEdit(object? sender, DataGridViewCellEventArgs e)
        {
            if (ProductsDataGridView.Rows[e.RowIndex].IsNewRow)
            {
                return;
            }

            if (ProductsDataGridView.Rows[e.RowIndex].Cells["Id"].Value == null || !int.TryParse(ProductsDataGridView.Rows[e.RowIndex].Cells["Id"].Value.ToString(), out int productId))
            {
                MessageBox.Show("Could not read the ID of the edited product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProductsDataGridView.CancelEdit();
                return;
            }

            try
            {
                string? name = ProductsDataGridView.Rows[e.RowIndex].Cells["Name"].Value?.ToString();
                name = name == null ? string.Empty : name;
                decimal price = Convert.ToDecimal(ProductsDataGridView.Rows[e.RowIndex].Cells["Price"].Value);
                bool isArchived = Convert.ToBoolean(ProductsDataGridView.Rows[e.RowIndex].Cells["Archived"].Value);

                var existingProduct = _productService.GetProductById(productId);

                if (existingProduct == null)
                {
                    MessageBox.Show($"Product with ID: {productId} not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    ProductsDataGridView.CancelEdit();
                    return;
                }

                existingProduct.Name = name;
                existingProduct.Price = price;
                existingProduct.IsArchived = isArchived;

                _productService.Update(existingProduct);
            }
            catch (FormatException)
            {
                MessageBox.Show("Invalid data format.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                ProductsDataGridView.CancelEdit();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error editing product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void PageNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void PageSizeNumericUpDown_ValueChanged(object sender, EventArgs e)
        {
            LoadProducts();
        }

        private void RemoveButton_Click(object sender, EventArgs e)
        {
            if (ProductsDataGridView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a product to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            DataGridViewRow selectedRow = ProductsDataGridView.SelectedRows[0];

            if (selectedRow.IsNewRow)
            {
                MessageBox.Show("Please select an existing product to remove.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (selectedRow.Cells["Id"].Value == null || !int.TryParse(selectedRow.Cells["Id"].Value.ToString(), out int productId))
            {
                MessageBox.Show("Could not read the ID of the selected product.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (MessageBox.Show($"Are you sure you want to remove the product with ID: {productId}?", "Confirm Removal", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            try
            {
                _productService.Remove(productId);

                LoadProducts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error removing product: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            new AddProductForm(_productService, _currencyService, _currencyExchangeAPIService).ShowDialog();
            LoadProducts();
        }

        private void CurrencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdatePrices();
        }

        private async void UpdatePrices()
        {
            if (CurrencyComboBox.SelectedItem != null)
            {
                try
                {
                    decimal exchangeRate = await _currencyExchangeAPIService.GetCurrentExchangeRate(actualCurrencyCode);

                    if (exchangeRate > 0)
                    {
                        UpdateDisplayedPrices(exchangeRate);
                    }
                    else
                    {
                        MessageBox.Show("Unable to fetch exchange data.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error during updating prices: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void UpdateDisplayedPrices(decimal exchangeRate)
        {

            foreach (DataRow row in productsDataTable.Rows)
            {
                if (row["OriginalPrice"] != null && decimal.TryParse(row["OriginalPrice"].ToString(), out decimal originalPrice))
                {
                    row["Price"] = Math.Round(originalPrice / exchangeRate, 2);
                }
            }
            productsDataTable.AcceptChanges();

            ProductsDataGridView.DataSource = null;
            ProductsDataGridView.DataSource = productsDataTable;
        }

        private void FilterNameTextBox_TextChanged(object sender, EventArgs e)
        {
            PageNumericUpDown.Value = 1;
            LoadProducts();
        }
    }
}
