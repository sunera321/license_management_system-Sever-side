using AutoMapper;
using license_management_system_Sever_side.Data;
using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;
using Microsoft.EntityFrameworkCore;



namespace license_management_system_Sever_side.Services.ReviewServices
{
    public class ReviewServices : IReviewServices
    {
        DataContext _context;
        IMapper _mapper;
        public ReviewServices(DataContext dataContext, IMapper mapper)
        {
            _context = dataContext;
            _mapper = mapper;
        }
        public async Task<IEnumerable<Review>> GetReviewsAsync(int moduleId)
        {
            return await _context.Reviews.Where(r => r.ModuleId == moduleId).ToListAsync();
        }

        public async Task<Review> GetReviewByIdAsync(int reviewId)
        {
            return await _context.Reviews.FindAsync(reviewId);
        }

        public async Task AddReviewAsync(ReviewDto reviewDto, int moduleId, string userId)
        {
            var review = new Review
            {
                ModuleId = moduleId,
                Rating = reviewDto.Rating,
                ReviewText = reviewDto.Review,
                CustomerId = userId
            };
            _context.Reviews.Add(review);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateReviewAsync(int reviewId, ReviewDto reviewDto, string userId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null || review.CustomerId != userId)
            {
                // Handle not found or forbidden
                return;
            }
            review.Rating = reviewDto.Rating;
            review.ReviewText = reviewDto.Review;
            _context.Reviews.Update(review);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteReviewAsync(int reviewId, string userId)
        {
            var review = await _context.Reviews.FindAsync(reviewId);
            if (review == null || review.CustomerId != userId)
            {
                // Handle not found or forbidden
                return;
            }
            _context.Reviews.Remove(review);
            await _context.SaveChangesAsync();
        }

    }
}
