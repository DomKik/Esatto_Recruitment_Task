using Esatto_Recruitment_WinForms.Interfaces;
using Esatto_Recruitment_WinForms.Models;
using Esatto_Recruitment_WinForms.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Esatto_Recruitment_WinForms
{
    public partial class AddProductForm : Form
    {
        private readonly IProductService _productService;
        private readonly ICurrencyService _currencyService;
        private readonly ICurrencyExchangeAPIService _currencyExchangeAPIService;

        public string currencyCode { get { return CurrencyComboBox.SelectedValue as string; } }
        public AddProductForm(IProductService productService, ICurrencyService currencyService, ICurrencyExchangeAPIService currencyExchangeAPIService)
        {
            InitializeComponent();

            _productService = productService;
            _currencyService = currencyService;
            _currencyExchangeAPIService = currencyExchangeAPIService;

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

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private async void AddButton_Click(object sender, EventArgs e)
        {
            decimal exchangeRate = await _currencyExchangeAPIService.GetCurrentExchangeRate(currencyCode);
            if (exchangeRate <= 0)
            {
                MessageBox.Show("Exchange currency rate not found.");
                return;
            }

            decimal price = PriceNumericUpDown.Value * exchangeRate;
            Product product = new Product
            {
                Name = NameTextBox.Text,
                Price = price,
                CreationDate = DateTime.Now,
                IsArchived = IsArchivedCheckBox.Checked,
            };

            try
            {
                _productService.Add(product);
                MessageBox.Show("Product added succesfully.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error occured during adding product to database.");
            }
        }

        private void CurrencyComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
