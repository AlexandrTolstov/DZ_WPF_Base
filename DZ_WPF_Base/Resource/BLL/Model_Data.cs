using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_WPF_Base.Resource.BLL
{
    class Model_Data
    {
        public List<Model_Base> Model_Table { get; set; } = new List<Model_Base>();
        public Model_Data()
        {
            GetData();
        }
        public void GetData()
        {
            using (MCSEntities db = new MCSEntities())
            {
                var Model = db.TablesModel;

                foreach (var mod in Model)
                {
                    Model_Table.Add(new Model_Base(mod.intModelID, 
                        mod.strName, 
                        mod.intManufacturerID, 
                        mod.intSMCSFamilyID, 
                        mod.strImage));
                }
            }
        }
    }
}
