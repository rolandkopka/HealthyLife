using AutoMapper;
using HealthyLife.Data.Entities.Food;
using HealthyLife.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace HealthyLife.Data.AutoMapperProfiles
{
    public class FoodProfile : Profile
    {
        public FoodProfile()
        {
            CreateMap<Ingredient, IngredientModel>().ReverseMap();
        }
    }
}
