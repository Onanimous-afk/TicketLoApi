using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TicketLoApi.Models
{
    public class systemuser
    {
        [Key]
        public Guid systemuserid { get; set; }
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
        public int statuscode { get; set; }
        public DateTime createdon { get; set; }
        public string createdby { get; set; }
        public DateTime modifiedon { get; set; }
        public string modifiedby { get; set; }
    }
    public class LoginParam
    {
        public string email { get; set; }
        public string password { get; set; }
    }
    public class Login
    {
        [Key]
        public Guid Systemuserid { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int StatusCode { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime ModifiedOn { get; set; }
        public string Token { get; set; }
    }
    public class LoginResult 
    {
        public string Status { get; set; }
        public Login Data { get; set; }
        public string Message { get; set; }
    }
    public class SystemuserParam
    {
        public string fullname { get; set; }
        public string email { get; set; }
        public string password { get; set; }
    }
    public class RegisterResult
    {
        public string Status { get; set; }
        public Login Data { get; set; }
        public string Message { get; set; }
    }
    public class ForgotResult 
    {
        public string Status { get; set; }
        public Login Data { get; set; }
        public string Message { get; set; }
    }
    public class ForgotParam
    {
        public string email { get; set; }
    }
    public class GetForgotResult
    {
        public string fullname { get; set; }
        public string email { get; set; }
    }

}
