using Microsoft.AspNetCore.Mvc;

namespace SudokerSolver.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SolverController : ControllerBase
    {

        [HttpPost("solve")]
        public Task<IActionResult> Solve(
            [FromBody] string str
        )
        {


        }
    }
}