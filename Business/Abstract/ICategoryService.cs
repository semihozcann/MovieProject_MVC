using Entities.Concrete;
using Entities.Dtos.Categories;
using Shared.Utilities.Result.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryService
    {

        Task<IDataResult<CategoryDto>> GetByIdAsync(int categoryId);
        Task<IDataResult<CategoryListDto>> GetAllAsync();
        Task<IResult> AddAsync(CategoryAddDto categoryAddDto);
        Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto);
        Task<IResult> DeleteAsync(int categoryId);
        Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId);

        List<Category> GetCategories();

    }
}
