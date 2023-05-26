using System.Diagnostics;
using UserAPI.Interfaces;
using UserAPI.Models;

namespace UserAPI.Services
{
    public class UserRepo : IUser<int,User>
    {
        private readonly JWTUserContext _context;

        public UserRepo(JWTUserContext context)
        {
            _context = context;
        }

        public User Add(User item)
        {
            try
            {
                _context.Users.Add(item);
                _context.SaveChanges();
                return item;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                Debug.WriteLine(item);
            }
            return null;
        }

        public User Delete(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(u => u.UserId == id);
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return null;
        }

        public User Get(int id)
        {
            var user = _context.Users.FirstOrDefault(u => u.UserId == id);
            return user;
        }

        public ICollection<User> GetAll()
        {
            var user= _context.Users.ToList();
            if (user.Count > 0)
                return user; 
            return null;
        }

        public User Update(User item)
        {
            var user = _context.Users.FirstOrDefault(u => u.Username == item.Username);
            if (user != null)
            {
                user.Password=item.Password;
                user.Name=item.Name;
                user.Email=item.Email;
                user.PhoneNumber=item.PhoneNumber;
                user.Age=item.Age;
                _context.Users.Update(user);
                _context.SaveChanges();
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}
