using PluginsConventionLibrary;

namespace RomanovaPlugin
{
    public class PluginsConventionElementMy : PluginsConventionElement
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Genre { get; set; }
        public int? Cost { get; set; }
        public string CostStr
        {
            set
            {
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