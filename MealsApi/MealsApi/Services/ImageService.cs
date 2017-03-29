using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using MealsApi.Data.Contracts;
using MealsApi.Utils.Upload;

namespace MealsApi.Services
{
    /// <summary>
    /// 
    /// </summary>
    public class ImageService : IImageService
    {
        private readonly IEncryptor _encryptor;
        private readonly IFileSystem _fileSystem;
        private readonly IDatabaseContext _context;

        public ImageService(IEncryptor encryptor, IFileSystem fileSystem, IDatabaseContext context)
        {
            _encryptor = encryptor;
            _fileSystem = fileSystem;
            _context = context;
        }

        public async Task<ImageStatus> ReadAsync(string encrypted)
        {
            var success = true;
            Guid? imageId = null;
            try
            {
                imageId = Guid.Parse(_encryptor.Decrypt(Uri.UnescapeDataString(encrypted)));
            }
            catch
            {
                success = false;
            }

            if (!success)
            {
                return await Task.FromResult(new ImageStatus { Success = false });
            }

            var image = _context.Images.SingleOrDefault(x => x.Id == imageId.Value);

            if (image == null)
            {
                return await Task.FromResult(new ImageStatus {Success = false});
            }

            byte[] imagePayload;
            using (var stream = await _fileSystem.OpenReadAsync(image.FileName))
            {
                using (var reader = new StreamReader(stream))
                {
                    using (var memstream = new MemoryStream())
                    {
                        var buffer = new byte[512];
                        int bytesRead;
                        while ((bytesRead = reader.BaseStream.Read(buffer, 0, buffer.Length)) > 0)
                            memstream.Write(buffer, 0, bytesRead);
                        imagePayload = memstream.ToArray();
                    }
                }
            }

            var result = new ImageStatus
            {
                Success = true,
                Image = new ImageResponse
                {
                    ImagePayload = imagePayload,
                    MimeType = image.MimeType
                }
            };

            return await Task.FromResult(result);
        }

        public Task<ImageResponse> UpdateAsync(string encrypted, HttpFile newImage)
        {
            throw new NotImplementedException();
        }
    }
}