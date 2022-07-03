using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessObject.Models;
using BusinessObject.DataAccess;
using BusinessObject.Repository;
using System.Text.RegularExpressions;
namespace SalesWinApp
{
    public partial class frmViewProduct : Form
    {
        public Product ProductInfo { get; set; }
        public bool InsertOrUpdate { get; set; }
        public IProductRepository ProductRepository { get; set; }
        public frmViewProduct()
        {
            InitializeComponent();
        }

        private void frmViewProduct_Load(object sender, EventArgs e)
        {
            txtProductID.Enabled = !InsertOrUpdate;
            if(InsertOrUpdate == true)
            {
                txtProductID.Text = ProductInfo.ProductId.ToString();
                txtCategoryID.Text = ProductInfo.CategoryId.ToString();
                txtProductName.Text = ProductInfo.ProductName.ToString();
                txtWeight.Text = ProductInfo.Weight.ToString();
                txtUnitPrice.Text = ProductInfo.UnitPrice.ToString();
                txtUnitsInStock.Text = ProductInfo.UnitsInStock.ToString();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                ProductError errors = new ProductError();
                bool check = false;
                string productID = txtProductID.Text;
                string pattern = @"^[0-9.]*$";
                Regex regex = new Regex(pattern);
                //
                if(regex.IsMatch(productID) == false || productID.Trim().Equals("") || int.Parse(productID) < 0)
                {
                    check = true;
                    errors.productIdError = "Product ID must be the number format and greater than 0!";
                }
                //
                string categoryID = txtCategoryID.Text;
                if (regex.IsMatch(categoryID) == false || categoryID.Trim().Equals("") || int.Parse(categoryID) < 0)
                {
                    check = true;
                    errors.categoryIdError = "Category ID must be the number format and greater than 0!";
                }
                //
                string productName = txtProductName.Text;
                if (productName.Trim().Equals(""))
                {
                    check = true;
                    errors.productNameError = "Product Name not blank!";
                }
                //
                string weight = txtWeight.Text;
                if (regex.IsMatch(weight) == false || weight.Trim().Equals("") || int.Parse(weight) < 0)
                {
                    check = true;
                    errors.weightError = "Weight must be the number format and greater than 0!";
                }
                //
                string unitPrice = txtUnitPrice.Text;
                if (regex.IsMatch(unitPrice) == false || unitPrice.Trim().Equals("") || int.Parse(unitPrice) < 0)
                {
                    check = true;
                    errors.unitPriceError = "Price must be the number format and greater than 0!";
                }
                //
                string unitsInStock = txtUnitsInStock.Text;
                if (regex.IsMatch(unitsInStock) == false || unitsInStock.Trim().Equals("") || int.Parse(unitsInStock) < 0)
                {
                    check = true;
                    errors.unitsInStockError = "Units in stock must be the number format and greater than 0!";
                }
                //
                if (check)
                {
                    MessageBox.Show($"{errors.productIdError} \n " +
                        $"{errors.categoryIdError} \n " +
                        $"{errors.productNameError} \n" +
                        $"{errors.weightError} \n" +
                        $"{errors.unitPriceError} \n" +
                        $"{errors.unitsInStockError}", "Add a new product - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    Product product = new Product
                    {
                        ProductId = int.Parse(productID),
                        CategoryId = int.Parse(categoryID),
                        ProductName = txtProductName.Text,
                        Weight = txtWeight.Text,
                        UnitPrice = decimal.Parse(unitPrice),
                        UnitsInStock = int.Parse(unitsInStock),
                    };
                    if(InsertOrUpdate == false)
                    {
                        ProductRepository.CreateProduct(product);
                    }
                    else
                    {
                        ProductRepository.UpdateProduct(product);
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new product" : "Update a product", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e) => Close();
        public record ProductError()
        {
            public string? productIdError { get; set; }
            public string? categoryIdError { get; set; }
            public string? productNameError { get; set; }
            public string? weightError { get; set; }
            public string? unitPriceError { get; set; }
            public string? unitsInStockError { get; set; }

        }
    }
}
