using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Loginnmodels2.Data;
using Microsoft.EntityFrameworkCore;

namespace Loginnmodels2.DataServices
{
    public interface IPageService
    {
        Task<List<Data.Pages>> Get();
        Task<Data.Pages> Add(Data.Pages a);
    }

    public class PageDataService : IPageService
    {
        private readonly dbcontext1 _context;

        public PageDataService(dbcontext1 contexto)
        {
            _context = contexto;
        }

        public async Task<List<Data.Pages>> Get()
        {
            return await _context.Paginas.ToListAsync();
        }

        public async Task<Data.Pages> Add(Data.Pages a)
        {
            _context.Paginas.Add(a);
            await _context.SaveChangesAsync();
            return a;
        }
    }
}
