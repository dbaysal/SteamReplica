using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NLayer.API.Filters;
using NLayer.Core;
using NLayer.Core.DTOs;
using NLayer.Core.Services;

namespace NLayer.API.Controllers
{
    
    public class CategoriesController : CustomBaseController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;
        private readonly IBasketService _basketService;

        public CategoriesController(IMapper mapper, IService<Category> service, ICategoryService productService, IBasketService basketService)
        {
            _mapper = mapper;
            _categoryService = productService;
            _basketService = basketService;
        }


        //get a category with its products
        [HttpGet("[action]")]  
        public async Task<IActionResult> GetSingleCategoryByIdWithProductsAsync(int categoryId)
        {
            return CreateActionResult(await _categoryService.GetSingleCategoryByIdWithProductsAsync(categoryId));
        }

        //get a category with its products
        [HttpGet("[action]")]
        public async Task<IActionResult> getbasket()
        {
            return Ok(await _basketService.GetAllAsync());
        }


        //get a category according to its id
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var category = await _categoryService.GetByIdAsync(id);
            var categoriesDto = _mapper.Map<CategoryDto>(category);
            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(200, categoriesDto));
        }


        //get all categories
        [HttpGet]
        public async Task<IActionResult> All()
        {
            var category = await _categoryService.GetAllAsync();
            var categoryDtos = _mapper.Map<List<CategoryDto>>(category.ToList());
            return CreateActionResult(CustomResponseDto<List<CategoryDto>>.Success(200, categoryDtos));
        }

        //update a category
        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            categoryDto.CreatedDate = DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss");
            var category = await _categoryService.AddAsync(_mapper.Map<Category>(categoryDto));
            var categoriesDto = _mapper.Map<CategoryDto>(category);


            return CreateActionResult(CustomResponseDto<CategoryDto>.Success(201, categoriesDto));
        }


    }
}
