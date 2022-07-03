using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;
using BusinessObject.Models;
using BusinessObject.DataAccess;
using BusinessObject.Repository;
using System.Text.RegularExpressions;

namespace SalesWinApp
{
    public partial class frmProduct : Form
    {
        
        public frmProduct()
        {
            InitializeComponent();
        }
        public IProductRepository productRepository = new ProductRepository();
        public BindingSource? source;
        private void LoadProductList()
        {
            try
            {
                var products = productRepository.GetListProducts().OrderByDescending(x => x.ProductId);
                source = new BindingSource();
                List<Product> listProducts = productRepository.GetListProducts();
                source.DataSource = products;
                dgvProduct.DataSource = source;
               
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        
        private void frmProduct_Load(object sender, EventArgs e)
        {
            LoadProductList();
        }

        private void btnCreate_Click(object sender, EventArgs e)
        {
            frmViewProduct frmViewProduct = new frmViewProduct
            {
                Text = "Create a product",
                InsertOrUpdate = false,
                ProductRepository = productRepository

            };
            if (frmViewProduct.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //btnDelete.Enabled = false;
            btnDelete.Enabled = false;
            dgvProduct.CellDoubleClick += dgvProduct_CellDoubleClick;
            LoadProductList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(txtProductID.Text);
            if(MessageBox.Show("Are you want to delete this product?", "EF CRUD Operation", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                try
                {
                    productRepository.DeleteProduct(productID);
                    LoadProductList();
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message, "Delete pruduct fail", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void dgvProduct_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmViewProduct frmViewProduct = new frmViewProduct
            {
                Text = "Update a product",
                InsertOrUpdate = true,
                ProductInfo = GetProductObject(),
                ProductRepository = productRepository
                
            };
            if(frmViewProduct.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }
        private Product GetProductObject()
        {
            Product? product = null;
            try
            {
                int productID;
                dynamic check = int.TryParse(txtProductID.Text, out productID);
                int categoryID;
                check = int.TryParse(txtCategoryID.Text, out categoryID);
                string productName = txtProductName.Text;
                string weight = txtWeight.Text;
                decimal unitPrice;
                check = decimal.TryParse(txtUnitPrice.Text, out unitPrice);
                int unitsInStock;
                check = int.TryParse(txtUnitsInStock.Text, out unitsInStock);

                product = new Product
                {
                    ProductId = productID,
                    CategoryId = categoryID,
                    ProductName = productName,
                    Weight = weight,
                    UnitPrice = unitPrice,
                    UnitsInStock = unitsInStock
                };
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Get product");
            }
            return product;
        }

        private void btnClose_Click(object sender, EventArgs e) => Close();

        private void dgvProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtProductID.Clear();
            txtCategoryID.Clear();
            txtProductName.Clear();
            txtWeight.Clear();
            txtUnitPrice.Clear();
            txtUnitsInStock.Clear();

            txtProductID.Text = dgvProduct.Rows[index].Cells[0].Value.ToString();
            txtCategoryID.Text = dgvProduct.Rows[index].Cells[1].Value.ToString();
            txtProductName.Text = dgvProduct.Rows[index].Cells[2].Value.ToString();
            txtWeight.Text = dgvProduct.Rows[index].Cells[3].Value.ToString();
            txtUnitPrice.Text = dgvProduct.Rows[index].Cells[4].Value.ToString();
            txtUnitsInStock.Text = dgvProduct.Rows[index].Cells[5].Value.ToString();
        }
    }
}
