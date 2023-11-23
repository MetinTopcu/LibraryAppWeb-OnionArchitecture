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
    public class BooksController : CustomBaseController
    {
        private readonly IMapper _mapper;
        private readonly IBookService _service;

        public BooksController(IMapper mapper, IBookService service)
        {
            _mapper = mapper;
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> All()
        {
            var books = await _service.GetAllAsync();

            var booksDtos = _mapper.Map<List<BookDto>>(books.ToList());

            return CreateActionResultInstance(ResponseDto<List<BookDto>>.Success(booksDtos, 200));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await _service.GetByIdAsync(id);
            var booksDtos = _mapper.Map<List<BookDto>>(books);

            return CreateActionResultInstance(ResponseDto<List<BookDto>>.Success(booksDtos, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookDto bookDto)
        {
            var books = await _service.AddAsync(_mapper.Map<Book>(bookDto));

            var booksDtos = _mapper.Map<BookDto>(books);

            return CreateActionResultInstance(ResponseDto<BookDto>.Success(booksDtos, 201));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookDto bookDto)
        {
            await _service.UpdateAsync(_mapper.Map<Book>(bookDto));

            return CreateActionResultInstance(ResponseDto<NoContentDto>.Success(204));
        }

        [HttpDelete("{id}")]  //id belirtiyoruz ki api/books/5  5 id li veriyi siler.
        public async Task<IActionResult> Remove(int id)
        {
            var books = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(books);

            return CreateActionResultInstance(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
