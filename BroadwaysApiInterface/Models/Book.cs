using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BroadwaysApiInterface.Models
{
    public class Book
    {
        [Key]
        public int BookId { get; set; }
        [StringLength(50)]
        public string Title { get; set; }
        //public string MainTitle { get; set; }
        //public string SubTitle { get; set; }
    }
}
