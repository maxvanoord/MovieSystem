using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectIMDB.Dto
{
    public class ReviewDtoInput
    {
        public int Stars { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
