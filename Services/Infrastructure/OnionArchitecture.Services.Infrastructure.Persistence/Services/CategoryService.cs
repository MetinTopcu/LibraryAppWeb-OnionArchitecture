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
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepository<Category> repository, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepository categoryRepository) : base(repository, unitOfWork)
        {
            _mapper = mapper;
            _repository = categoryRepository;
        }
    }
}
