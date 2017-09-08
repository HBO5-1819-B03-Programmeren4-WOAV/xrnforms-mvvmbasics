using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XrnCourse.MvvmBasics.Domain.Models;

namespace XrnCourse.MvvmBasics.Domain.Services
{
    public class ClassmateInMemoryService
    {
        static List<Classmate> inMemClassmates = new List<Classmate>
        {
            new Classmate{  Id= Guid.NewGuid(), Name ="Siegfried",
                            Birthdate =new DateTime(1981,1,7), Phone="+00 111 222 333" },
            new Classmate{  Id= Guid.NewGuid(), Name ="Karlina",
                            Birthdate =new DateTime(1990,8,26), Phone="+00 444 555 666" },
            new Classmate{  Id= Guid.NewGuid(), Name ="Isana",
                            Birthdate =new DateTime(2001,11,2), Phone="+00 777 888 999" },
        };

        /// <summary>
        /// Gets all classmates in memory collection
        /// </summary>
        public async Task<IEnumerable<Classmate>> GetAll()
        {
            await Task.Delay(0);
            return inMemClassmates;
        }

        /// <summary>
        /// Gets a classmates from memory collection based on Id
        /// </summary>
        public async Task<Classmate> GetById(Guid id)
        {
            await Task.Delay(0);
            return inMemClassmates.FirstOrDefault(cm => cm.Id == id);
        }

        /// <summary>
        /// Saves a classmate to memory collection. Updates if existing, Adds if non-existing
        /// </summary>
        public async Task Save(Classmate classMate)
        {
            var mate = await GetById(classMate.Id);
            if(mate == null)
            {
                mate.Id = Guid.NewGuid();
                inMemClassmates.Add(mate);
            }
            mate.Name = classMate.Name;
            mate.Phone = classMate.Phone;
            mate.Birthdate = classMate.Birthdate;
        }
    }
}
