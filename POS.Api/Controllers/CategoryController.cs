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
    public class CategoryController : ControllerBase
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ICategoryRepository _CategoryRepository;

        public CategoryController(ILogger<CategoryController> logger, ICategoryRepository CategoryRepository)
        {
            _logger = logger;
            _CategoryRepository = CategoryRepository;
        }

        [HttpGet("{profile}")]
        public ActionResult<List<Category>> Get(string profile)
        {
            try
            {
                var results = _CategoryRepository.GetByProfile(profile);
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
                var results = _CategoryRepository.GetByCode(code, profile);
                if (results == null) return NotFound();
                return this.Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet("Paging/{pageIndex}/{pageSize}")]
        public async Task<ActionResult<PagingResult<Usp_GetCategoryPagingResult>>> GetDataPaging(int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var results = await _CategoryRepository.GetDataPaging(pageIndex, pageSize);
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
        public ActionResult Save(Category item)
        {
            try
            {
                var results = _CategoryRepository.Save(item);
                return this.Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var results = _CategoryRepository.Delete(id);
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
