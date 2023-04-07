using Entities.Concrete;
using Shared.Entities.Abstract;

namespace Entities.Dtos.Categories
{
    public class CategoryDto : IDto
    {
        public Category Category { get; set; }
    }
}
