using Domain.Entities;
using Domain.Interfaces;
namespace ApplicationTest.Mocks
{
    public class MockTipsterRepository : MockUserRepository, ITipsterRepository
    {
        public List<Prediction>? TipsterPredictions { get; private set; }
        public MockTipsterRepository(List<User> tipsters) : base(tipsters)
        {
            TipsterPredictions = new List<Prediction>();
        }
        public new Tipster? GetAccountById(int id)
        {
            List<Tipster> Tipsters = Accounts.OfType<Tipster>().ToList();
            foreach (Tipster tipster in Tipsters)
            {
                if (tipster.GetId() == id)
                {
                    return tipster;
                }
            }
            return null;
        }
        public new List<Tipster> GetAllAccounts()
        {
            List<Tipster> Tipsters = Accounts.OfType<Tipster>().ToList();
            return Tipsters;
        }
        public void UpdateRate(Tipster tipster, decimal rate)
        {
            tipster.SuccessRate = rate;
        }
        public List<Prediction>? GetPredictions(Tipster? tipster)
        {
            return TipsterPredictions;
        }
        public Tipster? GetCreator(Prediction prediction)
        {
            foreach(User user in Accounts) 
            {
                if(user.GetId() == prediction.TipsterId)
                {
                    return (Tipster?)user;
                }
            }
            return null;
        }
    }

}
