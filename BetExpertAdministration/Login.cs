using Domain;
namespace BetExpertAdministration
{
    public partial class Login : Form
    {
        LogHandler AdminHadler;
        public Login()
        {
            AdminHadler = new LogHandler();
            InitializeComponent();
        }

        private void blogin_Click(object sender, EventArgs e)
        {
            if(AdminHadler.Login(username.Text, password.Text)) {
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
