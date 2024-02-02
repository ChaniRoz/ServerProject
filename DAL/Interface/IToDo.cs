using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApplication1.Models;
namespace DAL.Interface
{
    public interface IToDo
    {
        Task<List<ToDo>> GetToDos();
        Task<bool> PostToDos(ToDo toDo);
        Task<bool> PutToDos(ToDo toDo);
        Task<bool> DeleteToDos(int id);
    }
}
