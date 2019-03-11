using System;
using System.ComponentModel;

namespace Wpf_IIoT001
{
    public class AlarmMessage : INotifyPropertyChanged
    {
        private String _machineNo;
        private int _index;
        private Boolean _alarmFlag = false;
        private string _alarmMessage = string.Empty;
        private DateTime _timeStamp;

        public string MachineNo
        {
            get { return _machineNo; }
            set
            {
                _machineNo = value;
                NotifyPropertyChanged("MachineNo");
            }
        }

        public int Index
        {
            get { return _index; }
            set
            {
                _index = value;
                NotifyPropertyChanged("Index");
            }
        }
        public Boolean AlarmFlag
        {
            get { return _alarmFlag; }
            set
            {
                _alarmFlag = value;
                NotifyPropertyChanged("AlarmFlag");
            }
        }

        public string AlarmMessages
        {
            get { return _alarmMessage; }
            set
            {
                _alarmMessage = value;
                NotifyPropertyChanged("AlarmMessages");
            }
        }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set
            {
                _timeStamp = value;
                NotifyPropertyChanged("TimeStamp");
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
