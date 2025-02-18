using ManageStudent.Models;
using ManageStudent_BO.Models;
using ManageStudent_Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System;
using System.Text.RegularExpressions;

namespace ManageStudent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IAccountService IaccountService;
        public AccountController(IAccountService accountService)
        {
            this.IaccountService = accountService;
        } 
        [HttpPost("Login")]
        public IActionResult Login(LoginDTO loginDTO)
        {
            var account = IaccountService.GetAccountByUserName(loginDTO.usernameOrEmail);
            var account2 = IaccountService.GetAccountByEmail(loginDTO.usernameOrEmail);

            if ((account == null && account2 == null) ||
                (account != null && account.Password != loginDTO.password) ||
                (account2 != null && account2.Password != loginDTO.password))
            {
                return Unauthorized("Thông tin đăng nhập không hợp lệ");
            }
            if (account != null)
            {
                return Ok(account);
            }

            if (account2 != null)
            {
                return Ok(account2);
            }

            return Unauthorized("Thông tin đăng nhập không hợp lệ");
        }
        [HttpPost("Register")]
        public IActionResult Register([FromBody] RegisterDTO newAccount)
        {
            if (IaccountService.GetAccountByEmail(newAccount.email) != null) 
            {
                return BadRequest("Email đã tồn tại");
            }
            if (IaccountService.GetAccountByUserName(newAccount.username) != null)
            {
                return BadRequest("Tài khoản đã tồn tại");
            }
            string emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            if (!Regex.IsMatch(newAccount.email, emailPattern))
            {
                return BadRequest("Email không đúng định dạng");
            }
            Account n = new Account();
            n.Username = newAccount.username;
            n.Password = newAccount.password;
            n.Email = newAccount.email;
            n.Role = "Teacher";
            if (IaccountService.AddAccount(n))
            {
                return Ok(n);
            }
            else
            {
                return BadRequest("Tạo tài khoản thất bại");
            }
        }
        [HttpGet("GetAllAccount")]
        public IActionResult GetAllAccount() 
        {
            try
            {
                var listAccount = IaccountService.GetAllAccount();
                if (listAccount == null)
                {
                    return NotFound("Không có tài khoản nào");
                }
                return Ok(listAccount);
            }
            catch (Exception ex) 
            {
                return StatusCode(500, $"Lỗi server: {ex.Message}");
            }
        }
        [HttpPost("Logout")]
        public IActionResult Logout()
        {
            return Ok("Đăng xuất thành công");
        }
    }
}
