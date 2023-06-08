using Domain.Entities;
using Domain.Interfaces;
namespace ApplicationTest.Mocks
{
    public class MockAdminRepository : MockUserRepository, IAdminRepository
    {
        public MockAdminRepository(List<User> admins) : base(admins)
        {
        }
        public new Admin? GetAccountById(int id)
        {
            List<Admin> Admins = Accounts.OfType<Admin>().ToList();
            foreach (Admin admin in Admins)
            {
                if (admin.GetId() == id)
                {
                    return admin;
                }
            }
            return null;
        }
        public new List<Admin> GetAllAccounts()
        {
            List<Admin> Admins = Accounts.OfType<Admin>().ToList();
            return Admins;
        }
        public void SuspendTipster(Tipster tipster)
        {
            tipster.Suspended = true;
        }
        public void ResumeTipster(Tipster tipster)
        {
            tipster.Suspended = false;
        }
    }
}
