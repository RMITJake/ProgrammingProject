using AdminWebAPI.DTO;
using AdminWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace AdminWebAPI.Controllers;

public class ProfileController : Controller
{
    private readonly IHttpClientFactory _clientFactory;
    private HttpClient Client => _clientFactory.CreateClient();

    public ProfileController(IHttpClientFactory clientFactory) => _clientFactory = clientFactory;

    public async Task<IActionResult> Index()
    {
        // Get all users
        var response = await Client.GetStringAsync("api/users");
        var users = JsonConvert.DeserializeObject<List<User>>(response);

        return View(users);
    }

    public async Task<IActionResult> Modify(int id)
    {
        // Get user by id
        var response = await Client.GetStringAsync($"api/users/{id}");
        var users = JsonConvert.DeserializeObject<List<UserDto>>(response);

        return View(users[0]);
    }

    [HttpPost]
    public async Task<IActionResult> Modify(UserDto input)
    {
        // validate
        if (!ModelState.IsValid)
        {
            var response = await Client.GetStringAsync($"api/users/{input.UserID}");
            var users = JsonConvert.DeserializeObject<List<UserDto>>(response);
            return View(users[0]);
        }

        // update db and save changes
        var content = new StringContent(JsonConvert.SerializeObject(input), Encoding.UTF8, "application/json");
        await Client.PutAsync("api/users", content);

        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> Lock(string id)
    {
        // Lock user login
        await Client.PutAsync($"api/logins/{id}/{true}", null);
        return RedirectToAction(nameof(Index));
    }

    public async Task<IActionResult> UnLock(string id)
    {
        // Unlock user login
        await Client.PutAsync($"api/logins/{id}/{false}", null);
        return RedirectToAction(nameof(Index));
    }
}
