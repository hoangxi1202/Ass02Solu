using BusinessObject.Repository;
namespace SalesWinApp
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        private void ClearText()
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;

        }
        public IMemberRepository MemberRepository { get; set; }
        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string userName = txtUserName.Text;
                string password = txtPassword.Text;
                MemberRepository = new MemberRepository();

                if (MemberRepository.CheckLogin(userName, password))
                {
                    DialogResult dg = MessageBox.Show("Login Successfully", "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    frmMain frmMain = new frmMain();
                    frmMain.ShowDialog();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult dg = MessageBox.Show("Are you sure to cancel ?", "Cancel", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dg == DialogResult.Yes)
                Application.Exit();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {

        }

        private void rdbShowHide_CheckedChanged(object sender, EventArgs e)
        {
            if (rdbShowHide.Checked)
            {
                txtPassword.PasswordChar = (char)0;
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }
    }
}