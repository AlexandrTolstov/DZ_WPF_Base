using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_WPF_Base.Resource.BLL
{
    class Manufacturer_Data
    {
        public List<Manufacturer_Base> Manufacturer_Table { get; set; } = new List<Manufacturer_Base>();
        public Manufacturer_Data()
        {
            GetData();
        }
        public void GetData()
        {
            using (MCSEntities db = new MCSEntities())
            {
                var Manufacturer = db.TablesManufacturer;

                foreach (var mun in Manufacturer)
                {
                    Manufacturer_Table.Add(new Manufacturer_Base(mun.intManufacturerID, mun.strManufacturerChecklistId, mun.strName));
                }
            }
        }
    }
}

