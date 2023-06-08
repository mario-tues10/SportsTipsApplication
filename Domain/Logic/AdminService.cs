using Domain.Entities;
using Domain.Interfaces;
namespace Domain.Logic
{
    public class AdminService
    {
        private readonly IAdminRepository adminRepository;
        private readonly ITipsterRepository? tipsterRepository;
        private event EventHandler<LastPredictionDaysArgs> lastPredictionDays;
        public event EventHandler<LastPredictionDaysArgs> LastPredictionDays
        {
            add { lastPredictionDays += value; }
            remove { lastPredictionDays -= value; }
        }

        public AdminService(IAdminRepository adminRepository, ITipsterRepository? tipsterRepository)
        {
            this.adminRepository = adminRepository;
            this.tipsterRepository = tipsterRepository;
        }

        public void SuspendTipster(Tipster tipster)
        {
            adminRepository.SuspendTipster(tipster);
        }
        public void ResumeTipster(Tipster tipster)
        {
            adminRepository.ResumeTipster(tipster);
        }
        public Admin? GetMyselfById(int id)
        {
            return adminRepository.GetAccountById(id);
        }
        public List<Admin>? GetMyselfList()
        {
            return adminRepository.GetAllAccounts();
        }
        public void DeleteAccount(Admin admin)
        {
            adminRepository.DeleteIntoAccount(admin);
        }
        public void ChangePassword(Admin admin, string oldPassword, string newPassword)
        {
            if (BCrypt.Net.BCrypt.Verify(oldPassword, admin.GetPassword()))
            {
                string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                adminRepository.ChangePassword(admin, hashedNewPassword);
            }
            else
            {
                throw new Exception("Passwords don't match!");
            }
        }
        // The non-trivial logic for desktop app + event handler invocation
        public void GetLastPredictionDays(Tipster tipster, int rowIndex)
        {
            LastPredictionDaysArgs args = new LastPredictionDaysArgs();
            args.RowIndex = rowIndex;
            try
            {
                List<Prediction>? Predictions = tipsterRepository.GetPredictions(tipster);
                if (Predictions != null)
                {
                    Predictions.Sort((x, y) => DateTime.Compare(y.CreationTime, x.CreationTime));
                    TimeSpan timeSpan = DateTime.Now.Subtract(Predictions[0].CreationTime);
                    args.Days = timeSpan.Days;
                    lastPredictionDays?.Invoke(this, args);
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Predictions list is empty!");
            }
            catch(ArgumentOutOfRangeException)
            {
                args.Days = 0;
                lastPredictionDays?.Invoke(this, args);
            }
        }
    }
}
