using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatingApp.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DatingApp.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ValuesController : ControllerBase
    {
        private readonly DataContext _context;
        public ValuesController(DataContext context)
        {
            _context = context;
        }

        /* synchronous, always use asynchronous 
        public IActionResult GetValues() 
        {
            var values = _context.Values.ToList();
            return Ok(values);
        }
        */

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> GetValues() 
        {
            var values = await _context.Values.ToListAsync();
            return Ok(values);
        }

         // GET api/values/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetValue(int id) 
        {
            var value = await _context.Values.FirstOrDefaultAsync(x => x.Id == id);
            return Ok(value);
        }
    }
}
