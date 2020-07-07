using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketLoApi.Models;

namespace TicketLoApi.DataAccess
{
    public interface IDataAccessProvider
    {
        bool RegisterUser(string fullname,string email, string password);
        void UpdateProfile(systemuser systemuser);
        Login Login(string email, string password);
        systemuser DetailUser(Guid systemuserid);
        List<systemuser> GetAllUser();
        GetForgotResult ForgotPassword(string email);

    }
}
