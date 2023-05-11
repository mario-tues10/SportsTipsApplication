using DataManagement;
using DataManagement.Entities;
using Domain;
namespace BetExpertAdministration
{
    public partial class Registration : Form
    {
        private AuthenticationHandler registerHandler;
        public Registration()
        {
            InitializeComponent();
            registerHandler = new AuthenticationHandler();
        }

        private void register_Click(object sender, EventArgs e)
        {
            try
            {
                registerHandler.Register(username.Text, email.Text, password.Text, 
                    UserRole.Admin, null, new AdminRepository(new SqlService()));
                Login login = new Login();
                login.Show();
                this.Hide();
            }catch(Exception ex) {
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