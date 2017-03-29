using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace MealsApi.Services
{
    /// <summary>
    /// Filesystem
    /// </summary>
    public interface IFileSystem
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<bool> ExistsAsync(string filePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<Stream> OpenWriteAsync(string filePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task DeleteAsync(string filePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="filePath"></param>
        /// <returns></returns>
        Task<Stream> OpenReadAsync(string filePath);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> ListDirectoryAsync(string directory);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        Task DeleteDirectoryAsync(string directory);
    }
}