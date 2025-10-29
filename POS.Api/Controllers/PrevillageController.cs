﻿using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using POS.Application.Interfaces.Repositories;
using POS.Domain.Entities;
using POS.Infrastructure.Repositories;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace POS.Api.Controllers
{
    [EnableCors("AllowedOrigins")]
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PrevillageController : ControllerBase
    {
        private readonly ILogger<PrevillageController> _logger;
        private readonly IPrevillageRepository _previllageRepository;

        public PrevillageController(ILogger<PrevillageController> logger, IPrevillageRepository previllageRepository)
        {
            _logger = logger;
            _previllageRepository = previllageRepository;
        }

        [HttpGet("{username}")]
        public async Task<List<VUserPrevillage>> Get(string username)
        {
            List<VUserPrevillage> items = new List<VUserPrevillage>();
            try
            {
                items =await _previllageRepository.GetByUsername(username);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return items;
        }

        [HttpGet("{role}/{profile}")]
        public async Task<List<Usp_GetPrevillageByProfileRoleResult>> Get(int role, string profile)
        {
            List<Usp_GetPrevillageByProfileRoleResult> items = new List<Usp_GetPrevillageByProfileRoleResult>();
            try
            {
                items = await _previllageRepository.GetByProfileRole(profile, role);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.ToString());
            }

            return items;
        }
    }
}
