using AdminWebAPI.Data;
using AdminWebAPI.Models;
using Microsoft.EntityFrameworkCore;
using AdminWebAPI.DTO;

namespace AdminWebAPI.Managers;

public class UserManager
{
    private readonly PatientConnectContext _context;

    public UserManager(PatientConnectContext context) => _context = context;

    public IEnumerable<User> GetUsers() => 
        _context.Users.Include(x => x.UserID).ToList();

    public IEnumerable<User> GetUser(int id) =>
        _context.Users.Where(x => x.UserID == id).ToList();
    

    public void UpdateUser(int id, UserDto input)
    {
        // look up user by id
        var user = _context.Users.Find(id);

        // modify user details + save
        user.City = input.City;
        user.PostCode = input.PostCode;
        user.Email = input.Email;
        user.Age = input.Age;
        user.ProviderNumber = input.ProviderNumber;
        _context.SaveChanges();
    }

    public void UpdateLogin(string id, bool status)
    {
        // look up login id
        var login = _context.Logins.Find(id);

        // update login (locked/unlocked) + save
        //login.Locked = status;
        _context.SaveChanges();
    }
}
