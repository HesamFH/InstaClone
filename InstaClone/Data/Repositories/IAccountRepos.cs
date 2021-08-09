using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InstaClone.Models;

namespace InstaClone.Data.Repositories
{

    public interface IAccountRepos
    {
        bool IsUserNameExists(string userName);

        bool IsEmailExists(string email);

        Users GetUserForLogin(string email, string password);

        void AddUser(Users user);
    }

    public class AccountRepos : IAccountRepos
    {
        private InstaDbContext _context;

        public AccountRepos(InstaDbContext context)
        {
            _context = context;
        }

        public bool IsUserNameExists(string userName)
        {
            return _context.Users.Any(u => u.Username == userName);
        }

        public bool IsEmailExists(string email)
        {
            return _context.Users.Any(u => u.Email == email);
        }

        public void AddUser(Users user)
        {
            _context.Add(user);
            _context.SaveChanges();
        }

        public Users GetUserForLogin(string email, string password)
        {
            return _context.Users.SingleOrDefault(u => u.Email == email && u.Password == password);
        }
    }
}
