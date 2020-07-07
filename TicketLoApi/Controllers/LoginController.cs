using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TicketLoApi.DataAccess;
using TicketLoApi.Models;
using System.Security.Cryptography;
using System.Text;

namespace TicketLoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IDataAccessProvider _dataAccessProvider;

        public LoginController(IDataAccessProvider dataAccessProvider)
        {
            _dataAccessProvider = dataAccessProvider;
        }

        [HttpPost]
        public LoginResult Login([FromBody] LoginParam pr)
        {
            LoginResult res = new LoginResult();
            var password = MD5Hash(pr.password);
            if (ModelState.IsValid)
            {
                res.Status = "OK";
                res.Data = _dataAccessProvider.Login(pr.email, password);
                res.Message = "Login Success";                
            }
            else 
            {
                res.Status = "NG";
                res.Data = null;
                res.Message = "Login Failed";
            }
            return res;
        }
        public static string MD5Hash(string text)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            //compute hash from the bytes of text  
            md5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(text));

            //get hash result after compute it  
            byte[] result = md5.Hash;

            StringBuilder strBuilder = new StringBuilder();
            for (int i = 0; i < result.Length; i++)
            {
                //change it into 2 hexadecimal digits  
                //for each byte  
                strBuilder.Append(result[i].ToString("x2"));
            }

            return strBuilder.ToString();
        }

    }
}
    