using Application.Features.ChildFather.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Children.Dtos
{
    public class GetListChildDto
    {
        public string Id { get; set; }
        public string NationalId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string GenderName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string SchoolName { get; set; }
        public string ClassName { get; set; }
        public string FatherFirstName { get; set; }
        public GetChildFatherDto ChildFather { get; set; }

    }
}
