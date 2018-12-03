using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace DZ_WPF_Base.Resource.BLL
{
    class Equipment_Data
    {
        public List<Equipment_Base> Equipment_Table { get; set; } = new List<Equipment_Base>();
        public Equipment_Data()
        {
            GetData();
        }
        public List<Equipment_Base> GetData()
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
            return Equipment_Table;
        }
        public void Set_Data(int ManID, int ModID, int locID)
        {
            try
            {
                using (MCSEntities db = new MCSEntities())
                {
                    newEquipment Eq = new newEquipment
                    {
                        //intEquipmentID = 847,                                                      //[intEquipmentID] [int] IDENTITY(1,1) NOT NULL,
                        intGarageRoom = null,                                                       //[intGarageRoom] [nvarchar](50) NULL, 
                        intManufacturerID = ManID,                                                //[intManufacturerID] [int] NOT NULL,
                        intModelID = ModID, //****                                                //[intModelID] [int] NOT NULL,
                        strManufYear = DateTime.Now.Year.ToString(),                              //[strManufYear] [nvarchar](4) NULL,
                        intSNPrefixID = (int)DateTime.Now.Second,                                 //[intSNPrefixID] [int] NOT NULL,
                        strSerialNo = null,                                                       //[strSerialNo] [nvarchar](20) NULL,
                        intEquipmentTypeID = (new Random()).Next(1, 999),                         //[intEquipmentTypeID] [int] NOT NULL,
                        intSMCSFamilyID = (new Random()).Next(1, 999),                            //[intSMCSFamilyID] [int] NOT NULL,
                        intSizeID = (new Random()).Next(300, 9999),                               //[intSizeID] [int] NOT NULL,
                        CreateDate = null,                                                         //[CreateDate] [date] NULL,
                        intMetered = ((double)(new Random()).Next(1000, 9999)) / 100,             //[intMetered] [float] NOT NULL,
                        LastDate = DateTime.Now,                                                  //[LastDate] [date] NOT NULL,
                        intLastMetered = ((double)(new Random()).Next(1000, 9999)) / 100,         //[intLastMetered] [float] NOT NULL,
                        intTotalMetered = ((double)(new Random()).Next(1000, 9999)) / 100,        //[intTotalMetered] [float] NOT NULL,
                        intlimitDay = (new Random()).Next(1, 30),                                 //[intlimitDay] [int] NULL,
                        intlimitWeek = (new Random()).Next(1, 7),                                 //[intlimitWeek] [int] NULL,
                        bitActive = Convert.ToBoolean((new Random()).Next(0, 1)),                 //[bitActive] [bit] NOT NULL,
                        bitPreservation = Convert.ToBoolean((new Random()).Next(0, 1)),          //[bitPreservation] [bit] NOT NULL,
                        bitMeter = Convert.ToBoolean((new Random()).Next(0, 1)),                  //[bitMeter] [bit] NOT NULL,
                        bitKTG = Convert.ToBoolean((new Random()).Next(0, 1)),                   //[bitKTG] [bit] NOT NULL,
                        isDelete = Convert.ToBoolean((new Random()).Next(0, 1)),                  //[isDelete] [bit] NOT NULL CONSTRAINT [DF_newEquipment_isDelete]  DEFAULT ((0)),
                        intLocationId = locID,                                                    //[intLocationId] [int] NOT NULL,
                        strDescription = null,                                                      //[strDescription] [nvarchar](1050) NULL,
                        floatCostTires = null,                                                      //[floatCostTires] [float] NULL,
                        intCostTiresCurrency = null,                                                //[intCostTiresCurrency] [int] NULL,
                        floatAverageDivergence = null,                                              //[floatAverageDivergence] [float] NULL,
                        floatFullPrice = null,                                                      //[floatFullPrice] [float] NULL,
                        intFullPriceCurrency = null,                                                //[intFullPriceCurrency] [int] NULL,
                        dateStartUpDate = null,                                                     //[dateStartUpDate] [date] NULL,
                        intServiceLife = null,                                                      //[intServiceLife] [int] NULL,
                        intHoweverOddsAcceleration = null,                                          //[intHoweverOddsAcceleration] [int] NULL,
                        bitMethodAmortization = true                                                //[bitMethodAmortization] [bit] NOT NULL,
                        //TablesLocation = null,
                        //TablesManufacturer = null,
                        //TablesModel = null
                    };
                    db.newEquipment.Add(Eq);
                    db.SaveChanges();
                    MessageBox.Show("Данные записаны");
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Невозможно записать данные");
            }
        }

    }
}