using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using DStudio.API.Client.Identity.Services.Interfaces;

namespace DStudio.API.Client.Identity
{
    public class IdentityFunction(
        ILogger<IdentityFunction> logger,
        IIdentityService identityService)
    {
        [Function(nameof(PostRegister))]
        // [OpenApiOperation(
        //     operationId: "HttpGet",
        //     tags: new[] { "get" })]
        // [OpenApiParameter(
        //     name: "integerId",
        //     In = ParameterLocation.Path,
        //     Required = true,
        //     Type = typeof(int),
        //     Description = "The integer ID parameter")]
        // [OpenApiResponseWithBody(
        //     statusCode: HttpStatusCode.OK,
        //     contentType: "application/json",
        //     bodyType: typeof(string),
        //     Description = "The OK response")]
        public async Task<HttpResponseData> PostRegister(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "post-register")]
            HttpRequestData req,
            FunctionContext executionContext)
        {
            var response = req.CreateResponse();
            response.StatusCode = HttpStatusCode.OK;
            var token = await identityService.Register();
            await response.WriteStringAsync(token);
            return response;
        }
        
        [Function(nameof(Validation))]
        // [OpenApiOperation(
        //     operationId: "HttpGet",
        //     tags: new[] { "get" })]
        // [OpenApiParameter(
        //     name: "integerId",
        //     In = ParameterLocation.Path,
        //     Required = true,
        //     Type = typeof(int),
        //     Description = "The integer ID parameter")]
        // [OpenApiResponseWithBody(
        //     statusCode: HttpStatusCode.OK,
        //     contentType: "application/json",
        //     bodyType: typeof(string),
        //     Description = "The OK response")]
        public async Task<HttpResponseData> Validation(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "post-register")]
            HttpRequestData req,
            FunctionContext executionContext)
        {
            var response = req.CreateResponse();
            var token = req.Query["token"];
            
            if (string.IsNullOrEmpty(token))
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }

            var isValid = await identityService.Validate(token);

            if (!isValid)
            {
                response.StatusCode = HttpStatusCode.Unauthorized;
                return response;
            }
            
            response.StatusCode = HttpStatusCode.OK;
            return response;
        }
    }
}