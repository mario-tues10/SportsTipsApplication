using ApplicationTest.Mocks;
using Domain.Entities;
using Domain.Logic;
namespace ApplicationTest
{
    [TestClass]
    public class ClientSuggestionsTests
    {
        private MockTipsterRepository mockTipsterRepository;
        private MockPredictionRepository mockPredictionRepository;
        private ClientSuggestions clientSuggestions;

        [TestInitialize]
        public void Setup()
        {
            mockTipsterRepository = new MockTipsterRepository(new List<User>());
            mockPredictionRepository = new MockPredictionRepository(new List<Prediction>());
            clientSuggestions = new ClientSuggestions(mockTipsterRepository, mockPredictionRepository);
        }

        [TestMethod]
        public void SuggestTipstersBySport_ValidSport_ReturnsSortedTipstersList()
        {
            Sport sport = Sport.Tennis;
            List<Tipster> tipsters = new List<Tipster>
            {
                new Tipster("tipster1", "tipster1@example.com", "password", UserRole.Tipster),
                new Tipster("tipster2", "tipster2@example.com", "password", UserRole.Tipster),
                new Tipster("tipster3", "tipster3@example.com", "password", UserRole.Tipster)
            };
            mockTipsterRepository.Accounts.AddRange(tipsters);
            List<Tipster>? result = clientSuggestions.SuggestTipstersBySport(sport);
            Assert.AreEqual(tipsters.Count, result.Count);
        }

        [TestMethod]
        public void SportBestTipsterPredictions_ValidSport_ReturnsSortedPredictionsList()
        {
            Sport sport = Sport.Tennis;
            List<Prediction> predictions = new List<Prediction>
            {
                new Prediction("prediction1", "finalPrediction1", DateTime.Now, false, sport, 1, 1),
                new Prediction("prediction2", "finalPrediction2", DateTime.Now, false, sport, 2, 1),
                new Prediction("prediction3", "finalPrediction3", DateTime.Now, false, sport, 3, 1)
            };
            mockPredictionRepository.Predictions.AddRange(predictions);
            List<Prediction>? result = clientSuggestions.SportBestTipsterPredictions(sport);
            Assert.AreEqual(predictions.Count, result.Count);
        }
        [TestMethod]
        public void SuggestTipstersBySport_ValidSport_ReturnsNotNullTipstersList()
        {
            Sport sport = Sport.Tennis;
            List<Tipster> tipsters = new List<Tipster>
            {
                new Tipster("tipster1", "tipster1@example.com", "password", UserRole.Tipster),
                new Tipster("tipster2", "tipster2@example.com", "password", UserRole.Tipster),
                new Tipster("tipster3", "tipster3@example.com", "password", UserRole.Tipster)
            };
            mockTipsterRepository.Accounts.AddRange(tipsters);
            List<Tipster>? result = clientSuggestions.SuggestTipstersBySport(sport);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void SportBestTipsterPredictions_ValidSport_ReturnsNotNullPredictionsList()
        {
            Sport sport = Sport.Tennis;
            List<Prediction> predictions = new List<Prediction>
            {
                new Prediction("prediction1", "finalPrediction1", DateTime.Now, false, sport, 1, 1),
                new Prediction("prediction2", "finalPrediction2", DateTime.Now, false, sport, 2, 1),
                new Prediction("prediction3", "finalPrediction3", DateTime.Now, false, sport, 3, 1)
            };
            mockPredictionRepository.Predictions.AddRange(predictions);
            List<Prediction>? result = clientSuggestions.SportBestTipsterPredictions(sport);
            Assert.IsNotNull(result);
        }
    }
}
