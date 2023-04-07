using AutoMapper;
using Business.Abstract;
using Business.Constants;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.Dtos.Categories;
using Shared.Utilities.Business;
using Shared.Utilities.Result.Abstract;
using Shared.Utilities.Result.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {

        #region Injection

        ICategoryRepository _categoryRepository;
        IMapper _mapper;
        public CategoryManager(ICategoryRepository categoryRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _mapper = mapper;
        }

        #endregion

        public async Task<IResult> AddAsync(CategoryAddDto categoryAddDto)
        {

            Task<IResult> result = BusinessRules.Run(CategoryNameAlreadyExist(categoryAddDto.Name));
            if (result != null)
            {
                return result.Result;
            }

            var category = _mapper.Map<Category>(categoryAddDto);
            await _categoryRepository.AddAsync(category);
            await _categoryRepository.SaveAsync();
            return new SuccessResult(Messages.CategoryAdded);
        }

        public async Task<IResult> DeleteAsync(int categoryId)
        {
            var category = await _categoryRepository.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                var deletedCategory = await _categoryRepository.DeleteAsync(category);
                await _categoryRepository.SaveAsync();
                return new SuccessResult(Messages.CategoryDeleted);
            }
            else
            {
                return new ErrorResult(Messages.CategoryNotFound);
            }
        }

        public async Task<IDataResult<CategoryListDto>> GetAllAsync()
        {
            var categories = await _categoryRepository.GetAllAsync();
            if (categories != null)
            {
                return new SuccessDataResult<CategoryListDto>(new CategoryListDto { Categories = categories }, Messages.CategoryListed);
            }
            else
            {
                return new ErrorDataResult<CategoryListDto>(new CategoryListDto { Categories = null }, Messages.CategoryNotFound);
            }
        }

        public async Task<IDataResult<CategoryDto>> GetByIdAsync(int categoryId)
        {
            var category = await _categoryRepository.GetAsync(c => c.Id == categoryId);
            if (category != null)
            {
                return new SuccessDataResult<CategoryDto>(new CategoryDto { Category = category }, Messages.CategoryGeted);
            }
            else
            {
                return new ErrorDataResult<CategoryDto>(Messages.CategoryNotFound);
            }
        }

        public async Task<IResult> UpdateAsync(CategoryUpdateDto categoryUpdateDto)
        {
            var oldCategory = await _categoryRepository.GetAsync(c => c.Id == categoryUpdateDto.Id);
            var category = _mapper.Map<CategoryUpdateDto, Category>(categoryUpdateDto, oldCategory);
            var updatedCategory = await _categoryRepository.UpdateAsync(category);
            await _categoryRepository.SaveAsync();

            return new SuccessResult(Messages.CategoryUpdated);
        }


        public async Task<IDataResult<CategoryUpdateDto>> GetCategoryUpdateDtoAsync(int categoryId)
        {
            var category = await _categoryRepository.GetAllAsync(c => c.Id == categoryId);
            var result = category.Any();
            if (result)
            {
                return new SuccessDataResult<CategoryUpdateDto>(new CategoryUpdateDto { Id = categoryId });
            }
            else
            {
                return new ErrorDataResult<CategoryUpdateDto>(Messages.CategoryNotFound);
            }
        }


        public List<Category> GetCategories()
        {
            return _categoryRepository.GetAll();
        }






        #region BusinessRules

        public async Task<IResult> CategoryNameAlreadyExist(string categoryName)
        {
            //Burada aynı isimde başka bir örnek eklenmesini engellemek amacıyla bir örnek kural yazılmıştır.
            var category = await _categoryRepository.GetAllAsync(c => c.Name == categoryName);
            var result = category.Any();
            if (result)
            {
                return new ErrorResult(Messages.CategoryNameAlreadyExist);
            }
            return new SuccessResult();
        }

        #endregion
    }
}
