using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using WebApi.Entities.Models;
using WebApi.Entities.WebApi.Entities;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EfTestController : Controller
    {
        private readonly ApplicationDbContext _dbContext;

        public EfTestController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        [HttpGet("read")]
        public IActionResult Read()
        {
            var top5 = _dbContext.EfTests.ToList().Take(5);
            return Ok(top5);
        }

        [HttpGet("insert")]
        public IActionResult Insert()
        {
            _dbContext.EfTests.Add(new EfTest
            {
                StartDate = DateTime.Now
            });
            _dbContext.SaveChanges();
            return Ok("Inserted 1 record successfully.");
        }
    }
}