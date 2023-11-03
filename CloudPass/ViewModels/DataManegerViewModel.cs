using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CloudPass.Model;

namespace CloudPass.ViewModels
{
    public class DataManegerViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public ObservableCollection<DataModel> Data { get; set; }

        private DataModel selectedData;

        public DataModel SelectedData
        {
            get { return selectedData; }
            set 
            { 
                selectedData = value; 
                OnPropertyChanged(nameof(SelectedData));
            }
        }

        public DataManegerViewModel()
        {
            Data = new ObservableCollection<DataModel>();

            Data.Add(new DataModel { Url = "Website.org", Username = "Bush", Password = "123213123" });
            Data.Add(new DataModel { Url = "te.org", Username = "fsd", Password = "vsdfsd" });

            if (Data.Count > 0)
            {
                SelectedData = Data[0];
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
