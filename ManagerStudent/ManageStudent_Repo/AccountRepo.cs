using ManageStudent_BO.Models;
using ManageStudent_DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Repo
{
    public class AccountRepo : IAccountRepo
    {
        public bool AddAccount(Account account)
        {
            return AccountDAO.Instance.AddAccount(account);
        }

        public Account GetAccountByEmail(string email)
        {
            return AccountDAO.Instance.GetAccountByEmail(email);
        }

        public Account GetAccountByUserName(string UserName)
        {
            return AccountDAO.Instance.GetAccountByUserName(UserName);
        }

        public List<Account> GetAllAccount()
        {
            return AccountDAO.Instance.GetAllAccount();
        }
    }
}
