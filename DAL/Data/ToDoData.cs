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
    public class ToDoData : IToDo
    {

        private readonly Context _context;

        public ToDoData(Context context)
        {
            _context = context;
        }

        public async Task<bool> DeleteToDos(int id)
        {
            var idEx = _context.ToDo.FirstOrDefault(x => x.Id == id);
            _context.ToDo.Remove(idEx);
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

        public async Task<List<ToDo>> GetToDos()
        {
            var res = await _context.ToDo.ToListAsync();
            return res;
        }

        public async Task<bool> PostToDos(ToDo toDo)
        {
            ToDo exLog = new ToDo();
            exLog.Id = toDo.Id;
            exLog.Name = toDo.Name;
            exLog.CreateDate = DateTime.Now;
            exLog.Complated = toDo.Complated;

            _context.ToDo.Add(exLog);

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

        public async Task<bool> PutToDos(ToDo toDo)
        {

            var idEx = _context.ToDo.FirstOrDefault(x => x.Id == toDo.Id);
            idEx.Name = toDo.Name;
            idEx.Id = toDo.Id;
            idEx.CreateDate = DateTime.Now;
            idEx.Complated = toDo.Complated;
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
