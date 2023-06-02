using Domain.Entities;
using Domain;
using DataManagement;
namespace BetExpertAdministration
{
    public partial class Registration : Form
    {
        private AuthenticationHandler authenticationHandler;
        public Registration()
        {
            InitializeComponent();
            authenticationHandler = new AuthenticationHandler(new AdminRepository());
        }

        private void register_Click(object sender, EventArgs e)
        {
            try
            {
                authenticationHandler.Register(username.Text, email.Text, password.Text, UserRole.Admin);
                Login login = new Login();
                login.Show();
                this.Hide();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void registeredAlready_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}