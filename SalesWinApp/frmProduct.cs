using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
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
        /*
        public static void FillCombo(string sql, ComboBox cbo, string id, string name)
        {
            SqlDataAdapter dap = new SqlDataAdapter(sql, Con);
            DataTable table = new DataTable();
            dap.Fill(table);
            cbo.DataSource = table;
            cbo.ValueMember = id; //Trường giá trị
            cbo.DisplayMember = name; //Trường hiển thị
        }
        */
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

        private void dgvProduct_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnCreate_Click(object sender, EventArgs e)
        {

        }

        private void dgvProduct_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            //btnDelete.Enabled = false;
            LoadProductList();
        }
    }
}
