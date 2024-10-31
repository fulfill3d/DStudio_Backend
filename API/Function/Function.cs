using System.Net;
using DStudio.API.Data.Models;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.OpenApi.Models;
using DStudio.API.Services.Interfaces;
using Newtonsoft.Json;

namespace DStudio.API
{
    public class Function(
        IApiService apiService)
    {
        [Function(nameof(GetManifest))]
        [OpenApiOperation(
            operationId: "HttpGet",
            tags: new[] { "get" })]
        [OpenApiParameter(
            name: "id",
            In = ParameterLocation.Query,
            Required = true,
            Type = typeof(string),
            Description = "The Manifest ID parameter")]
        [OpenApiParameter(
            name: "partitionKey",
            In = ParameterLocation.Query,
            Required = true,
            Type = typeof(string),
            Description = "The Manifest ID parameter")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "application/json",
            bodyType: typeof(Manifest),
            Description = "The OK response")]
        public async Task<HttpResponseData> GetManifest(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "manifest")]
            HttpRequestData req)
        {
            var query = System.Web.HttpUtility.ParseQueryString(req.Url.Query);
            var id = query["id"];
            var partitionKey = query["partitionKey"];

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(partitionKey))
            {
                var errorResponse = req.CreateResponse(HttpStatusCode.BadRequest);
                await errorResponse.WriteStringAsync("The 'id' query parameter is required.");
                return errorResponse;
            }

            var response = req.CreateResponse(HttpStatusCode.OK);
            var result = await apiService.GetManifest(id, partitionKey);
            await response.WriteStringAsync(JsonConvert.SerializeObject(result, Formatting.Indented));
            return response;
        }
        
        
        [Function(nameof(GetManifests))]
        [OpenApiOperation(
            operationId: "HttpGet",
            tags: new[] { "get" })]
        [OpenApiParameter(
            name: "id",
            In = ParameterLocation.Path,
            Required = true,
            Type = typeof(string),
            Description = "The Manifest ID parameter")]
        [OpenApiResponseWithBody(
            statusCode: HttpStatusCode.OK,
            contentType: "application/json",
            bodyType: typeof(Manifest),
            Description = "The OK response")]
        public async Task<HttpResponseData> GetManifests(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = "manifest/get-all")]
            HttpRequestData req,
            FunctionContext executionContext, string id)
        {
            var response = req.CreateResponse();
            response.StatusCode = HttpStatusCode.OK;
            var result = await apiService.GetManifests();
            await response.WriteStringAsync(JsonConvert.SerializeObject(result, Formatting.Indented));
            return response;
        }
    }
}