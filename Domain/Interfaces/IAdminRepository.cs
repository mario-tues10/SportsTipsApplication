using Domain.Entities;
namespace Domain.Interfaces
{
    public interface IAdminRepository : IAccountRepository
    {
        new Admin? GetAccountById(int id);
        new List<Admin>? GetAllAccounts();
        void SuspendTipster(Tipster tipster);
        void ResumeTipster(Tipster tipster);
    }
}
