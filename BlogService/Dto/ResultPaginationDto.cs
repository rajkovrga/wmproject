using System;
using System.Collections.Generic;
using System.Text;

namespace BlogService.Dto
{
    public class ResultPaginationDto<T>
    {
        public IEnumerable<T> Items { get; set; }
        public int CountItems { get; set; }
        public int CountPages => (int)Math.Ceiling((float)CountItems / PerPage);
        public int CurrentPage { get; set; }
        public int PerPage { get; set; }
    }
}
