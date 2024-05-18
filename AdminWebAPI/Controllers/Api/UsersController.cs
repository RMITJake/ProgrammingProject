using AdminWebAPI.DTO;
using AdminWebAPI.Managers;
using AdminWebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace AdminWebAPI.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class UsersController : Controller
{
    private readonly UserManager _repo;

    public UsersController(UserManager repo)
    {
        _repo = repo;
    }

    // GET: api/users (get all users)
    [HttpGet]
    public IEnumerable<User> Get()
    {
        return _repo.GetUsers();
    }

    // GET: api/users/1 (get user by id)
    [HttpGet("{id}")]
    public IEnumerable<User> Get(int id)
    {
        return _repo.GetUser(id);
    }

    // PUT: api/users (modify user)
    [HttpPut]
    public void Put([FromBody] UserDto user)
    {
        _repo.UpdateUser(user.UserID, user);
    }
}
