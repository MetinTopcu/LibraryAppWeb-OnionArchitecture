using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Services.Core.Application.Dtos;
using OnionArchitecture.Services.Core.Application.Services;
using OnionArchitecture.Services.Core.Domain.Entities;
using OnionArchitecture.Shared.ControllerBases;
using OnionArchitecture.Shared.Dtos;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnionArchitecture.Services.Presentation.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CustomBaseController
    {

        private readonly IMapper _mapper;
        private readonly ICategoryService _service;

        public CategoriesController(IMapper mapper, ICategoryService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var categories = await _service.GetAllAsync();

            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories.ToList());

            return CreateActionResultInstance(ResponseDto<List<CategoryDto>>.Success(categoriesDtos, 200));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var categories = await _service.GetByIdAsync(id);
            var categoriesDtos = _mapper.Map<List<CategoryDto>>(categories);

            return CreateActionResultInstance(ResponseDto<List<CategoryDto>>.Success(categoriesDtos, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(CategoryDto categoryDto)
        {
            var categories = await _service.AddAsync(_mapper.Map<Category>(categoryDto));

            var categoriesDtos = _mapper.Map<CategoryDto>(categories);

            return CreateActionResultInstance(ResponseDto<CategoryDto>.Success(categoriesDtos, 201));
        }

        [HttpPut]
        public async Task<IActionResult> Update(CategoryDto categoryDto)
        {
            await _service.UpdateAsync(_mapper.Map<Category>(categoryDto));

            return CreateActionResultInstance(ResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]  //id belirtiyoruz ki api/categories/5  5 id li veriyi siler.
        public async Task<IActionResult> Remove(int id)
        {
            var categories = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(categories);

            return CreateActionResultInstance(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
