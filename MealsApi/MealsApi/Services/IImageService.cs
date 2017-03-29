using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;
using MealsApi.Utils.Upload;

namespace MealsApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public interface IImageService
    {
        Task<ImageStatus> ReadAsync(string encrypted);
        Task<ImageResponse> UpdateAsync(string encrypted, HttpFile newImage);
    }
}
