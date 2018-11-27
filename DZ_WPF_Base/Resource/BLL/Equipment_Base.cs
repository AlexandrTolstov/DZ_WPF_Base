using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ_WPF_Base.Resource;

namespace DZ_WPF_Base.Resource.BLL
{
    class Equipment_Base
    {
        public int intEquipmentID { get; set; } //ID оборудования
        public int intManufacturerID { get; set; } //ID производителя
        public string ManufacturerName { get; set; } //Имя производителя
        public int intModelID { get; set; } //ID модели
        public string ModelName { get; set; } //Имя модели
        public int intLocationId { get; set; } //ID локации
        public string strLocationName { get; set; } //Название улицы

        public Equipment_Base(int intEquipmentID, int intManufacturerID, string ManufacturerName, int intModelID, string ModelName, int intLocationId, string strLocationName)
        {
            this.intEquipmentID = intEquipmentID;
            this.intManufacturerID = intManufacturerID;
            this.ManufacturerName = ManufacturerName;
            this.intModelID = intModelID;
            this.ModelName = ModelName;
            this.intLocationId = intLocationId;
            this.strLocationName = strLocationName;
        }
    }
}
