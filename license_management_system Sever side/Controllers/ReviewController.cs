using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.ReviewServices;
using license_management_system_Sever_side.Data;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewServices;
        private readonly DataContext _context;

        public ReviewController(IReviewServices reviewServices, DataContext context)
        {
            _reviewServices = reviewServices;
            _context = context;
        }

        // Create a new review

        [HttpPost("{moduleId}/reviews")]
        public async Task<IActionResult> AddReview(int moduleId, [FromBody] ReviewDto reviewDto, [FromHeader] string userId)
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
                CustomerId = userId
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
        public async Task<IActionResult> UpdateReview(int reviewId, [FromBody] ReviewDto reviewDto, [FromHeader] string userId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return NotFound();
            }

            if (review.CustomerId != userId)
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
        public async Task<IActionResult> DeleteReview(int reviewId, [FromHeader] string userId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null)
            {
                return NotFound();
            }

            if (review.CustomerId != userId)
            {
                return Forbid();
            }

            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
