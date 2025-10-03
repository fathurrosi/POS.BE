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
    public class ProductController : ControllerBase
    {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductRepository _ProductRepository;

        public ProductController(ILogger<ProductController> logger, IProductRepository ProductRepository)
        {
            _logger = logger;
            _ProductRepository = ProductRepository;
        }

        [HttpGet("{profile}")]
        public ActionResult<List<Product>> Get(string profile)
        {
            try
            {
                var results = _ProductRepository.GetByProfile(profile);
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
                var results = _ProductRepository.GetByCode(code, profile);
                if (results == null) return NotFound();
                return this.Ok(results);

            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return this.StatusCode(500, ex.Message);
            }
        }

        [HttpGet("{pageIndex}/{pageSize}/{profile}")]
        public async Task<ActionResult<PagingResult<Usp_GetProductPagingResult>>> GetDataPaging(string profile,int pageIndex = 1, int pageSize = 10)
        {
            try
            {
                var results = await _ProductRepository.GetDataPaging(pageIndex, pageSize, profile);
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
        public ActionResult Save(Product item)
        {
            try
            {
                var results = _ProductRepository.Save(item);
                return this.Ok(results);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
                return StatusCode(500, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string code, string profile)
        {
            try
            {
                var results = _ProductRepository.Delete(code, profile);
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
