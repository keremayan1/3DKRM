﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.ChildFather.DTOs
{
    public class GetChildFatherDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EducationStatusName { get; set; }

        public string Job { get; set; }
        public string TelephoneNumber { get; set; }
    }
}
