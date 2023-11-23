using AutoMapper;
using OnionArchitecture.Services.Core.Application.Repositories;
using OnionArchitecture.Services.Core.Application.Services;
using OnionArchitecture.Services.Core.Application.UnitOfWorks;
using OnionArchitecture.Services.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnionArchitecture.Services.Infrastructure.Persistence.Services
{
    public class BookService : Service<Book> , IBookService
    {
        private readonly IBookRepository _repository;
        private readonly IMapper _mapper;

        public BookService(IGenericRepository<Book> repository, IUnitOfWork unitOfWork, IMapper mapper, IBookRepository bookRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = bookRepository;
        }
    }
}
