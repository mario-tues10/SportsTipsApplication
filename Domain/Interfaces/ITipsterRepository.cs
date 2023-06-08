using Domain.Entities;
namespace Domain.Interfaces
{
    public interface ITipsterRepository : IAccountRepository
    {
        void UpdateRate(Tipster tipster, decimal newRate);
        new Tipster? GetAccountById(int id);
        new List<Tipster>? GetAllAccounts();
        List<Prediction>? GetPredictions(Tipster? tipster);
        Tipster? GetCreator(Prediction prediction);
    }
}
