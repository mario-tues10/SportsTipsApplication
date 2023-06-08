using ApplicationTest.Mocks;
using Domain.DVOs;
using Domain.Entities;
using Domain.Logic;
namespace ApplicationTest
{
    [TestClass]
    public class ViewMapperTests
    {
        private MockPredictionRepository mockPredictionRepository;
        private MockTipsterRepository mockTipsterRepository;
        private MockUserRepository mockUserRepository;
        private ViewMapper viewMapper;

        [TestInitialize]
        public void Setup()
        {
            mockPredictionRepository = new MockPredictionRepository(new List<Prediction>());
            mockTipsterRepository = new MockTipsterRepository(new List<User>());
            mockUserRepository = new MockUserRepository(new List<User>());
            viewMapper = new ViewMapper(mockPredictionRepository, mockTipsterRepository, mockUserRepository);
        }

        [TestMethod]
        public void MapPredictions_ValidMatch_ReturnsNonNullMappedPredictions()
        {
            Match match = new Match("Team A", "Team B", DateTime.Now, 1);
            Sport sport = Sport.Tennis;
            List<Prediction> predictions = new List<Prediction>
            {
                new Prediction("prediction1", "finalPrediction1", DateTime.Now, false, sport, 1, 1),
                new Prediction("prediction2", "finalPrediction2", DateTime.Now, false, sport, 2, 1),
                new Prediction("prediction3", "finalPrediction3", DateTime.Now, false, sport, 3, 1)
            };
            mockPredictionRepository.Predictions.AddRange(predictions);
            List<PredictionDVO>? result = viewMapper.MapPredictions(match);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MapProfile_ClientRole_ReturnsNonNullProfileDVO()
        {
            int clientId = 1;
            string clientRole = "Client";
            User client = new User("client1", "client1@example.com", "password", UserRole.Client);
            client.SetId(clientId);
            mockUserRepository.Accounts.Add(client);
            ProfileDVO? result = viewMapper.MapProfile(clientId, clientRole);
            Assert.IsNotNull(result);
        }

        [TestMethod]
        public void MapProfile_TipsterRole_ReturnsNonNullProfileDVO()
        {
            int tipsterId = 1;
            string tipsterRole = "Tipster";
            Tipster tipster = new Tipster("tipster1", "tipster1@example.com", "password", UserRole.Tipster); 
            tipster.SetId(tipsterId);
            mockTipsterRepository.Accounts.Add(tipster);
            ProfileDVO? result = viewMapper.MapProfile(tipsterId, tipsterRole);
            Assert.IsNotNull(result);
        }
    }
}
