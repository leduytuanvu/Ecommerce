using Ecommerce.Application.Common.Interfaces.Services.Category;
using Ecommerce.Contracts.Category.Request;
using Ecommerce.Contracts.Category.Response;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("category")]
    public class CategoryController : ApiController
    {
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryService, IMapper mapper)
        {
            _categoryService = categoryService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {

            ErrorOr<List<Category>?> result = await _categoryService.GetAll();

            return result.Match(
                categoryResult => CustomResult("Get data successfully", data: _mapper.Map<List<CategoryResponse>>(categoryResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<Category?> result = await _categoryService.GetById(id);

            return result.Match(
                categoryResult => CustomResult("Get data successfully", data: _mapper.Map<CategoryResponse>(categoryResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(CategoryCreateRequest request)
        {
            ErrorOr<Category?> result = await _categoryService.Create(_mapper.Map<Category>(request));

            return result.Match(
                categoryResult => CustomResult("Get data successfully", data: _mapper.Map<CategoryResponse>(categoryResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, CategoryUpdateRequest request)
        {
            var category = _mapper.Map<Category>(request);
            ErrorOr<Category?> result = await _categoryService.Update(id, category);

            return result.Match(
                categoryResult => CustomResult("Get data successfully", data: _mapper.Map<CategoryResponse>(categoryResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Category?> result = await _categoryService.Delete(id);

            return result.Match(
                categoryResult => CustomResult("Get data successfully", data: _mapper.Map<CategoryResponse>(categoryResult!)),
                errors => CustomResultError(errors)
            );
        }
    }
}
