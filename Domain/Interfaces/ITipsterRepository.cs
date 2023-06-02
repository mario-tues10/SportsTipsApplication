using Domain.Entities;
namespace Domain.Interfaces
{
    public interface ITipsterRepository : IAccountRepository
    {
        new Tipster? GetAccountById(int id);
        new List<Tipster>? GetAllAccounts();
        List<Prediction>? GetPredictions(Tipster tipster);
    }
}
