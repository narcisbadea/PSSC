﻿using E_Commerce.Domain.Models;

namespace E_Commerce.DAL.Repositoris.Interfaces
{
    public interface IOderRepository
    {
        Task PostOrderAsync(Order order);
    }
}