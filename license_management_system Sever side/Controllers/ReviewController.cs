using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using license_management_system_Sever_side.Services.ReviewServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace license_management_system_Sever_side.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReviewController : ControllerBase
    {
        private readonly IReviewServices _reviewService;

        public ReviewController(IReviewServices reviewService)
        {
            _reviewService = reviewService;
        }

        [HttpGet("{moduleId}")]
        public async Task<ActionResult<IEnumerable<Review>>> GetReviews(int moduleId)
        {
            var reviews = await _reviewService.GetReviewsAsync(moduleId);
            return Ok(reviews);
        }

        [HttpGet("review/{reviewId}")]
        public async Task<ActionResult<Review>> GetReviewById(int reviewId)
        {
            var review = await _reviewService.GetReviewByIdAsync(reviewId);

            if (review == null)
            {
                return NotFound();
            }

            return Ok(review);
        }

        //[Authorize]
        [HttpPost]
        public async Task<ActionResult> AddReview([FromBody] ReviewDto reviewDto)
        {
            await _reviewService.AddReviewAsync(reviewDto);
            return Ok();
        }

        [Authorize]
        [HttpDelete("{reviewId}")]
        public async Task<ActionResult> DeleteReview(int reviewId)
        {
            await _reviewService.DeleteReviewAsync(reviewId);
            return Ok();
        }
    }
}
