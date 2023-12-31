﻿using Domain.Entities;
using Domain.Logic;
using DataManagement;
namespace BetExpertAdministration
{
    public partial class Login : Form
    {
        private AuthenticationHandler authenticationHandler;
        public Login()
        {
            InitializeComponent();
            authenticationHandler = new AuthenticationHandler(new AdminRepository());
        }

        private void blogin_Click(object sender, EventArgs e)
        {
            User? loggingAdmin = authenticationHandler.Authenticate(username.Text, email.Text, password.Text);
            if(loggingAdmin != null) {
                Admin loggedAdmin = new Admin(loggingAdmin.Username, loggingAdmin.Email,
                    loggingAdmin.GetPassword(), loggingAdmin.UserRole);
                loggedAdmin.SetId(loggingAdmin.GetId());
                AdminPanel adminPanel = new AdminPanel(loggedAdmin);
                adminPanel.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("There is no admin with these credentials!", "Error!", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void noAccount_Click(object sender, EventArgs e)
        {
            this.Hide();
            Registration registration = new Registration();
            registration.Show();
        }
    }
}
