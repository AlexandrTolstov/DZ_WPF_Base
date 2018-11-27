using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_WPF_Base.Resource.BLL
{
    class Equipment_Data
    {
        public List<Equipment_Base> Equipment_Table { get; set; } = new List<Equipment_Base>();
        public Equipment_Data()
        {
            using (MCSEntities db = new MCSEntities())
            {
                var Equipment = db.newEquipment;
                var Location = db.TablesLocation;
                var Manufacturer = db.TablesManufacturer;
                var Model = db.TablesModel;

                foreach (var eq in Equipment)
                {
                    string ManName = "";
                    foreach (var man in Manufacturer)
                    {
                        if (eq.intManufacturerID == man.intManufacturerID)
                        {
                            ManName = man.strName;
                            break;
                        }
                    }
                    string ModName = "";
                    foreach (var mod in Model)
                    {
                        if (eq.intModelID == mod.intModelID)
                        {
                            ModName = mod.strName;
                        }
                    }
                    string LocName = "";
                    foreach (var loc in Location)
                    {
                        if (eq.intLocationId == loc.intLocationId)
                        {
                            LocName = loc.strLocationName;
                        }
                    }

                    Equipment_Table.Add(new Equipment_Base(eq.intEquipmentID,
                        eq.intManufacturerID,
                        ManName,
                        eq.intModelID,
                        ModName,
                        eq.intLocationId,
                        LocName));
                }
            }
        }
    }
}
