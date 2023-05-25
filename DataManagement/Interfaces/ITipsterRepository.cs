using DataManagement.Entities;
namespace DataManagement.Interfaces
{
    public interface ITipsterRepository : IAccountRepository
    {
        new Tipster? GetAccountById(int id);
        new List<Tipster>? GetAllAccounts();
        List<Prediction>? GetPredictions(Tipster tipster);
    }
}
