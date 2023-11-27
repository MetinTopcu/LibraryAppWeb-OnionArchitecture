using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using OnionArchitecture.Shared.Dtos;
using System.Linq;

namespace OnionArchitecture.Services.Presentation.API.Filters
{
    public class ValidaterFilterAttribute : ActionFilterAttribute
    {
        //BookDtoValidator ile beraber oluşturduk
        public override void OnActionExecuting(ActionExecutingContext context) //action methoda girmeden önce hata fırtlatıyoruz. 
        {
            if(!context.ModelState.IsValid) 
            {
                var errors = context.ModelState.Values.SelectMany(x => x.Errors).Select(x => x.ErrorMessage).ToList();

                context.Result = new BadRequestObjectResult(ResponseDto<NoContentDto>.Fail(errors, 400));
            }
        }
    }
}
