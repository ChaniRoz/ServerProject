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
    public class PostData : IPost
    {

        private readonly Context _context;

        public PostData(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeletePosts(int id)
        {
            var idEx = _context.Post.FirstOrDefault(x => x.Id == id);
            _context.Post.Remove(idEx);
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

        public async Task<List<Post>> GetPosts()
        {
            var res = await _context.Post.ToListAsync();
            return res;
        }

        public async Task<bool> PostPosts(Post Post)
        {
            Post exLog = new Post();
            exLog.Id = Post.Id;
            exLog.Contant=Post.Contant;
            exLog.Like=Post.Like;
            

            _context.Post.Add(exLog);

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

        public async Task<bool> PutPosts(Post Post)
        {

            var idEx = _context.Post.FirstOrDefault(x => x.Id == Post.Id);
            idEx.Id = Post.Id;
            idEx.Contant = Post.Contant;
            idEx.Like = Post.Like;
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
