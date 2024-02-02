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
    public class PhotoData : IPhoto
    {

        private readonly Context _photoContext;

        public PhotoData(Context context)
        {
            _photoContext = context;
        }

        public async Task<bool> DeletePhotos(int id)
        {
            var idEx = _photoContext.Photo.FirstOrDefault(x => x.Id == id);
            _photoContext.Photo.Remove(idEx);
            try
            {
                var isOK = _photoContext.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<List<Photo>> GetPhotos()
        {
            var res = await _photoContext.Photo.ToListAsync();
            return res;
        }

        public async Task<bool> PostPhotos(Photo Photo)
        {
            Photo exLog = new Photo();
            exLog.Id = Photo.Id;
            exLog.ImgURL = Photo.ImgURL;
            _photoContext.Photo.Add(exLog);

            try
            {
                var isOK = _photoContext.SaveChanges() > 0;
            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }

        public async Task<bool> PutPhotos(Photo Photo)
        {

            var idEx = _photoContext.Photo.FirstOrDefault(x => x.Id == Photo.Id);
            idEx.Id = Photo.Id;
            idEx.ImgURL = Photo.ImgURL;
            try
            {
                var isOK = _photoContext.SaveChanges() > 0;

            }
            catch (Exception e)
            {
                return false;
            }
            return true;
        }
    }
}
