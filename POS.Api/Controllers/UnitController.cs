using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Domain.Models.Result;

namespace POS.Api.Controllers
{
    [EnableCors("AllowedOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class UnitController : ControllerBase
    {
        private readonly ILogger<UnitController> _logger;
        private readonly IUnitRepository _UnitRepository;

        public UnitController(ILogger<UnitController> logger, IUnitRepository UnitRepository)
        {
            _logger = logger;
            _UnitRepository = UnitRepository;
        }

        [HttpGet("{profile}")]
        public ActionResult<List<Unit>> Get(string profile)
        {
            try
            {
                var results = _UnitRepository.GetByProfile(profile);
                if (results == null) return NotFound();
                return this.Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return this.StatusCode(500, ex.Message);

            }
        }

        [HttpGet("{code}/{profile}")]
        public ActionResult Get(string code, string profile)
        {
            try
            {
                var results = _UnitRepository.GetByCode(code, profile);
                if (results == null) return NotFound();
                return this.Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return this.StatusCode(500, ex.Message);
            }
        }

        //[HttpGet("Paging/{pageIndex}/{pageSize}")]


        [HttpGet("{pageIndex}/{pageSize}/{profile}")]
        public async Task<ActionResult<PagingResult<Usp_GetUnitPagingResult>>> GetDataPaging(int pageIndex = 1, int pageSize = 10, string profile="")
        {
            try
            {
                var results = await _UnitRepository.GetDataPaging(pageIndex, pageSize, profile);
                if (results == null) return NotFound();
                return this.Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        public ActionResult Save(Unit item)
        {
            try
            {
                var results = _UnitRepository.Save(item);
                return this.Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{code}/{profile}")]
        public IActionResult Delete(string code,string profile)
        {
            try
            {
                var results = _UnitRepository.Delete(code,  profile);
                return this.Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }
    }
}
