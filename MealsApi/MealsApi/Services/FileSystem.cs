using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace MealsApi.Services
{
    /// <summary>
    /// Filesystem
    /// </summary>
    public class FileSystem : IFileSystem
    {
        /// <summary>
        /// Maps base path
        /// </summary>
        // ReSharper disable once MemberCanBePrivate.Global
        // ReSharper disable once UnusedAutoPropertyAccessor.Global
        public Func<string, string> GetFilePathFunc { get; set; }

        public Task<bool> ExistsAsync(string filePath)
        {
            filePath = GetFilePath(filePath);
            return Task.FromResult(File.Exists(filePath));
        }

        public Task<Stream> OpenWriteAsync(string filePath)
        {
            filePath = GetFilePath(filePath);
            var directory = Path.GetDirectoryName(filePath);

            if (directory != null && !Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            return Task.FromResult<Stream>(new FileStream(
                filePath,
                FileMode.CreateNew));
        }

        public Task DeleteAsync(string filePath)
        {
            filePath = GetFilePath(filePath);
            File.Delete(filePath);
            return Task.FromResult(0);
        }

        public Task<Stream> OpenReadAsync(string filePath)
        {
            filePath = GetFilePath(filePath);

            return Task.FromResult<Stream>(new FileStream(
                filePath,
                FileMode.Open));
        }

        public Task<IEnumerable<string>> ListDirectoryAsync(string directory)
        {
            var actualDirectory = GetFilePath(directory);
            var files = Directory.EnumerateFiles(actualDirectory)
                .OrderBy(file => file)
                .Select(path => path.Substring(path.IndexOf(ToFileSystemPath(directory), StringComparison.Ordinal)).Replace("\\", "/"));

            return Task.FromResult(files);
        }

        public Task DeleteDirectoryAsync(string directory)
        {
            directory = GetFilePath(directory);
            Directory.Delete(directory, true);

            return Task.FromResult(0);
        }

        private string GetFilePath(string filePath)
        {
            if (GetFilePathFunc == null)
            {
                throw new InvalidOperationException(
                    "GetFilePathFunc is not set. Please set it before using the class.");
            }

            filePath = GetFilePathFunc(filePath);
            return ToFileSystemPath(filePath);
        }

        private static string ToFileSystemPath(string filePath)
        {
            return filePath.Replace("/", "\\");
        }
    }
}