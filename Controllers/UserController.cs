
using Microsoft.AspNetCore.Mvc;
using UsermanagementService.Configuration;

namespace UsermanagementService.Controllers
{
    [ApiController]
    [Route("[controller]/api/")]
    public class UserController : ControllerBase
    {
        private readonly IPostgresClient Dataclient;


        public UserController(IPostgresClient postgresClient)
        {
            Dataclient = postgresClient;
        }

        [HttpGet("getdata")]
        public async Task<ActionResult<string>> Get()
        {
            string brand = string.Empty;

            await Dataclient.ReadData("select brand from cars", (record) =>
            {
                brand = record.GetString(0);
            });
            return Ok(brand);
        }

        [HttpPost("register")]
        public async Task<ActionResult<string>> Register()
        {
            Task.CompletedTask.Wait();
            return Ok();
        }

        [HttpGet("login")]
        public async Task<ActionResult<string>> login()
        {
            Task.CompletedTask.Wait();
            return Ok();
        }

        [HttpGet("token")]
        public async Task<ActionResult<string>> token()
        {
            Task.CompletedTask.Wait();
            return Ok();
        }


    }

}
