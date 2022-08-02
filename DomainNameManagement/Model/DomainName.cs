using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookListRazor.Model
{
    public class DomainName
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string Owner { get; set; }

        public string GLCode { get; set; }
    }
}
