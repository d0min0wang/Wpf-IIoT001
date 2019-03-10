using System;
using System.ComponentModel;

namespace Wpf_IIoT001
{
    public class machineFlag: INotifyPropertyChanged
    {
        //开机状态位
        private TagQuality _machineStartusQuality;
        public TagQuality MachineStartusQuality
        {
            get { return _machineStartusQuality; }
            set
            {
                _machineStartusQuality = value;
                //int temp = MachineStatus;
                NotifyPropertyChanged("MachineStartusQuality");
            }
        }
        private Boolean _isMachineStart;
        public Boolean IsMachineStart
        {
            get { return _isMachineStart; }
            set
            {
                _isMachineStart = value;
                MachineStatus=Convert.ToInt32(value);
                NotifyPropertyChanged("IsMachineStart");
            }
        }

        //炉子状态位
        private TagQuality _furnaceStartusQuality;
        public TagQuality FurnaceStartusQuality
        {
            get { return _furnaceStartusQuality; }
            set
            {
                _furnaceStartusQuality = value;
                NotifyPropertyChanged("FurnaceStartusQuality");
            }
        }
        private Boolean _isFurnaceStart;
        public Boolean IsFurnaceStart
        {
            get { return _isFurnaceStart; }
            set
            {
                _isFurnaceStart = value;
                MachineStatus = Convert.ToInt32(value);
                FurnaceStatus = Convert.ToInt32(value);
                NotifyPropertyChanged("IsFurnaceStart");
            }
        }

        //升料机状态位
        private TagQuality _literStartusQuality;
        public TagQuality LiterStartusQuality
        {
            get { return _literStartusQuality; }
            set
            {
                _literStartusQuality = value;
                NotifyPropertyChanged("LiterStartusQuality");
            }
        }
        private Boolean _isLiterStart;
        public Boolean IsLiterStart
        {
            get { return _isLiterStart; }
            set
            {
                _isLiterStart = value;
                MachineStatus = Convert.ToInt32(value);
                LiterStatus = Convert.ToInt32(value);
                NotifyPropertyChanged("IsLiterStart");
            }
        }

        //报警状态位
        private TagQuality _alarmStatusQuality;
        public TagQuality AlarmStatusQuality
        {
            get { return _alarmStatusQuality; }
            set
            {
                _alarmStatusQuality = value;
                NotifyPropertyChanged("AlarmStatusQuality");
            }
        }
        private Boolean _isAlarm;
        public Boolean IsAlarm
        {
            get { return _isAlarm; }
            set
            {
                _isAlarm = value;
                AlarmStatus = Convert.ToInt32(value);
                NotifyPropertyChanged("AlarmStatus");
            }
        }

        private int flareMoldTimeSetting;//烤模时间设定
        private int dippingMaterialTimeSetting;//浸料时间设定
        private int flareMaterialTimeSetting;//烤料时间设定
        private int coolingTimeSetting;//冷却时间设定
        private int brushOilTimeSetting;//刷油时间设定

        public int FlareMoldTimeSetting
        {
            get { return flareMoldTimeSetting; }
            set {
                flareMoldTimeSetting = value;
                NotifyPropertyChanged("FlareMoldTimeSetting");
            }
        }

        public int DipingMaterialTimeSetting
        {
            get { return dippingMaterialTimeSetting; }
            set
            {
                dippingMaterialTimeSetting = value;
                NotifyPropertyChanged("DipingMaterialTimeSetting");
            }
        }

        public int FlareMaterialTimeSetting
        {
            get { return flareMaterialTimeSetting; }
            set
            {
                flareMaterialTimeSetting = value;
                NotifyPropertyChanged("FlareMaterialTimeSetting");
            }
        }

        public int CoolingTimeSetting
        {
            get { return coolingTimeSetting; }
            set
            {
                coolingTimeSetting = value;
                NotifyPropertyChanged("CoolingTimeSetting");
            }
        }

        public int BrushOilTimeSetting
        {
            get { return brushOilTimeSetting; }
            set
            {
                brushOilTimeSetting = value;
                NotifyPropertyChanged("BrushOilTimeSetting");
            }
        }



        //开机
        public int getMachineStart()
        {
            if (_isMachineStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //开炉做管
        public int getMaking()
        {
            if (_isMachineStart && _isFurnaceStart && _isLiterStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
        //开炉空转
        public int getIdling()
        {
            if (_isMachineStart && _isFurnaceStart && !_isLiterStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //不开炉空转
        public int getIdlingAndFurnaceStop()
        {
            if (_isMachineStart && !_isFurnaceStart && !_isLiterStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //停机
        public int getHalting()
        {
            if (!_isMachineStart)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        //报警
        public int getAlarm()
        {
            if (_isAlarm)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        private int _machineStatus;
        public int MachineStatus
        {
            //机器状态
            get { return _machineStatus; }
            set
            {
                if (_machineStartusQuality == TagQuality.Good)
                {
                    if (_isMachineStart)
                    {
                        if (_isFurnaceStart && _isLiterStart)
                        {
                            _machineStatus= 2;//机器启动，炉子启动，升料机启动则显示绿色
                        }
                        else
                        {
                            _machineStatus= 3;//机器启动，炉子或者升料机关闭则显示黄色
                        }
                    }
                    else
                    {
                        _machineStatus= 1;//机器关闭则显示红色
                    }
                }
                else
                {
                    _machineStatus= 0;//掉线则显示灰色
                }
                NotifyPropertyChanged("MachineStatus");
            }
        }

        private int _furnaceStatus;
        public int FurnaceStatus
        {
            get { return _furnaceStatus; }
            set
            {
                //炉子状态
                if (_furnaceStartusQuality == TagQuality.Good)
                {
                    if (_isFurnaceStart)
                    {
                        _furnaceStatus= 2;//炉子开启则显示绿色
                    }
                    else
                    {
                        _furnaceStatus= 1;//炉子关闭则显示红色
                    }
                }
                else
                {
                    _furnaceStatus= 0;
                }
                NotifyPropertyChanged("FurnaceStatus");
            }
        }

        private int _literStatus;
        public int LiterStatus
        {
            get { return _literStatus; }
            set
            {
                //升料机状态
                if (_literStartusQuality == TagQuality.Good)
                {
                    if (_isLiterStart)
                    {
                        _literStatus= 2;//升料机开启则显示绿色
                    }
                    else
                    {
                        _literStatus= 1;//升料机关闭则显示红色
                    }
                }
                else
                {
                    _literStatus= 0;
                }
                NotifyPropertyChanged("LiterStatus");
            }
        }

        private int _alarmStatus;
        public int AlarmStatus
        {
            get { return _alarmStatus; }
            //报警状态
            set
            {
                if (_alarmStatusQuality == TagQuality.Good)
                {
                    if (_isAlarm)
                    {
                        _alarmStatus= 1;//有报警则显示红色
                    }
                    else
                    {
                        _alarmStatus= 0;//无报警则显示绿色
                    }
                }
                else
                {
                    _alarmStatus= 0;
                }
                NotifyPropertyChanged("AlarmStatus");
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
