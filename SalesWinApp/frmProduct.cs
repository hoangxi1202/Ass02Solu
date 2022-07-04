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
                var products = productRepository.GetListProducts().OrderBy(x => x.ProductId);
                source = new BindingSource();
                List<Product> listProducts = productRepository.GetListProducts();
                source.DataSource = products;
                dgvProduct.DataSource = source;
                dgvProduct.Columns[6].Visible = false;
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
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Create a product",
                InsertOrUpdate = false,
                ProductInfo = GetProductObject(),
                productRepository = productRepository
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
            {
                LoadProductList();
                source.Position = source.Count - 1;
            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            dgvProduct.CellDoubleClick += DgvProduct_CellDoubleClick;
            LoadProductList();
        }

        private void DgvProduct_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            frmProductDetail frmProductDetail = new frmProductDetail
            {
                Text = "Update a order",
                InsertOrUpdate = true,
                ProductInfo = GetProductObject(),
                productRepository = productRepository
            };
            if (frmProductDetail.ShowDialog() == DialogResult.OK)
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
                product = new Product
                {
                    ProductId = int.Parse(txtProductID.Text),
                    CategoryId = int.Parse(txtCategoryID.Text),
                    ProductName = txtProductName.Text,
                    UnitsInStock = int.Parse(txtUnitsInStock.Text),
                    Weight = txtWeight.Text,
                    UnitPrice = decimal.Parse(txtUnitPrice.Text)
                };
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Get Product");
            }
            return product;
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int productID = int.Parse(txtProductID.Text);
            try
            {
                productRepository.DeleteProduct(productID);
                LoadProductList();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Delete a product - Error ",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) => this.Close();

        private void dgvProduct_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int index = e.RowIndex;
            txtProductID.Clear();
            txtCategoryID.Clear();
            txtProductName.Clear();
            txtUnitPrice.Clear();
            txtUnitsInStock.Clear();
            txtWeight.Clear();
            txtProductID.Text = dgvProduct.Rows[index].Cells[0].Value.ToString();
            txtCategoryID.Text = dgvProduct.Rows[index].Cells[1].Value.ToString();
            txtProductName.Text = dgvProduct.Rows[index].Cells[2].Value.ToString();
            txtWeight.Text = dgvProduct.Rows[index].Cells[3].Value.ToString();
            txtUnitPrice.Text = dgvProduct.Rows[index].Cells[4].Value.ToString();
            txtUnitsInStock.Text = dgvProduct.Rows[index].Cells[5].Value.ToString();           

        }
    }
}
