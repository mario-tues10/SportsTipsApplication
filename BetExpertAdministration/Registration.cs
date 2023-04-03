using Domain;
using Entites;

namespace BetExpertAdministration
{
    public partial class Registration : Form
    {
        LogHandler AdminHandler;
        public Registration()
        {
            AdminHandler = new LogHandler();
            InitializeComponent();
        }

        private void register_Click(object sender, EventArgs e)
        {
            try
            {
                AdminHandler.Register(username.Text, email.Text, password.Text);
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