using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
//using System.Data.Entity;
using Loginnmodels2.Data;
using Microsoft.EntityFrameworkCore;

namespace Loginnmodels2.DataServices
{
    public interface IUserDataService
    {
        Task<List<Data.User>> Get();
        Task<Data.User> Get(string usr_name);
        Task<Data.User> Add(Data.User a);   
        Task<List<Data.UserHasCases>> GetCases(User param_usr);
        
        void Delete(Data.User a);
    }

    public class UserDataService : IUserDataService
    {
        dbcontext1 _context;

        public UserDataService(dbcontext1 ctx)
        {
            _context = ctx;
        }

        public async Task<List<Data.User>> Get()
        {
            return await _context.Users.ToListAsync();
        }

        public async Task<Data.User> Get(string usr_name)
        {
            return await GetAllUsers().Where(x => x.user_name == usr_name).FirstOrDefaultAsync();
        }

        public async Task<Data.User> Add(Data.User a)
        {
            _context.Users.Add(a);
            await _context.SaveChangesAsync();
            return a;
        }

        public async void Delete(Data.User a)
        {
            _context.Users.Remove(a);
            await _context.SaveChangesAsync();            
        }

        public IQueryable<User> GetAllUsers()
        {
            return _context.Users.AsQueryable();
        }

        private IQueryable<UserHasCases> GetAllCases()
        {
            return _context.UserCaseRelation.AsQueryable();
        }

        public async Task<List<Data.UserHasCases>> GetCases(User param_usr)
        {
            return await GetAllCases().Where(x => x.usr == param_usr).ToListAsync();
        }

        public async Task<List<Data.UserHasCases>> GetAllValidCases()
        {
            return await GetAllCases().Where(x => x.connected_case.is_valid == true).ToListAsync();
        }

    }
}
