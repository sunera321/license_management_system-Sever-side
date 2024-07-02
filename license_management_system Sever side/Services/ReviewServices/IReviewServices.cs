﻿using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;


using license_management_system_Sever_side.Models.DTOs;
using license_management_system_Sever_side.Models.Entities;

namespace license_management_system_Sever_side.Services.ReviewServices
{
    public interface IReviewServices
    {
        Task<IEnumerable<Review>> GetReviewsAsync(int moduleId);
        Task<Review> GetReviewByIdAsync(int reviewId);
        Task AddReviewAsync(ReviewDto reviewDto, int moduleId, string userId);
        Task UpdateReviewAsync(int reviewId, ReviewDto reviewDto, string userId);
        Task DeleteReviewAsync(int reviewId, string userId);
    }

}

