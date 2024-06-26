using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.ModuleSerives;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModuleController : ControllerBase
    {
        private readonly IModuleSerives _moduleSerives;
        private readonly DataContext _context;


        public ModuleController(IModuleSerives moduleSerives,DataContext context)
        {
            _moduleSerives = moduleSerives;
            _context = context;
            
        }
     

        [HttpPost]
        public async Task<IActionResult> AddModule(ModuleDto module)
        {
            await _moduleSerives.AddModule(module);
            return Ok("add module");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllModule()
        {
            var modules = await _moduleSerives.GetAllModule();
            return Ok(modules);
        }

        [HttpGet("getModuleswithId")]
        public async Task<ActionResult<IEnumerable<Modules>>> GetModuleswithId()
        {
            return await _context.Modules.ToListAsync();
        }



        [HttpPut]
        public async Task<IActionResult> UpdateModule(ModuleDto module)
        {
            await _moduleSerives.UpdateModule(module);
            return Ok();
        }

        // New endpoint to get module statistics
        [HttpGet("statistics")]
        public async Task<IActionResult> GetModuleStatistics()
        {
            try
            {
                var statistics = await _moduleSerives.GetModuleStatistics();
                return Ok(statistics);
            }
            catch (System.Exception ex)
            {
                return StatusCode(500, "Internal server error: " + ex.Message);
            }
        }

     ///////////////////////////Reviews//////////////////////////////////////
        // Create a new review
        [HttpPost("{moduleId}/reviews")]
        public async Task<IActionResult> AddReview(int moduleId, [FromBody] ReviewDto reviewDto)
        {
            if (reviewDto == null)
            {
                return BadRequest();
            }

            var review = new Review
            {
                ModuleId = moduleId,
                Rating = reviewDto.Rating,
                ReviewText = reviewDto.Review,
                CustomerId = User.Identity.Name //  user authentication
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Read all reviews for a module
        [HttpGet("{moduleId}/reviews")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews(int moduleId)
        {
            return await _context.Reviews.Where(r => r.ModuleId == moduleId).ToListAsync();
        }

        // Update a review
        [HttpPut("reviews/{reviewId}")]
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] ReviewDto reviewDto)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return NotFound();
            }

            if (review.CustomerId != User.Identity.Name) // Ensure the customer owns the review
            {
                return Forbid();
            }

            review.Rating = reviewDto.Rating;
            review.ReviewText = reviewDto.Review;

            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();

            return Ok();
        }

        // Delete a review
        [HttpDelete("reviews/{reviewId}")]
        public async Task<IActionResult> DeleteReview(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return NotFound();
            }

            if (review.CustomerId != User.Identity.Name) // Ensure the customer owns the review
            {
                return Forbid();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return Ok();
        }


    }
}
