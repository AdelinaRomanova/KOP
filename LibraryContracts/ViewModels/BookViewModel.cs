using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryContracts.ViewModels
{
    public class BookViewModel
    {
        public int? Id { get; set; }

        [DisplayName("Название")]
        public string Title { get; set; }

        [DisplayName("Описание")]
        public string Description { get; set; }

        [DisplayName("Жанр")]
        public string Genre { get; set; }

        [DisplayName("Стоимость")]
        public int? Cost { get; set; }

        public string CostStr
        {
            set
            {
                if (Cost == 0) CostStr = "Бесплатная";
                else if (Cost == null) CostStr = "Не указано";
                else CostStr = value;
            }
            get
            {
                if (Cost == 0) return "Бесплатная";
                else if (Cost == null) return "Не указано";
                else return Cost.ToString();
            }
        }
    }
}
