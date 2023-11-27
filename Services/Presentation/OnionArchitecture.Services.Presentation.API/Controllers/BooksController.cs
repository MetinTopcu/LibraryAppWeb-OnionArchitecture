using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnionArchitecture.Services.Core.Application.Dtos;
using OnionArchitecture.Services.Core.Application.Services;
using OnionArchitecture.Services.Core.Domain.Entities;
using OnionArchitecture.Services.Presentation.API.Filters;
using OnionArchitecture.Shared.ControllerBases;
using OnionArchitecture.Shared.Dtos;
using System;
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

        [ServiceFilter(typeof(NotFoundFilter<Book>))] //metoda girmeden yakalıyor id null olduğunu
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var books = await _service.GetByIdAsync(id);
            var booksDtos = _mapper.Map<BookDto>(books);

            return CreateActionResultInstance(ResponseDto<BookDto>.Success(booksDtos, 200));
        }

        [HttpPost]
        public async Task<IActionResult> Save(BookCreateDto bookCreateDto)
        {
            var books = _mapper.Map<Book>(bookCreateDto);

            books.CreatedDate = DateTime.Now;
            await _service.AddAsync(books);

            var booksDtos = _mapper.Map<BookDto>(books);

            return CreateActionResultInstance(ResponseDto<BookDto>.Success(booksDtos, 201));
        }

        [HttpPut]
        public async Task<IActionResult> Update(BookUpdateDto bookUpdateDto)
        {
            var books = _mapper.Map<Book>(bookUpdateDto);
            BookDto bookDto = new BookDto();

            books.UpdateDate = DateTime.Now;
            await _service.UpdateAsync(books);

            return CreateActionResultInstance(ResponseDto<NoContentDto>.Success(204));
        }

        [ServiceFilter(typeof(NotFoundFilter<Book>))] //metoda girmeden yakalıyor id null olduğunu
        [HttpDelete("{id}")]  //id belirtiyoruz ki api/books/5  5 id li veriyi siler.
        public async Task<IActionResult> Remove(int id)
        {
            var books = await _service.GetByIdAsync(id);

            await _service.RemoveAsync(books);

            return CreateActionResultInstance(ResponseDto<NoContentDto>.Success(204));
        }
    }
}
