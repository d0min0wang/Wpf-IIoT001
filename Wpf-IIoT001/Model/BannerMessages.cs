using System;
using System.ComponentModel;
using System.Windows.Threading;

namespace Wpf_IIoT001
{
    /// <summary>
    /// Banner显示的数据绑定
    /// </summary>
    public class BannerMessages:INotifyPropertyChanged
    {
        //当前时间
        private DateTime _currentTime;
        /// <summary>
        /// 构造函数
        /// 在本函数中实时更新时间的显示
        /// </summary>
        public BannerMessages()
        {
            _currentTime = DateTime.Now;
            DispatcherTimer timer = new DispatcherTimer();
            timer.Interval = TimeSpan.FromMilliseconds(500);
            timer.Tick += new EventHandler(Timer_Tik);
            timer.Start();
        }
        private void Timer_Tik(object sender,EventArgs e)
        {
            CurrentTime = DateTime.Now;
        }
        public DateTime CurrentTime
        {
            get { return _currentTime; }
            set
            {
                _currentTime = value;
                NotifyPropertyChanged("CurrentTime");
            }
        }

        //开机率Progressbar
        private double _utilizationRatio;
        public double UtilizationRatio
        {
            get { return _utilizationRatio; }
            set
            {
                _utilizationRatio = value;
                NotifyPropertyChanged("UtilizationRatio");
            }
        }
        //开机率Label
        private string _utilizationRatioStr;
        public string UtilizationRatioStr
        {
            get { return _utilizationRatioStr; }
            set
            {
                _utilizationRatioStr = value;
                NotifyPropertyChanged("UtilizationRatioStr");
            }
        }

        //做管率Progressbar
        private double _makingRatio;
        public double MakingRatio
        {
            get { return _makingRatio; }
            set
            {
                _makingRatio = value;
                NotifyPropertyChanged("MakingRatio");
            }
        }
        //做管率Label
        private string _makingRatioStr;
        public string MakingRatioStr
        {
            get { return _makingRatioStr; }
            set
            {
                _makingRatioStr = value;
                NotifyPropertyChanged("MakingRatioStr");
            }
        }

        //开机数量
        private string _executing;
        public string Executing
        {
            get { return _executing; }
            set
            {
                _executing = value;
                NotifyPropertyChanged("Executing");
            }
        }
        //开炉做管
        private string _executingAndMaking;
        public string ExecutingAndMaking
        {
            get { return _executingAndMaking; }
            set
            {
                _executingAndMaking = value;
                NotifyPropertyChanged("ExecutingAndMaking");
            }
        }
        //开炉空转
        private string _executingAndStartFurnace;
        public string ExecutingAndStartFurnace
        {
            get { return _executingAndStartFurnace; }
            set
            {
                _executingAndStartFurnace = value;
                NotifyPropertyChanged("ExecutingAndStartFurnace");
            }
        }
        //不开炉空转
        private string _executingAndStopFurnace;
        public string ExecutingAndStopFurnace
        {
            get { return _executingAndStopFurnace; }
            set
            {
                _executingAndStopFurnace = value;
                NotifyPropertyChanged("ExecutingAndStopFurnace");
            }
        }
        //停机
        private string _noExecuting;
        public string NoExecuting
        {
            get { return _noExecuting; }
            set
            {
                _noExecuting = value;
                NotifyPropertyChanged("NoExecuting");
            }
        }
        //报警
        private string _alarming;
        public string Alarming
        {
            get { return _alarming; }
            set
            {
                _alarming = value;
                NotifyPropertyChanged("Alarming");
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
