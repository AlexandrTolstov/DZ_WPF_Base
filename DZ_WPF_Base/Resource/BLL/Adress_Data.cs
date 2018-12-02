using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_WPF_Base.Resource.BLL
{
    class Adress_Data
    {
        public List<Adress_Base> Adress_Table { get; set; } = new List<Adress_Base>();
        public Adress_Data()
        {
            GetData();
        }
        public void GetData()
        {
            using (MCSEntities db = new MCSEntities())
            {
                var Adress = db.TablesLocation;

                foreach (var adr in Adress)
                {
                        Adress_Table.Add(new Adress_Base(
                            adr.intLocationId,
                            adr.strLocationName,
                            adr.intMajorLocationID,
                            adr.floatWageStatements,
                            adr.intWageStatementsCurrency,
                            adr.floatAdministrativeExpenses,
                            adr.intAdministrativeExpensesCurrency,
                            adr.strAddressName,
                            adr.strAddressName3,
                            adr.strAddressName5,
                            adr.CreateDate
                            ));
                }
            }
        }
    }
}
