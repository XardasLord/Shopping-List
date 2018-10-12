﻿using ShoppingList.Business.Models;
using System.Threading.Tasks;

namespace ShoppingList.Business.Services
{
    public interface IRecipeService
    {
        Task<int> AddAsync(RecipeModel model);
    }
}
