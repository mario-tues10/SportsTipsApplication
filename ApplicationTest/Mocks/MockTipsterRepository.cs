using Domain.Entities;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationTest.Mocks
{
    /*
    public class MockTipsterRepository : ITipsterRepository
    {
        public List<Tipster> Tipsters { get; private set; }
        public MockTipsterRepository(List<Tipster> tipsters)
        {
            Tipsters = tipsters;
        }
        public void InsertIntoAccount(Tipster tipster)
        {
            Tipsters.Add(tipster);
        }
        public void DeleteIntoAccount(Tipster tipster)
        {
            Tipsters.Remove(tipster);
        }
        public void ChangePassword(Tipster tipster, string newPassword)
        {
            tipster.SetPassword(newPassword);
        }
        public Tipster GetAccountById(int id)
        {
            foreach (Tipster tipster in Tipsters)
            {
                if (tipster.GetId() == id)
                {
                    return tipster;
                }
            }
            return null;
        }
        public List<Tipster> GetAllAccounts()
        {
            return Tipsters;
        }
    }
    */

}
