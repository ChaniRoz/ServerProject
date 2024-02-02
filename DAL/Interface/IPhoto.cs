using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace DAL.Interface
{
    public interface IPhoto
    {
        Task<List<Photo>> GetPhotos();
        Task<bool> PostPhotos(Photo Photo);
        Task<bool> PutPhotos(Photo Photo);
        Task<bool> DeletePhotos(int id);
    }
}
