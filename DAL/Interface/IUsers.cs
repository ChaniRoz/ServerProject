using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace DAL.Interface
{
    public interface IUsers
    {
        Task<List<Users>> GetUsers();
        Task<bool> PostUsers(Users User);
        Task<bool> PutUsers(Users User);
        Task<bool> DeleteUsers(int id);
    }
}
