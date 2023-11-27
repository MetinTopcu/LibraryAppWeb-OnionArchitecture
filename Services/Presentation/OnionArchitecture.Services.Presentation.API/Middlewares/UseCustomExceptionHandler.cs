using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using OnionArchitecture.Services.Core.Application.Exceptions;
using OnionArchitecture.Shared.Dtos;
using System.Text.Json;

namespace OnionArchitecture.Services.Presentation.API.Middlewares
{
    public static class UseCustomExceptionHandler //request ilk geldiğinde middleware e girer ve bir de response oluşurken girer.
    {
        
        public static void UseCustomException(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(config =>
            {
                config.Run(async context =>
                {
                    context.Response.ContentType = "application/json";

                    var exceptionFeature = context.Features.Get<IExceptionHandlerFeature>();

                    var statusCode = exceptionFeature.Error switch
                    {
                        ClientSideException => 400,
                        NotFoundException => 404,
                        _ => 500
                    };
                    context.Response.StatusCode = statusCode;

                    var response = ResponseDto<NoContentDto>.Fail(exceptionFeature.Error.Message,statusCode);

                    await context.Response.WriteAsync(JsonSerializer.Serialize(response));
                });
            });
        }
    }
}
