using BookingApp.Business.Operations.Setting;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BookingApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SettingsController : ControllerBase
    {
        private readonly ISettinService _settingService;

        public SettingsController(ISettinService settingService)
        {
            _settingService = settingService;
        }
        [HttpPatch]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> ToggleMaintenance()
        {
            await _settingService.ToggleMaintenance();

            return Ok();
        }
    }
}
