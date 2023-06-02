using DataManagement;
using Domain.Entities;
using Domain;
namespace BetExpertAdministration
{
    public partial class AdminPanel : Form
    {
        private AdminService adminService;
        private CompetitionService competitionService;
        private MatchService matchService;
        private TipsterService tipsterService;
        private Admin loggedAdmin;
        public AdminPanel(Admin loggedAdmin)
        {
            InitializeComponent();
            this.loggedAdmin = loggedAdmin;
            adminService = new AdminService(new AdminRepository());
            competitionService = new CompetitionService(new CompetitionRepository());
            matchService = new MatchService(new MatchRepository());
            tipsterService = new TipsterService(new TipsterRepository());
            assignCompetition.Click += new EventHandler(OnAssingningCompetitions);
            loggedUser.Text = $"Logged in as: " + loggedAdmin.Username;
        }
        private void OnAssingningCompetitions(object? sender, EventArgs? e)
        {
            assignCompetition.Items.Clear();
            try
            {
                foreach (Competition competition in competitionService.GetCompetitions())
                {
                    assignCompetition.DisplayMember = competition.Name;
                    assignCompetition.ValueMember = competition.GetId().ToString();
                    assignCompetition.Items.Add(competition.Name);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There are no competitions!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void createCompetition_Click(object sender, EventArgs e)
        {
            try
            {
                if (name.Text.Length == 0)
                {
                    name.Text = "TBA";
                }
                Competition competition = new Competition(name.Text, Enum.Parse<Sport>(sport.SelectedItem.ToString()),
                    startDate.Value, endDate.Value);
                competitionService.CreateCompetition(competition);
                MessageBox.Show("You have created competition correctly!", "Success!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have not selected correct data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allCompetitions_Click(object sender, EventArgs e)
        {
            Competitions.Items.Clear();
            try
            {
                List<Competition>? competitions = competitionService.GetCompetitions();
                foreach (Competition competition in competitions)
                {
                    string[] row = { competition.Name, competition.CompetitionSport.ToString(),
                        competition.StartDate.ToShortDateString(), competition.EndDate.ToShortDateString()};
                    Competitions.Items.Add(competition.GetId().ToString()).SubItems.AddRange(row);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There are no competitions yet!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void deleteCompetition_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure suspending that tipster?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Competition competition = new Competition(Competitions.SelectedItems[0].SubItems[1].Text,
                        Enum.Parse<Sport>(Competitions.SelectedItems[0].SubItems[2].Text),
                        DateTime.Parse(Competitions.SelectedItems[0].SubItems[3].Text),
                        DateTime.Parse(Competitions.SelectedItems[0].SubItems[4].Text));
                    competition.SetId(Convert.ToInt32(Competitions.SelectedItems[0].SubItems[0].Text));
                    competitionService.DeleteCompetition(competition);
                    MessageBox.Show("You have deleted the selected competition correctly!", "Success!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select competition to remove!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void createMatch_Click(object sender, EventArgs e)
        {
            try
            {
                if (firstCompetitor.Text.Length == 0)
                {
                    firstCompetitor.Text = "TBA";
                }
                if (secondCompetitor.Text.Length == 0)
                {
                    secondCompetitor.Text = "TBA";
                }
                Match match = new Match(firstCompetitor.Text, secondCompetitor.Text, startTime.Value,
                    Convert.ToInt32(assignCompetition.ValueMember));
                Competition? assignedCompetition = competitionService.GetMyselfById
                    (Convert.ToInt32(assignCompetition.ValueMember));
                matchService.CreateMatch(assignedCompetition, match);
                MessageBox.Show("You have created match correctly!", "Success!",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have not entered correct data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void allMatches_Click(object sender, EventArgs e)
        {
            Matches.Items.Clear();
            try
            {
                List<Match>? matches = matchService.GetMatches();
                foreach (Match match in matches)
                {
                    string[] row = { match.FirstCompetitor, match.SecondCompetitor,
                        match.StartTime.ToString(), match.CompetitionId.ToString()};
                    Matches.Items.Add(match.GetId().ToString()).SubItems.AddRange(row);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There are no matches yet!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void deleteMatch_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure deleting that match?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Match match = new Match(Matches.SelectedItems[0].SubItems[1].Text,
                        Matches.SelectedItems[0].SubItems[2].Text,
                        DateTime.Parse(Matches.SelectedItems[0].SubItems[3].Text),
                        Convert.ToInt32(Matches.SelectedItems[0].SubItems[4].Text));
                    matchService.DeleteMatch(match);
                    MessageBox.Show("You have deleted the selected match correctly!", "Success!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("Select match to remove!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allTipsters_Click(object sender, EventArgs e)
        {
            Tipsters.Items.Clear();
            try
            {
                List<Tipster>? tipsters = tipsterService.GetTipsters();
                foreach (Tipster tipster in tipsters)
                {
                    string[] row = { tipster.Username, tipster.SuccessRate.ToString() + "%",
                        tipsterService.LastPredictionDays(tipster).ToString(),tipster.Suspended.ToString()
                    };
                    Tipsters.Items.Add(tipster.GetId().ToString()).SubItems.AddRange(row);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("There are no competitions yet!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void suspendTipster_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure suspending that tipster?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tipster? tipster = tipsterService.GetMyselfById(Convert.ToInt32(Tipsters.SelectedItems[0].SubItems[0].Text));
                    adminService.SuspendTipster(tipster);
                    MessageBox.Show("You have suspended the tipster's account correctly!", "Success!",
                      MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have not selected tipster!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void resumeTipster_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Are you sure resuming that tipster?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tipster? tipster = tipsterService.GetMyselfById(Convert.ToInt32(Tipsters.SelectedItems[0].SubItems[0].Text));
                    adminService.ResumeTipster(tipster);

                    MessageBox.Show("You have resumed tipster's account correctly!", "Success!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have not selected tipster!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void deleteTipster_Click(object sender, EventArgs e)
        {
            try
            {

                DialogResult result = MessageBox.Show("Are you sure deleting that tipster?", "Confirm",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    Tipster? tipster = tipsterService.GetMyselfById(Convert.ToInt32(Tipsters.SelectedItems[0].SubItems[0].Text));
                    tipsterService.DeleteAccount(tipster);

                    MessageBox.Show("You have deleted the tipster's account correctly!", "Success!",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("You have not selected tipster!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void logOut_Click(object sender, EventArgs e)
        {
            this.Hide();
            Login logIn = new Login();
            logIn.Show();
        }

        private void Profile_Click(object sender, EventArgs e)
        {
            this.Hide();
            Profile profile = new Profile(loggedAdmin);
            profile.Show();
        }
    }
}
