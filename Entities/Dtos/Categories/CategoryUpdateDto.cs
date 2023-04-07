﻿using Shared.Entities.Abstract;

namespace Entities.Dtos.Categories
{
    public class CategoryUpdateDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

    }
}
