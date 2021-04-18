using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalRMaster.Hubs;
using System;
using System.Threading.Tasks;

namespace SignalRMaster.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationHubController : ControllerBase
    {
        private readonly IHubContext<NotificationHub> _hubClient;

        public NotificationHubController(IHubContext<NotificationHub> hubContext)
        {
            _hubClient = hubContext;
        }

        [HttpGet]
        public async Task<IActionResult> SendMessage()
        {
            await _hubClient.Clients.All.SendAsync("Event", $"Event at {DateTime.Now}");
            return Ok();
        }
    }
}
