using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_WPF_Base.Resource.BLL
{
    class Adress_Base
    {
        public int intLocationId { get; set; }
        public string strLocationName { get; set; }
        public Nullable<int> intMajorLocationID { get; set; }
        public Nullable<double> floatWageStatements { get; set; }
        public Nullable<int> intWageStatementsCurrency { get; set; }
        public Nullable<double> floatAdministrativeExpenses { get; set; }
        public Nullable<int> intAdministrativeExpensesCurrency { get; set; }
        public string strAddressName { get; set; }
        public string strAddressName3 { get; set; }
        public string strAddressName5 { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }

        public Adress_Base(int intLocationId,
            string strLocationName,
            Nullable<int> intMajorLocationID,
            Nullable<double> floatWageStatements,
            Nullable<int> intWageStatementsCurrency,
            Nullable<double> floatAdministrativeExpenses,
            Nullable<int> intAdministrativeExpensesCurrency,
            string strAddressName,
            string strAddressName3,
            string strAddressName5,
            Nullable<System.DateTime> CreateDate
            )
        {
            this.intLocationId = intLocationId;
            this.strLocationName = strLocationName;
            this.intMajorLocationID = intMajorLocationID;
            this.floatWageStatements = floatWageStatements;
            this.intWageStatementsCurrency = intWageStatementsCurrency;
            this.floatAdministrativeExpenses = floatAdministrativeExpenses;
            this.intAdministrativeExpensesCurrency = intAdministrativeExpensesCurrency;
            this.strAddressName = strAddressName;
            this.strAddressName3 = strAddressName3;
            this.strAddressName5 = strAddressName5;
            this.CreateDate = CreateDate;
        }
    }
}
