using ElevatorControl.Application.Services;
using ElevatorControl.Domain.Entitties;
using ElevatorControl.Domain.Entitties.Request;
using Microsoft.AspNetCore.Mvc;

namespace ElevatorControl.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class ElevatorController : ControllerBase
    {
        private readonly ElevatorService _svc;
        public ElevatorController(ElevatorService svc)
        {
            this._svc = svc;
        }
        [HttpGet("status")]
        public ActionResult<ElevatorState> Status() => Ok(_svc.GetState());

        [HttpPost("call")]
        public IActionResult Call([FromBody] ElevatorRequest req)
        {
            _svc.CallElevator(req.DestinationFloor);
            return NoContent();
        }

        [HttpPost("open")] public IActionResult Open() { _svc.OpenDoors(); return NoContent(); }
        [HttpPost("close")] public IActionResult Close() { _svc.CloseDoors(); return NoContent(); }

        [HttpPost("start")] public IActionResult Start() { _svc.Start(); return NoContent(); }
        [HttpPost("stop")] public IActionResult Stop() { _svc.Stop(); return NoContent(); }
    }
}
