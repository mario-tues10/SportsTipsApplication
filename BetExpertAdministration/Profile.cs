using Domain.Entities;
using Domain;
using DataManagement;
namespace BetExpertAdministration
{
    public partial class Profile : Form
    {
        private AdminService adminService;
        private Admin loggedAdmin;
        public Profile(Admin admin)
        {
            InitializeComponent();
            id.Enabled = false;
            username.Enabled = false;
            loggedAdmin = admin;
            adminService = new AdminService(new AdminRepository(), null);
            id.Text = admin.GetId().ToString();
            username.Text = admin.Username;
        }

        private void deleteAccount_Click(object sender, EventArgs e)
        {
            adminService.DeleteAccount(loggedAdmin);
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }

        private void changePassword_Click(object sender, EventArgs e)
        {
            try
            {
                adminService.ChangePassword(loggedAdmin, oldPassword.Text, newPassword.Text);
                MessageBox.Show("You have changed your password correctly!", "Success!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminPanel_Click(object sender, EventArgs e)
        {
            AdminPanel adminPanel = new AdminPanel(loggedAdmin);
            adminPanel.Show();
            this.Hide();
        }
    }
}
