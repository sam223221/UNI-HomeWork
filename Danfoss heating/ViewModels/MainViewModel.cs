using Danfoss_heating.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Danfoss_heating.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        public ObservableCollection<EnergyData> WinterData { get; set; } = new ObservableCollection<EnergyData>();
        public ObservableCollection<EnergyData> SummerData { get; set; } = new ObservableCollection<EnergyData>();

        public MainViewModel()
        {
            var parser = new ExcelDataParser();
            var data = parser.ParseExcel("path_to_your_excel_file.xlsx");

            foreach (var item in data)
            {
                if (item.Season == "Winter")
                    WinterData.Add(item);
                else
                    SummerData.Add(item);
            }
        }
    }
}
