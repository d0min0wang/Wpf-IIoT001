using System.ComponentModel;

namespace Wpf_IIoT001
{
    public class StatusMessages : INotifyPropertyChanged
    {
        private string _guiLoadedTime;
        public string GuiLoadedTime
        {
            get { return _guiLoadedTime; }
            set
            {
                _guiLoadedTime = value;
                NotifyPropertyChanged("GuiLoadedTime");
            }
        }

        private string _serverStatusString;
        public string ServerStatusString
        {
            get { return _serverStatusString; }
            set
            {
                _serverStatusString = value;
                NotifyPropertyChanged("ServerStatusString");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        // NotifyPropertyChanged will raise the PropertyChanged event passing the
        // source property that is being updated.
        public void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
