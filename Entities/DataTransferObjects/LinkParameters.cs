using Entities.RequestFeatures;
using Microsoft.AspNetCore.Http;

namespace Entities.DataTransferObjects
{
    public record LinkParameters
    {
        public BookParameter BookParameters { get; init; }
        public HttpContext HttpContext { get; init; }
    }
}