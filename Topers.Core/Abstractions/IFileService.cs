
using Microsoft.AspNetCore.Http;

namespace Topers.Core.Abstractions;

public interface IFileService
{
    Tuple<int, string> SaveImage(IFormFile imageFile);
    void DeleteImage(string fullFileName);
};