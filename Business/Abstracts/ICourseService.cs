using Core.Persistence.Paging;
using Entities.Concretes;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstracts
{
    public interface ICourseService
    {
        Task<IPaginate<CourseDetailDto>> GetDetailsListAsync();

        Task<IPaginate<Course>> GetListAsync();
        Task Add(Course course);
        Task Update(Course course);
        Task Delete(Course course);


    }

}
