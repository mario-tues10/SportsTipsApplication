﻿using DataManagement.Interfaces;
using DataManagement.Entities;
using BCrypt.Net;
namespace Domain
{
    public class AdminService
    {
        private readonly IAdminRepository adminRepository;
        public AdminService(IAdminRepository adminRepository)
        {
            this.adminRepository = adminRepository;
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
            if(BCrypt.Net.BCrypt.Verify(oldPassword, admin.Password)) 
            {
                adminRepository.ChangePassword(admin, newPassword);
            }
            else
            {
                throw new Exception("Passwords don't match!");
            }
        }
        
    }
}