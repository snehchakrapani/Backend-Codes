using AssetManagementSystem.Services;
using Microsoft.AspNetCore.Mvc;

namespace AssetManagementSystem.Controllers
{

    public class RequestAssetRequest
    {
        public int SerialNumber { get; set; }
        public string AssetType { get; set; } = "";
        public string RequestedBy { get; set; } = "";
    }
    public class AddBookRequest
    {
        public string Name { get; set; } = "";
        public string Author { get; set; } = "";
        public DateTime DateOfPublish { get; set; }
    }

    public class AddSoftwareRequest
    {
        public string Name { get; set; } = "";
        public string LicenseKey { get; set; } = "";
        public DateTime ExpiryDate { get; set; }
    }

    public class AddHardwareRequest
    {
        public string Name { get; set; } = "";
        public string Manufacturer { get; set; } = "";
        public string WarrantyPeriod { get; set; } = "";
    }

    public class UpdateAssetRequest
    {
        public int SerialNumber { get; set; }
        public string AssetType { get; set; } = "";
        public string? Name { get; set; }
        public string? ExtraField1 { get; set; }
        public string? ExtraField2 { get; set; }
    }

    public class BulkUpdateAssetRequest
    {
        public string AssetType { get; set; } = "";
        public string? Name { get; set; }
        public string? ExtraField1 { get; set; }
        public string? ExtraField2 { get; set; }
    }

    public class AssignRequest
    {
        public int SerialNumber { get; set; }
        public string AssetType { get; set; } = "";
        public string UserName { get; set; } = "";
    }

    public class UnassignRequest
    {
        public int SerialNumber { get; set; }
        public string AssetType { get; set; } = "";
    }



    [ApiController]
    [Route("api/[controller]")]
    public class AssetsController : ControllerBase
    {


        private readonly AssetManager _manager;

        public AssetsController(AssetManager manager)
        {
            _manager = manager;
        }


        [HttpGet]
        public IActionResult GetAll()
        {
            var result = _manager.GetAllAssets();
            return Ok(result);
        }


        [HttpGet("search")]
        public IActionResult Search(
            [FromQuery] string assetType,
            [FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(assetType) ||
                string.IsNullOrWhiteSpace(searchTerm))
                return BadRequest(new { message = "assetType and searchTerm are required" });

            var (success, message, results) =
                _manager.SearchAsset(assetType, searchTerm);

            if (!success)
                return NotFound(new { message });

            return Ok(new { message, results });
        }


        [HttpPost("book")]
        public IActionResult AddBook([FromBody] AddBookRequest request)
        {
            var (success, message, asset) =
                _manager.AddBook(
                    request.Name,
                    request.Author,
                    request.DateOfPublish);

            if (!success)
                return BadRequest(new { message });

            return Created("", new { message, asset });
        }

        [HttpPost("request")]
        public IActionResult RequestAsset([FromBody] RequestAssetRequest request)
        {
            var (success, message) =
                _manager.RequestAsset(
                    request.SerialNumber,
                    request.AssetType,
                    request.RequestedBy);

            if (!success)
                return NotFound(new { message });

            return Ok(new { message });
        }

        [HttpPost("software")]
        public IActionResult AddSoftware([FromBody] AddSoftwareRequest request)
        {
            var (success, message, asset) =
                _manager.AddSoftware(
                    request.Name,
                    request.LicenseKey,
                    request.ExpiryDate);

            if (!success)
                return BadRequest(new { message });

            return Created("", new { message, asset });
        }


        [HttpPost("hardware")]
        public IActionResult AddHardware([FromBody] AddHardwareRequest request)
        {
            var (success, message, asset) =
                _manager.AddHardware(
                    request.Name,
                    request.Manufacturer,
                    request.WarrantyPeriod);

            if (!success)
                return BadRequest(new { message });

            return Created("", new { message, asset });
        }

        [HttpPut]
        public IActionResult Update([FromBody] UpdateAssetRequest request)
        {
            var (success, message) =
                _manager.UpdateAsset(
                    request.SerialNumber,
                    request.AssetType,
                    request.Name,
                    request.ExtraField1,
                    request.ExtraField2);

            if (!success)
                return NotFound(new { message });

            return Ok(new { message });
        }

        [HttpPut("bulk")]
        public IActionResult BulkUpdate([FromBody] BulkUpdateAssetRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.AssetType))
                return BadRequest(new { message = "AssetType is required" });

            var (success, message, updatedCount) =
                _manager.UpdateAssetsByType(
                    request.AssetType,
                    request.Name,
                    request.ExtraField1,
                    request.ExtraField2);

            if (!success)
                return NotFound(new { message });

            return Ok(new { message, updatedCount });
        }


        [HttpDelete("{assetType}/{serialNumber}")]
        public IActionResult Delete(string assetType, int serialNumber)
        {
            var (success, message) =
                _manager.DeleteAsset(serialNumber, assetType);

            if (!success)
                return NotFound(new { message });

            return Ok(new { message });
        }


        [HttpPost("assign")]
        public IActionResult Assign([FromBody] AssignRequest request)
        {
            var (success, message) =
                _manager.AssignAsset(
                    request.SerialNumber,
                    request.AssetType,
                    request.UserName);

            if (!success)
                return NotFound(new { message });

            return Ok(new { message });
        }

        [HttpPost("unassign")]
        public IActionResult Unassign([FromBody] UnassignRequest request)
        {
            var (success, message) =
                _manager.UnassignAsset(
                    request.SerialNumber,
                    request.AssetType);

            if (!success)
                return NotFound(new { message });

            return Ok(new { message });
        }
    }
}