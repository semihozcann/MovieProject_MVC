using Entities.Concrete;
using Shared.Entities.Abstract;
using System.Collections.Generic;

namespace Entities.Dtos.Categories
{
    public class CategoryListDto : IDto
    {
        public List<Category> Categories { get; set; }
    }
}
