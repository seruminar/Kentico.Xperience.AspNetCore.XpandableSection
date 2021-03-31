using System.Collections.Generic;

namespace XpandableSection.Models
{
    public class Section
    {
        public Direction Direction { get; set; }

        public string Name { get; set; }

        public IList<Section> Sections { get; set; }
    }
}