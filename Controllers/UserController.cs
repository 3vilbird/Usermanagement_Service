
using Microsoft.AspNetCore.Mvc;
using UsermanagementService.Configuration;

namespace UsermanagementService.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IPostgresClient Dataclient;


        public UserController(IPostgresClient postgresClient)
        {
            Dataclient = postgresClient;
        }

        [HttpGet("/getdata")]
        public async Task<ActionResult<string>> Get()
        {
            string brand = string.Empty;

            await Dataclient.ReadData("select brand from cars", (record) =>
            {
                brand = record.GetString(0);
            });
            return Ok(brand);
        }
    }

}
