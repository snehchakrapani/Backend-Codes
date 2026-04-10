using Microsoft.AspNetCore.Mvc;

namespace AssetManagementAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {
        
        private static List<string> assets = new List<string>
        {
            "Laptop",
            "Harry Potter",
            "VS Code License"
        };

        [HttpGet]
        public IActionResult GetAll()
        {
            return Ok(assets);
        }
    }
}