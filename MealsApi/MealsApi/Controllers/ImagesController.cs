using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.Http;
using MealsApi.Controllers.Base;
using MealsApi.Services;

namespace MealsApi.Controllers
{
    public class ImagesController : BaseApiController
    {
        private readonly IImageService _imageService;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="imageService"></param>
        public ImagesController(IImageService imageService)
        {
            _imageService = imageService;
        }

        public async Task<HttpResponseMessage> Get(string image)
        {
            var imageStatus = await _imageService.ReadAsync(image);

            if (!imageStatus.Success)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, new HttpError("Image not found"));
            }

            // serve the payload
            var result = new HttpResponseMessage(HttpStatusCode.OK)
            {
                Content = new ByteArrayContent(imageStatus.Image.ImagePayload)
            };

            result.Content.Headers.ContentType = new MediaTypeHeaderValue(imageStatus.Image.MimeType);
            return result; 
        }
    }
}