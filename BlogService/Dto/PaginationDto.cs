using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Dto
{
    public class PaginationDto
    {
        public int PerPage { get; set; } = 5;
        public int CurrentPage { get; set; } = 1;
    }
}
