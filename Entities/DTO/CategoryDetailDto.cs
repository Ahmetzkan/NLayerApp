using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.DTO
{
    public class CategoryDetailDto : IDto
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public string CourseDescription { get; set; }
        public string CategoryName { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }
    }
}