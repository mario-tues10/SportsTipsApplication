using Domain.Entities;
using Domain.Interfaces;
namespace Domain
{
    public class TipsterService
    {
        private readonly ITipsterRepository tipsterRepository;
        public TipsterService(ITipsterRepository tipsterRepository)
        {
            this.tipsterRepository = tipsterRepository;
        }
        public List<Prediction>? GetPredictions(Tipster tipster)
        {
            return tipsterRepository.GetPredictions(tipster);
        }
        public Tipster? GetMyselfById(int id)
        {
            return tipsterRepository.GetAccountById(id);
        }
        public List<Tipster>? GetTipsters()
        {
            return tipsterRepository.GetAllAccounts();
        }
        public int LastPredictionDays(Tipster tipster)
        {
            try
            {
                List<Prediction>? Predictions = tipsterRepository.GetPredictions(tipster);
                if (Predictions != null)
                {
                    Predictions.Sort((x, y) => DateTime.Compare(y.CreationTime, x.CreationTime));
                    TimeSpan timeSpan = DateTime.Now.Subtract(Predictions[0].CreationTime);
                    return timeSpan.Days;
                }
                else
                {
                    return 0;
                }
            }
            catch (NullReferenceException)
            {
                throw new NullReferenceException("Predictions list is empty!");
            }
            catch (ArgumentOutOfRangeException)
            {
                return 0;
            }
        }
        public void DeleteAccount(Tipster tipster)
        {
            tipsterRepository.DeleteIntoAccount(tipster);
        }
        public void ChangePassword(Tipster tipster, string oldPassword, string newPassword)
        {
            if (BCrypt.Net.BCrypt.Verify(oldPassword, tipster.GetPassword()
                ))
            {
                string hashedNewPassword = BCrypt.Net.BCrypt.HashPassword(newPassword);
                tipsterRepository.ChangePassword(tipster, hashedNewPassword);
            }
            else
            {
                throw new Exception("Passwords don't match!");
            }
        }
    }
}
