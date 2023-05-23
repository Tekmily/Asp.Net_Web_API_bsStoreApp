using Entities.DataTransferObjects;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Presentation.ActionFiltters;
using Services.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public CategoriesController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllCategoriesAsync()
        {
            return Ok(await _serviceManager
                .CategoryService
                .GetAllCategoriesAsync(false));
        }
        [Authorize]
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetAllCategoriesAsync([FromRoute] int id)
        {
            return Ok(await _serviceManager
                .CategoryService
                .GetOneCategoryByIdAsync(id, false));
        }

    }
}
