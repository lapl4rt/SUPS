using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DigDes.DSchool.SUPS.DataAccess.PresentData
{
    public class CargoGuide
    {
        public CargoGuide() { }

        public string Cargo_ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ShortCode { get; set; }
        public string Code { get; set; }
        public string CodeGNG { get; set; }
        public string Mnemocode { get; set; }
        public string IsUsed { get; set; }
        public string IsEmpty { get; set; }
    }
}
