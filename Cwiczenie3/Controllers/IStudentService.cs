
using Cwiczenie3;

namespace Cwiczenia3
{
    public interface IGetStudent
    {
        Task<IList<Student>> GetStudentsListAsync(string title);
    }
}
