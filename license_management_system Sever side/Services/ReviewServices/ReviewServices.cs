using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace license_management_system_Sever_side.Services.ReviewServices
{
    public class ReviewServices : IReviewServices
    {
        private readonly DataContext _context;

        public ReviewServices(DataContext dataContext)
        {
            _context = dataContext;
        }

        public async Task<IEnumerable<Review>> GetReviewsAsync(int moduleId)
        {
            return await _context.Reviews.Where(r => r.ModuleId == moduleId).ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId);
        }

        public async Task AddReviewAsync(ReviewDto reviewDto)
        {
            var review = new Review
            {
                ModuleId = reviewDto.ModuleId,
                Rating = reviewDto.Rating,
                ReviewText = reviewDto.ReviewText
            };

            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int reviewId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);

            if (review != null)
            {
                _context.Reviews.Remove(review);
                await _context.SaveChangesAsync();
            }
        }
    }
}
