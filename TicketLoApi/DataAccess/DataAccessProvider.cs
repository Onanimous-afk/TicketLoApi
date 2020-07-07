using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TicketLoApi.Models;
using TicketLoApi.Controllers;

namespace TicketLoApi.DataAccess
{
    public class DataAccessProvider : IDataAccessProvider
    {
        private readonly PostgresSqlContext _context;
        private readonly TokenController _token;
        public DataAccessProvider(PostgresSqlContext context, TokenController token) 
        {
            _context = context;
            _token = token;
        }

        public systemuser DetailUser(Guid systemuserid)
        {
            return _context.systemuser.FirstOrDefault(p => p.systemuserid == systemuserid);
        }

        public List<systemuser> GetAllUser()
        {
            return _context.systemuser.ToList();
        }

        public Login Login(string email, string password)
        {
            try 
            {
                Login detail = new Login();
                var aksi = _context.systemuser.FirstOrDefault(p => p.email == email && p.password == password);
                if (aksi != null)
                {
                    detail.Systemuserid = aksi.systemuserid;
                    detail.Fullname = aksi.fullname;
                    detail.Email = aksi.email;
                    detail.Password = aksi.password;
                    detail.Token = _token.GetRandomToken(email);
                }
                return detail;
            } 
            catch (Exception ex) 
            { 
                throw ex; 
            }
            
            //throw new NotImplementedException();
        }

        public bool RegisterUser(string fullname, string email, string password) 
        {
            try 
            {
                var data = _context.systemuser.Where(p => p.email == email).FirstOrDefault();
                if (data == null)
                {
                    systemuser su = new systemuser();
                    su.fullname = fullname;
                    su.email = email;
                    su.password = password;
                    su.createdon = DateTime.Now;
                    su.createdby = fullname;
                    su.modifiedon = DateTime.Now;
                    su.modifiedby = fullname;
                    su.statuscode = 0;

                    _context.systemuser.Add(su);
                    _context.SaveChanges();

                    Guid lastid = su.systemuserid;

                    systemuserrole sr = new systemuserrole();
                    sr.systemuserid = lastid;
                    sr.roleid = new Guid("3edace78-cc1d-47c1-8e32-8356b2b0aa48");
                    sr.createdon = DateTime.Now;
                    sr.createdby = fullname;
                    sr.modifiedon = DateTime.Now;
                    sr.modifiedby = fullname;

                    _context.systemuserrole.Add(sr);
                    _context.SaveChanges();

                    return true;
                }
                else 
                {
                    return false;
                }               

            }
            catch (Exception ex) 
            {
                throw ex;
                //return false;
            }

        }
        public GetForgotResult ForgotPassword(string email) 
        {
            GetForgotResult res = new GetForgotResult();
            try 
            {
                var data = _context.systemuser.Where(p => p.email == email).FirstOrDefault();
                if (data != null)
                {
                    res.email = data.email;
                    res.fullname = data.fullname;
                    return res;
                }
                else
                {
                    return res;
                }
            }catch(Exception ex) 
            {
                throw ex;
            }
            
        }

        public void UpdateProfile(systemuser systemuser)
        {
            throw new NotImplementedException();
        }
    }
}
