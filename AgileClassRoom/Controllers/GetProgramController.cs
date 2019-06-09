using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using AgileClassRoom.Interface;
using AgileClassRoom.ViewModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AgileClassRoom.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GetProgramController : ControllerBase
    {
        private readonly IProgram _program;
        private readonly ICoordinator _coordinator;
        public GetProgramController(IProgram program, ICoordinator coordinator)
        {

            _program = program;
            _coordinator = coordinator;
        }
        [HttpGet]
        public IEnumerable<ProgramViewModel> Get()
        {
            int userId = Convert.ToInt32(this.User.FindFirstValue(ClaimTypes.Name));
            int coorid = _coordinator.GetCoordinatorId(userId);

            return _program.GetAllProgramsOfCoordinator(coorid);
        }
    }
}