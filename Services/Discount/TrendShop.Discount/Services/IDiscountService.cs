﻿using TrendShop.Discount.Dtos;

namespace TrendShop.Discount.Services
{
    public interface IDiscountService
    {
        Task<List<ResultDiscountCouponDto>> GetAllDiscountCouponAsync();
        Task CreateDiscountCouponAsync(CreateDiscountCouponDto createCouponDto);
        Task UpdateDiscountCouponAsync(UpdateDiscountCouponDto updateCouponDto);
        Task DeleteDiscountCouponAsync(int id);
        Task<GetByIdDiscountCouponDto> GetByIdDiscountCouponAsync(int id);
        Task<ResultDiscountCouponDto> GetCodeDetailByCodeAsync(string code);
        int GetDiscountCouponRate(string code);
        Task<int> GetDiscountCouponCount();

    }
}
