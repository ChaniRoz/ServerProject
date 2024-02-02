using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace DAL.Interface
{
    public interface IPost
    {
        Task<List<Post>> GetPosts();
        Task<bool> PostPosts(Post Post);
        Task<bool> PutPosts(Post Post);
        Task<bool> DeletePosts(int id);
    }
}
