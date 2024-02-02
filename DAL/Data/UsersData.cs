using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Interface;
using WebApplication1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
using Serilog;

namespace DAL.Data
{
    public class UsersData : IUsers
    {

        private readonly Context _context;

        public UsersData(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteUsers(int id)
        {
            var idEx = _context.Users.FirstOrDefault(x => x.Id == id);
            _context.Users.Remove(idEx);
            try
            {
                var isOK = _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Users>> GetUsers()
        {
            var res = await _context.Users.ToListAsync();
            return res;
        }

        public async Task<bool> PostUsers(Users Users)
        {
            Users exLog = new Users();
            exLog.Id = Users.Id;
            exLog.Name = Users.Name;
            exLog.Addres = Users.Addres;
            exLog.Email=Users.Email;
            exLog.Phone=Users.Phone;

            _context.Users.Add(exLog);

            try
            {
                var isOK = _context.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> PutUsers(Users Users)
        {

            var idEx = _context.Users.FirstOrDefault(x => x.Id == Users.Id);
            idEx.Id = Users.Id;
            idEx.Name = Users.Name;
            idEx.Addres = Users.Addres;
            idEx.Email = Users.Email;
            idEx.Phone = Users.Phone;
            try
            {
                var isOK = _context.SaveChanges() > 0;

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
