using DataManagement;
using Domain;
namespace BetExpertAdministration
{
    public partial class Login : Form
    {
        AuthenticationHandler logHadler;
        public Login()
        {
            InitializeComponent();
            logHadler = new AuthenticationHandler();
        }

        private void blogin_Click(object sender, EventArgs e)
        {
            if(logHadler.Login(username.Text, email.Text,  password.Text, new AdminRepository(new SqlService())) != null) {
                AdminPanel adminPanel = new AdminPanel();
                adminPanel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("There is no admin with these credentials!", "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
