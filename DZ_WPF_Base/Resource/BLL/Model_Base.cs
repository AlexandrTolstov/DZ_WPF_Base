using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_WPF_Base.Resource.BLL
{
    class Model_Base
    {
        public int intModelID { get; set; }
        public string strName { get; set; }
        public Nullable<int> intManufacturerID { get; set; }
        public Nullable<int> intSMCSFamilyID { get; set; }
        public string strImage { get; set; }

        public Model_Base(int intModelID, string strName, Nullable<int> intManufacturerID, Nullable<int> intSMCSFamilyID, string strImage)
        {
            this.intModelID = intModelID;
            this.strName = strName;
            this.intManufacturerID = intManufacturerID;
            this.intSMCSFamilyID = intSMCSFamilyID;
            this.strImage = strImage;
        }
    }
}
