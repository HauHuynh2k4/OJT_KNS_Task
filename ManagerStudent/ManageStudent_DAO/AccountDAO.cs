using ManageStudent_BO.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_DAO
{
    public class AccountDAO
    {
        private ManageStudentDemoContext DBcontext;
        private static AccountDAO instance = null;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();

                }
                return instance;
            }
        }
        public AccountDAO()
        {
            DBcontext = new ManageStudentDemoContext();
        }
        public Account GetAccountByEmail(string email) => DBcontext.Accounts.SingleOrDefault(a => a.Email.Equals(email));
        public Account GetAccountByUserName(string UserName) => DBcontext.Accounts.SingleOrDefault(a => a.Username.Equals(UserName));
        public List<Account> GetAllAccount()  => DBcontext.Accounts.ToList();
        public bool AddAccount(Account account) 
        {
            try
            {
                var existingAccount = GetAccountByEmail(account.Email);
                var existingAccount2 = GetAccountByUserName(account.Username);
                if (existingAccount != null && existingAccount2 !=null)
                {
                    return false;
                }
                DBcontext.Accounts.Add(account);
                return DBcontext.SaveChanges() > 0;
            }
            catch (Exception ex)
            {
                throw new Exception("An error occurred while Adding the Account: " + ex.Message);
            }
        }
    }
}
