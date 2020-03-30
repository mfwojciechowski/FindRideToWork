using System.Collections.Generic;
using FindRideToWork.Core.Domain;

namespace FindRideToWork.Core.Entities
{
    public class Language
    {
        public int LanguageId{ get; set; }
        public string Name { get; set; }
        public bool xDel { get; set; }
    }
}