using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity;
using Loginnmodels2.Data;
using Microsoft.EntityFrameworkCore;

namespace Loginnmodels2.DataServices
{
    public interface IGenericService<T>
    {        
        Task<T> Add(T a);          
        void Delete(T a);
    }

    public class GenericService<T> : IGenericService<T>
    {
        GenericContext _context;

        public GenericService(GenericContext ctx)
        {
            _context = ctx;
        }

        public async Task<T> Add(T a)
        {

            
            return a;
        }

        public async void Delete(T a)
        {
                      
        }


    }
}
