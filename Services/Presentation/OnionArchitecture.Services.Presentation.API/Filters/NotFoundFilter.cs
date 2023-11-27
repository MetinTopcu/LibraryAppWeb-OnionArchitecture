using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnionArchitecture.Services.Core.Application.Services;
using OnionArchitecture.Services.Core.Domain.Common;
using OnionArchitecture.Shared.Dtos;
using System.Linq;
using System.Threading.Tasks;

namespace OnionArchitecture.Services.Presentation.API.Filters
{
    public class NotFoundFilter<T> : IAsyncActionFilter where T : BaseEntity
    {
        private readonly IService<T> _service;

        public NotFoundFilter(IService<T> service) // constructoru var diye startupa tanımladık ve
        {                                          // kullancağımız endpointin üstüne  böyle yazdık  [ServiceFilter(typeof(NotFoundFilter<Book>))]
            _service = service;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {

            var idValue = context.ActionArguments.Values.FirstOrDefault();

            if(idValue == null) 
            {
                await next.Invoke();
                return;
            }

            var id = (int)idValue;
            var anyEntity = await _service.AnyAsync(x=>x.Id ==id);

            if(anyEntity) 
            {
                await next.Invoke();
                return;
            }

            context.Result = new NotFoundObjectResult(ResponseDto<NoContentDto>.Fail($"{typeof(T).Name}({id}) not found", 404));

           
        }
    }
}
