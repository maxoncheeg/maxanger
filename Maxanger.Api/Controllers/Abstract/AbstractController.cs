using Maxanger.Api.Models.Responses;
using Maxanger.Api.Models.Validations;
using Microsoft.AspNetCore.Mvc;

namespace Maxanger.Api.Controllers.Abstract;

[ApiController]
public abstract class AbstractController : ControllerBase
{
    protected AbstractController()
    {

    }

    protected ActionResult BaseResponse(int statusCode, object? data = null, string message = "")
    {
        ApiResponse response = new(statusCode, data, message);
        
        return Ok(response);
    }

    protected RequestValidation ValidateGetRequestPagination(int skip, int take)
    {
        var validation = new RequestValidation { Result = true };

        if (skip < 0 || take < 0)
        {
            validation.Result = false;
            validation.Code = StatusCodes.Status400BadRequest;

            if (skip < 0)
                validation.Message = "Значение 'skip' должно быть больше или равно 0";

            if (take < 0)
                validation.Message = "Значение 'take' должно быть больше или равно 0";
        }


        return validation;
    }
}