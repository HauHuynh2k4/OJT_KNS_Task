using ManageStudent_BO.Models;
using ManageStudent_Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Service
{
    public class AccountService : IAccountService
    {
        private IAccountRepo iaccountRepo;
        public AccountService()
        {
            iaccountRepo = new AccountRepo();
        }
        public bool AddAccount(Account account)
        {
            return iaccountRepo.AddAccount(account);
        }

        public Account GetAccountByEmail(string email)
        {
            return iaccountRepo.GetAccountByEmail(email);
        }

        public Account GetAccountByUserName(string UserName)
        {
            return iaccountRepo.GetAccountByUserName(UserName);
        }

        public List<Account> GetAllAccount()
        {
            return iaccountRepo.GetAllAccount();
        }
    }
}
