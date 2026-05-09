using System.Net.Http.Json;
using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Repositories;

public class GradeRepository : IGradeRepository
{
    private readonly HttpClient _httpClient;
    private const string DataUrl = "https://gist.githubusercontent.com/ArdeleanTudor/8ea407832cd9794960e0e6bbd1319f6e/raw/";

    public GradeRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<IEnumerable<Grade>> GetAllAsync()
    {
        var root = await _httpClient.GetFromJsonAsync<GradeRoot>(DataUrl);

        return root?.Items ?? Enumerable.Empty<Grade>();
    }

    public async Task<Grade?> GetByIdAsync(int id)
    {
        var allGrades = await GetAllAsync();
        return allGrades.FirstOrDefault(g => g.id == id);
    }

    public class GradeRoot
    {
        public List<Grade> Items { get; set; } = new();
    }
}