using DZ_WPF_Base.Resource.BLL;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DZ_WPF_Base
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public void Initial_Equipment()
        {
            try
            {
                Equipment_Data EqDB = new Equipment_Data();
                int i = 0;
                int NumOfRow = EqDB.Equipment_Table.Count;

                Grid[] grids = new Grid[NumOfRow];
                Label[] lableMun = new Label[NumOfRow];
                Label[] lableMod = new Label[NumOfRow];
                Label[] lableAdr = new Label[NumOfRow];
                Label[] lableID = new Label[NumOfRow];

                foreach (var item in EqDB.Equipment_Table)
                {
                    lableID[i] = new Label
                    {
                        Content = item.intEquipmentID,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(0.0, 0.0, 0.0, 1.0),
                    };

                    lableMun[i] = new Label
                    {
                        Content = item.ManufacturerName,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1.0, 0.0, 0.0, 1.0)
                    };

                    lableMod[i] = new Label
                    {
                        Content = item.ModelName,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1.0, 0.0, 0.0, 1.0)
                    };

                    lableAdr[i] = new Label
                    {
                        Content = item.strLocationName,
                        BorderBrush = Brushes.Black,
                        BorderThickness = new Thickness(1.0, 0.0, 1.0, 1.0)
                    };

                    grids[i] = new Grid { };
                    grids[i].ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(40) });
                    grids[i].ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.0, GridUnitType.Star) });
                    grids[i].ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.0, GridUnitType.Star) });
                    grids[i].ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1.0, GridUnitType.Star) });

                    grids[i].Children.Add(lableID[i]);
                    grids[i].Children.Add(lableMun[i]);
                    grids[i].Children.Add(lableMod[i]);
                    grids[i].Children.Add(lableAdr[i]);

                    Grid.SetColumn(lableID[i], 0);
                    Grid.SetColumn(lableMun[i], 1);
                    Grid.SetColumn(lableMod[i], 2);
                    Grid.SetColumn(lableAdr[i], 3);

                    EquipStack.Children.Add(grids[i]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public MainWindow()
        {
            InitializeComponent();
            Initial_Equipment();

            try
            {
                Manufacturer_Data munDB = new Manufacturer_Data();
                int i = 0;
                int NumOfRow = munDB.Manufacturer_Table.Count;

                ComboBoxItem[] itemsMun = new ComboBoxItem[NumOfRow];

                foreach (var item in munDB.Manufacturer_Table)
                {
                    itemsMun[i] = new ComboBoxItem
                    {
                        Content = item.strName
                    };
                    MunCombo.Items.Add(itemsMun[i]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            try
            {
                Adress_Data adrDB = new Adress_Data();
                int i = 0;
                int NumOfRow = adrDB.Adress_Table.Count;

                ComboBoxItem[] itemsAdr = new ComboBoxItem[NumOfRow];

                bool first = true;
                foreach (var item in adrDB.Adress_Table)
                {
                    itemsAdr[i] = new ComboBoxItem
                    {
                        Content = item.strLocationName,
                        IsSelected = first
                    };
                    first = false;
                    AdrCombo.Items.Add(itemsAdr[i]);
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void EqupButton_Click(object sender, RoutedEventArgs e)
        {
            Equipment_Data EqD = new Equipment_Data();

            string SelItemMun = (((ComboBoxItem)(MunCombo.SelectedItem)).Content).ToString();
            int SelMunID = 0;
            string SelItemMod = (((ComboBoxItem)(ModCombo.SelectedItem)).Content).ToString();
            int SelModID = 0;
            string SelItemAdr = (((ComboBoxItem)(AdrCombo.SelectedItem)).Content).ToString();
            int SelAdrID = 0;

            List<Equipment_Base> Eq_Data = EqD.GetData();

            foreach (var item in Eq_Data)
            {
                if(item.ManufacturerName.ToString() == SelItemMun)
                {
                    SelMunID = item.intManufacturerID;
                }
                if (item.ModelName.ToString() == SelItemMod)
                {
                    SelModID = item.intModelID;
                }
                if (item.strLocationName.ToString() == SelItemAdr)
                {
                    SelAdrID = item.intLocationId;
                }
            }
            EqD.Set_Data(ManID: SelMunID, ModID: SelModID, locID: SelAdrID);
            EquipStack.Children.Clear();
            Initial_Equipment();
        }

        private void MunCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Equipment_Data EqD = new Equipment_Data();

            string SelItemMun = (((ComboBoxItem)(MunCombo.SelectedItem)).Content).ToString();
            int SelModID = 0;

            List<Equipment_Base> Eq_Data = EqD.GetData();

            foreach (var item in Eq_Data)
            {
                if (item.ManufacturerName.ToString() == SelItemMun)
                {
                    SelModID = item.intModelID;
                }
            }

            try
            {
                Model_Data modDB = new Model_Data();
                int i = 0;
                int NumOfRow = modDB.Model_Table.Count;

                ComboBoxItem[] itemsMod = new ComboBoxItem[NumOfRow];
                ModCombo.Items.Clear();

                bool first = true;
                bool teg = false;
                foreach (var item in modDB.Model_Table)
                {
                    if(SelModID == item.intModelID)
                    {
                        teg = true;
                        itemsMod[i] = new ComboBoxItem
                        {
                            Content = item.strName,
                            IsSelected = first
                        };
                        ModCombo.Items.Add(itemsMod[i]);
                        i++;
                    }
                }
                if(teg == false)
                {
                    itemsMod[i] = new ComboBoxItem
                    {
                        Content = "Нет моделей"
                    };
                    ModCombo.Items.Add(itemsMod[i]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
