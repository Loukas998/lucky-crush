using LuckyCrush.Domain.Services;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

namespace LuckyCrush.Infrastructure.Services;

public class FileService(IWebHostEnvironment environment) : IFileService
{
    /// <summary>
    ///     Note::
    ///     path: The relative path to Images/{path}
    /// </summary>
    public async Task<List<string>> SaveFiles(List<IFormFile> files, string path, string[] allowedFileExtensions)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        //var prefixedPath = $"Images/{path}";

        string fileName;
        string filePath;
        List<string> filesPaths = [];

        foreach (var file in files)
        {
            if (file == null) throw new ArgumentNullException(nameof(file));
            var extension = Path.GetExtension(file.FileName);

            if (!allowedFileExtensions.Contains(extension))
                throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");

            fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
            filePath = Path.Combine(environment.ContentRootPath, path, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }

            filesPaths.Add(Path.Combine(path, fileName));
        }

        return filesPaths;
    }

    public string SaveFile(IFormFile file, string path, string[] allowedFileExtensions)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);
        //var prefixedPath = $"Images/{path}";

        if (file == null || file.Length == 0) throw new ArgumentNullException(nameof(file));
        var extension = Path.GetExtension(file.FileName);

        if (!allowedFileExtensions.Contains(extension))
            throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");

        var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
        var filePath = Path.Combine(environment.ContentRootPath, path, fileName);

        using (var stream = new FileStream(filePath, FileMode.Create))
        {
            file.CopyToAsync(stream);
        }
        var finalFilePath = Path.Combine(path, fileName);
        return finalFilePath;


    }

    public async Task<string> SaveFileAsync(IFormFile file, string path, string[] allowedFileExtensions)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        if (file == null || file.Length == 0) throw new ArgumentNullException(nameof(file));
        var extension = Path.GetExtension(file.FileName);

        if (!allowedFileExtensions.Contains(extension))
            throw new ArgumentException($"Only {string.Join(",", allowedFileExtensions)} are allowed.");

        var fileName = $"{Guid.NewGuid()}-{Path.GetFileName(file.FileName)}";
        var filePath = Path.Combine(environment.ContentRootPath, path, fileName);

        // Open a file stream and copy the contents asynchronously
        await using (var stream = new FileStream(filePath, FileMode.Create))
        {
            await file.CopyToAsync(stream);
        }
        var finalFilePath = Path.Combine(path, fileName);
        return finalFilePath;


    }

    public void DeleteFile(string path)
    {
        if (string.IsNullOrEmpty(path)) throw new ArgumentNullException(nameof(path));

        if (!File.Exists(path)) throw new FileNotFoundException("Invalid file path");

        File.Delete(path);
    }

    public async Task<string> SaveBytesImage(byte[] bytes, string path)
    {
        if (!Directory.Exists(path)) Directory.CreateDirectory(path);

        var fileName = $"{Guid.NewGuid()}.png";
        var filePath = Path.Combine(path, fileName);

        await File.WriteAllBytesAsync(filePath, bytes);
        return filePath;
    }
}
