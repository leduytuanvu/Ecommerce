using Ecommerce.Application.Common.Interfaces.Services.Image;
using Ecommerce.Contracts.Image.Request;
using Ecommerce.Contracts.Image.Response;
using Ecommerce.Domain.Entities;
using ErrorOr;
using MapsterMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    [Route("image")]
    public class ImageController : ApiController
    {
        private readonly IImageService _imageService;
        private readonly IMapper _mapper;

        public ImageController(IImageService imageService, IMapper mapper)
        {
            _imageService = imageService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            ErrorOr<List<Image>?> result = await _imageService.GetAll();

            return result.Match(
                imageResult => CustomResult("Get data successfully", data: _mapper.Map<List<ImageResponse>>(imageResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("get-by-id")]
        [HttpGet]
        public async Task<IActionResult> GetById(Guid id)
        {
            ErrorOr<Image?> result = await _imageService.GetById(id);

            return result.Match(
                imageResult => CustomResult("Get data successfully", data: _mapper.Map<ImageResponse>(imageResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("create")]
        [HttpPost]
        public async Task<IActionResult> Create(ImageCreateRequest request)
        {
            ErrorOr<Image?> result = await _imageService.Create(_mapper.Map<Image>(request));

            return result.Match(
                imageResult => CustomResult("Get data successfully", data: _mapper.Map<ImageResponse>(imageResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("update")]
        [HttpPut]
        public async Task<IActionResult> Update(Guid id, ImageUpdateRequest request)
        {
            var Image = _mapper.Map<Image>(request);
            ErrorOr<Image?> result = await _imageService.Update(id, Image);

            return result.Match(
                imageResult => CustomResult("Get data successfully", data: _mapper.Map<ImageResponse>(imageResult!)),
                errors => CustomResultError(errors)
            );
        }

        [Route("delete")]
        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            ErrorOr<Image?> result = await _imageService.Delete(id);

            return result.Match(
                imageResult => CustomResult("Get data successfully", data: _mapper.Map<ImageResponse>(imageResult!)),
                errors => CustomResultError(errors)
            );
        }
    }
}
