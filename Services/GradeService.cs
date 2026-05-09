using Siemens.Internship2026.GradeBook.Interfaces;
using Siemens.Internship2026.GradeBook.Models;

namespace Siemens.Internship2026.GradeBook.Services;

public class GradeService : IGradeService
{
    private readonly IGradeRepository _repository;

    public GradeService(IGradeRepository repository)
    {
        _repository = repository;
    }

    public async Task<IEnumerable<Grade>> GetPassingActiveGradesAsync(int n)
    {
        var allGrades = await _repository.GetAllAsync();

        return allGrades
            .Where(g => g.value >= 5 && g.isActive)
            .Take(n);
    }
}