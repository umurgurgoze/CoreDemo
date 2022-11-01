using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreDemo.Entity.Concrete
{
    public class BlogRating
    {
        [Key]
        public int RatingId { get; set; }
        public int BlogID { get; set; }
        public int BlogTotalScore { get; set; }
        public int BlogRatingCount { get; set; }
    }
}
