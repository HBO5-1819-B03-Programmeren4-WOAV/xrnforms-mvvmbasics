using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrnCourse.MvvmBasics.Domain.Models;

namespace XrnCourse.MvvmBasics.Domain.Services
{
    public interface IClassmateService
    {
        /// <summary>
        /// Gets all classmates
        /// </summary>
        Task<IEnumerable<Classmate>> GetAll();

        /// <summary>
        /// Gets a classmate based on Id
        /// </summary>
        Task<Classmate> GetById(Guid id);

        /// <summary>
        /// Saves a classmate. Updates if existing, Adds if non-existing
        /// </summary>
        Task Save(Classmate classMate);
    }
}
