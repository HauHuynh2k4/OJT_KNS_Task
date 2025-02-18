using ManageStudent_BO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManageStudent_Service
{
    public interface IAccountService
    {
        public Account GetAccountByEmail(string email);
        public Account GetAccountByUserName(string UserName);
        public List<Account> GetAllAccount();
        public bool AddAccount(Account account);
    }
}
