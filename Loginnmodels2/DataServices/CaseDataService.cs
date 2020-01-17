using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Loginnmodels2.Data;
using Microsoft.EntityFrameworkCore;

namespace Loginnmodels2.DataServices
{
    public interface ICaseDataService
    {
        Task<List<Data.Case>> Get();
        Task<Data.Case> Add(Data.Case a);
        Task<Data.Case> Update(Data.Case a);
        Task<List<Case>> GetAllCases();
        void Delete(Data.Case a);
        Task ToggleUserInCase(Case c, User u);
    }

    public class CaseDataService : ICaseDataService
    {
        dbcontext1 _context;

        public CaseDataService(dbcontext1 ctx)
        {
            _context = ctx;
        }

        public async Task<List<Data.Case>> Get()
        {
            return await _context.Cases.ToListAsync();
        }

        public async Task<Data.Case> Add(Data.Case a)
        {
            _context.Cases.Add(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async Task<Case> Update(Data.Case a)
        {
            _context.Entry(a).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return a;
        }

        public async void Delete(Data.Case a)
        {
            _context.Cases.Remove(a);
            await _context.SaveChangesAsync();            
        }

        private IQueryable<Case> GetAllCasesQueryable()
        {
            return _context.Cases.AsQueryable();
        }

        public async Task<List<Case>> GetAllCases()
        {
            return await GetAllCasesQueryable().ToListAsync();
        }

        public async Task ToggleUserInCase(Case c, User u)
        {
            var cases = _context.UserCaseRelation.AsQueryable();
            if (cases.Where(x => x.usr == u && x.connected_case == c).Any())
            {
                _context.UserCaseRelation.Remove(cases.Where(x => x.usr == u && x.connected_case == c).FirstOrDefault());
                _context.SaveChanges();
            }else
            {
                UserHasCases var_UserHasCases = new UserHasCases();
                var_UserHasCases.usr = u;
                var_UserHasCases.connected_case = c;
                _context.UserCaseRelation.Add(var_UserHasCases);
                _context.SaveChanges();

            }

            await Task.CompletedTask;
        }

    }
}
