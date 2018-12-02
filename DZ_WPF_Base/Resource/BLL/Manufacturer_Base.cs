using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_WPF_Base.Resource.BLL
{
    class Manufacturer_Base
    {
        public int intManufacturerID { get; set; }
        public string strManufacturerChecklistId { get; set; }
        public string strName { get; set; }

        public Manufacturer_Base(int intManufacturerID, string strManufacturerChecklistId, string strName)
        {
            this.intManufacturerID = intManufacturerID;
            this.strManufacturerChecklistId = strManufacturerChecklistId;
            this.strName = strName;
        }
    }
}
