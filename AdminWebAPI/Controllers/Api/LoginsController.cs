using AdminWebAPI.Managers;
using Microsoft.AspNetCore.Mvc;

namespace AdminWebAPI.Controllers.Api;

[ApiController]
[Route("api/[controller]")]
public class LoginsController : Controller
{
    private readonly UserManager _repo;

    public LoginsController(UserManager repo)
    {
        _repo = repo;
    }

    // PUT: api/logins/1/true (lock login)
    [HttpPut("{id}/{status}")]
    public void Put(string id, bool status)
    {
        _repo.UpdateLogin(id, status);
    }
}
