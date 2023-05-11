using DataManagement.Interfaces;
using DataManagement.Entities;
using DataManagement;
namespace BetExpertAdministration
{
    public partial class AdminPanel : Form
    {
        private readonly ICompetitionRepository competitionRepository;
        private readonly IMatchRepository matchRepository;
        public AdminPanel()
        {
            InitializeComponent();
            competitionRepository = new CompetitionRepository(new SqlService());
            matchRepository = new MatchRepository(new SqlService());
            assignCompetition.Click += new EventHandler(OnAssingningCompetitions);
        }

        private void OnAssingningCompetitions(object sender, EventArgs e)
        {
            assignCompetition.Items.Clear();
            try
            {
                foreach (Competition competition in competitionRepository.GetAllCompetitions())
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
                Competition competition = new Competition(name.Text, Enum.Parse<Sport>(sport.SelectedItem.ToString()),
                    startDate.Value, endDate.Value);
                competitionRepository.InsertIntoCompetition(competition);
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
                List<Competition>? competitions = competitionRepository.GetAllCompetitions();
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
                Competition competition = new Competition(Competitions.SelectedItems[0].SubItems[1].Text,
                    Enum.Parse<Sport>(Competitions.SelectedItems[0].SubItems[2].Text),
                    DateTime.Parse(Competitions.SelectedItems[0].SubItems[3].Text),
                    DateTime.Parse(Competitions.SelectedItems[0].SubItems[4].Text));
                competition.SetId(Convert.ToInt32(Competitions.SelectedItems[0].SubItems[0].Text));
                competitionRepository.DeleteIntoCompetition(competition);
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
                Match match = new Match(firstCompetitor.Text, secondCompetitor.Text, startTime.Value,
                    Convert.ToInt32(assignCompetition.ValueMember));
                matchRepository.InsertIntoMatch(match);
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
                List<Match>? matches = matchRepository.GetAllMatches();
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
                Match match = new Match(Matches.SelectedItems[0].SubItems[1].Text,
                    Matches.SelectedItems[0].SubItems[2].Text,
                    DateTime.Parse(Matches.SelectedItems[0].SubItems[3].Text),
                    Convert.ToInt32(Matches.SelectedItems[0].SubItems[4].Text));
                matchRepository.DeleteIntoMatch(match);
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
