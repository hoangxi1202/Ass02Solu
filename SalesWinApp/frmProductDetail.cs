using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BusinessObject.Repository;
using BusinessObject.Models;
using BusinessObject.DataAccess;
using System.Text.RegularExpressions;

namespace SalesWinApp;
public partial class frmProductDetail : Form
{
    public IProductRepository productRepository { get; set; }
    public bool InsertOrUpdate { get; set; }
    public Product ProductInfo { get; set; }
    public frmProductDetail()
    {
        InitializeComponent();
    }

    private void frmProductDetail_Load(object sender, EventArgs e)
    {
        txtProductID.Enabled = !InsertOrUpdate;

        if (InsertOrUpdate == true)
        {
            txtProductID.Text = ProductInfo.ProductId.ToString();
            txtCategoryID.Text = ProductInfo.CategoryId.ToString();
            txtProductName.Text = ProductInfo.ProductName;
            txtStock.Text = ProductInfo.UnitsInStock.ToString();
            txtUnitPrice.Text = ProductInfo.UnitPrice.ToString();
            txtWeight.Text = ProductInfo.Weight.ToString(); 
        }
    }

    private void btnCancel_Click(object sender, EventArgs e) => Close();

    private void btnSave_Click(object sender, EventArgs e)
    {
        try
        {
            ProductError errors = new ProductError();
            bool found = false;
            string productId = txtProductID.Text;
            string pattern = @"^[0-9.]*$";
            string pattern_int = @"^[0-9]*$";
            Regex regex = new Regex(pattern);
            Regex regex_int = new Regex(pattern_int);
            if (regex_int.IsMatch(productId) == false || productId.Trim().Equals("") || int.Parse(productId) < 0)
            {
                found = true;
                errors.productIDError = "Product ID must be the number format and greater than 0!";
            }

            string categoryId = txtCategoryID.Text;
            if (regex_int.IsMatch(categoryId) == false || categoryId.Trim().Equals("") || int.Parse(categoryId) < 0)
            {
                found = true;
                errors.categoryIDError = "Category ID must be the number format and greater than 0!";
            }

            string name = txtProductName.Text;
            if (name.Length <= 5)
            {
                found = true;
                errors.productNameError = "Length must be > 5";
            }

            string weight = txtWeight.Text;
            if (regex.IsMatch(weight) == false || weight.Trim().Equals("") || float.Parse(weight) < 0)
            {
                found = true;
                errors.WeightError = "Weight need to be float and > 0";
            }
            string price = txtUnitPrice.Text;
            if (regex.IsMatch(price) == false || price.Trim().Equals("") || decimal.Parse(price) < 0)
            {
                found = true;
                errors.UnitPriceError = "Price > 0";
            }
            string stock = txtStock.Text;
            if (regex_int.IsMatch(stock) == false || stock.Trim().Equals("") || int.Parse(stock) < 0)
            {
                found = true;
                errors.UnitInStockError = "Stock need to be int and > 0";
            }

            if (found)
            {
                MessageBox.Show($"{errors.productIDError} \n " +
                    $"{errors.categoryIDError} \n " +
                    $"{errors.productNameError} \n" +
                    $"{errors.UnitPriceError} \n" +
                    $"{errors.UnitInStockError} \n" +
                    $"{errors.WeightError}", "Add a new Product - Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                Product product = new Product
                {
                    ProductId = int.Parse(productId),
                    CategoryId = int.Parse(categoryId),
                    ProductName = name,
                    UnitPrice = decimal.Parse(price),
                    Weight = weight,
                    UnitsInStock = int.Parse(stock)
                };
                if (InsertOrUpdate == false)
                {
                    productRepository.CreateProduct(product);
                }
                else
                {
                    productRepository.UpdateProduct(product);
                }

            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message, InsertOrUpdate == false ? "Add a new Product" : "Update a Product", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
    public record ProductError()
    {
        public string? productIDError { get; set; }
        public string? categoryIDError { get; set; }
        public string? productNameError { get; set; }
        public string? UnitInStockError { get; set; }
        public string? UnitPriceError { get; set; }
        public string? WeightError { get; set; }
    }
}
