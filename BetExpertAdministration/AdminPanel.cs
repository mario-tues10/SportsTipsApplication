using Domain;
using Entites;
using System.Configuration;
using System.Security.Policy;

namespace BetExpertAdministration
{
    public partial class AdminPanel : Form
    { 
    
        AdminService adminService;

        public AdminPanel()
        {
            InitializeComponent();
            adminService = new AdminService();
            assignCompetition.Click += new EventHandler(OnAssingningCompetitions);
        }
        
        private void OnAssingningCompetitions(object sender, EventArgs e)
        {
            assignCompetition.Items.Clear();
            foreach (Competition competition in adminService.Competitions)
            {
                assignCompetition.DisplayMember = competition.Name;
                assignCompetition.ValueMember = competition.GetId().ToString();
                assignCompetition.Items.Add(competition.Name);
            }
        }
        private void createCompetition_Click(object sender, EventArgs e)
        {
            try
            {
                adminService.AddCompetition(name.Text, Enum.Parse<Sport>(sport.SelectedItem.ToString()),
                    startDate.Value, endDate.Value);
            }
            catch(NullReferenceException)
            {
                MessageBox.Show("You have not selected correct data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch(Exception ex) {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allCompetitions_Click(object sender, EventArgs e)
        {
            Competitions.Items.Clear();
            try
            {
                List<Competition>? competitions = adminService.AllCompetitions();
                foreach(Competition competition in competitions)
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
                adminService.RemoveCompetition(Competitions.FocusedItem);
            }catch(NullReferenceException)
            {
                MessageBox.Show("Select competition to remove!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void createMatch_Click(object sender, EventArgs e)
        {
            try
            {
                adminService.AddMatch(firstCompetitor.Text, secondCompetitor.Text, startTime.Value,  
                    Convert.ToInt32(assignCompetition.ValueMember));
            }catch(NullReferenceException)
            {
                MessageBox.Show("You have not entered correct data!", "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void allMatches_Click(object sender, EventArgs e)
        {
            Matches.Items.Clear();
            try
            {
                List<Match>? matches = adminService.AllMatches();
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
                adminService.RemoveMatch(Matches.FocusedItem.StateImageIndex);
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
    }
}
