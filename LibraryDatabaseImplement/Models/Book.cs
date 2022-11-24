using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryDatabaseImplement.Models
{
    public class Book
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public string Genre { get; set; }

        [Required]
        public int? Cost { get; set; }

        public string CostStr
        {
            set { }
            get
            {
                if (Cost == 0) return "Бесплатная";
                else if (Cost == null) return "Не указано";
                else return Cost.ToString();
            }
        }
    }
}
