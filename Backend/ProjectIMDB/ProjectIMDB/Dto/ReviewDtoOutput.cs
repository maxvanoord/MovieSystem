using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectIMDB.Entities;

namespace ProjectIMDB.Dto
{
    public class ReviewDtoOutput
    {
        public Guid ReviewId { get; set; }

        public int Stars { get; set; }

        public string Title { get; set; }

        public string Body { get; set; }
    }
}
