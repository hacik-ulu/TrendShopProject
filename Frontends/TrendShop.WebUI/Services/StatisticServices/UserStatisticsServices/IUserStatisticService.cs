﻿namespace TrendShop.WebUI.Services.StatisticServices.UserStatisticsServices
{
    public interface IUserStatisticService
    {
        Task<int> GetUserCount();
    }
}
