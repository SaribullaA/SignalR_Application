using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using SignalR_Application.Hubs;

namespace SignalR_Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hub;
        public NotificationController(IHubContext<ChatHub> hub)
        {
            _hub = hub;
        }
        [HttpPost]
        public async Task<IActionResult> Send( string msg)
        {
            await _hub.Clients.All.SendAsync("ReceiveMessage", "API", msg);

            return Ok("Sent");
        }

    }
}
