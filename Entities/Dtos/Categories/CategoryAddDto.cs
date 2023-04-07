using Shared.Entities.Abstract;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos.Categories
{
    public class CategoryAddDto : IDto
    {
        public string Name { get; set; }

    }
}
