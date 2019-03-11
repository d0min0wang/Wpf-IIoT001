using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Collections.ObjectModel;

namespace Wpf_IIoT001
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //初始化客户端
        private OPCClientWrapper opcClient = new OPCClientWrapper();
        //初始化Banner Model
        private BannerMessages bannerMessages = new BannerMessages();
        private static CancellationTokenSource cancelTokenSource = new CancellationTokenSource();

        public MainWindow()
        {
            InitializeComponent();
            this.dataGridViewAlarmMessage.ItemsSource = GlobalVars.alarmsMessagesList.AlarmMessagesDS;
            BindingInit();
            Stopwatch watch = new Stopwatch();///用于计算时间
            watch.Start();
            Parallel.Invoke(
                () => OpcClientInit());
            //await OpcClientInit();
            watch.Stop();
            label184.Text = watch.ElapsedMilliseconds.ToString();
        }

        /// <summary>
        /// 初始化数据绑定函数
        /// </summary>
        private void BindingInit()
        {
            //Banner
            GridBanner.DataContext = bannerMessages;
            //第一排
            DF07Status.DataContext = GlobalVars.DF07Flag;
            DF06Status.DataContext = GlobalVars.DF06Flag;
            SF08Status.DataContext = GlobalVars.SF08Flag;
            SF07Status.DataContext = GlobalVars.SF07Flag;
            SF06Status.DataContext = GlobalVars.SF06Flag;
            SF05Status.DataContext = GlobalVars.SF05Flag;
            SF04Status.DataContext = GlobalVars.SF04Flag;
            SF03Status.DataContext = GlobalVars.SF03Flag;
            SF02Status.DataContext = GlobalVars.SF02Flag;
            SF01Status.DataContext = GlobalVars.SF01Flag;
            DF05Status.DataContext = GlobalVars.DF05Flag;
            DF04Status.DataContext = GlobalVars.DF04Flag;
            DF03Status.DataContext = GlobalVars.DF03Flag;
            DF02Status.DataContext = GlobalVars.DF02Flag;
            DF01Status.DataContext = GlobalVars.DF01Flag;
            //第二排
            DF17Status.DataContext = GlobalVars.DF17Flag;
            DF16Status.DataContext = GlobalVars.DF16Flag;
            DF15Status.DataContext = GlobalVars.DF15Flag;
            SF12Status.DataContext = GlobalVars.SF12Flag;
            SF11Status.DataContext = GlobalVars.SF11Flag;
            SF10Status.DataContext = GlobalVars.SF10Flag;
            SF09Status.DataContext = GlobalVars.SF09Flag;
            DF14Status.DataContext = GlobalVars.DF14Flag;
            DF13Status.DataContext = GlobalVars.DF13Flag;
            DF12Status.DataContext = GlobalVars.DF12Flag;
            DF11Status.DataContext = GlobalVars.DF11Flag;
            DF10Status.DataContext = GlobalVars.DF10Flag;
            DF09Status.DataContext = GlobalVars.DF09Flag;
            DF08Status.DataContext = GlobalVars.DF08Flag;

            //第三排
            SF13Status.DataContext = GlobalVars.SF13Flag;
            SF14Status.DataContext = GlobalVars.SF14Flag;
            DF19Status.DataContext = GlobalVars.DF19Flag;
            SE13Status.DataContext = GlobalVars.SE13Flag;
        }

        /// <summary>
        /// OPC客户端初始化函数
        /// </summary>
        private async Task OpcClientInit()
        {
            opcClient.Init("192.168.0.130", "Kepware.KEPServerEX.V6");
            //添加点位变化事件回调
            opcClient.OpcDataChangedEvent += new OPCDataChangedHandler(OpcClient_OpcDataChangedEvent);
            //添加监视点位
            machineItems _machineItems = new machineItems();
            AlarmItems _alarmItems = new AlarmItems();
            ////await Task.Run(() =>
            ////{
            //    foreach (KeyValuePair<string, int> keyValuePair in MachineItems.getMachineFlagDict())
            //    {
            //    await Task.Run(() => { opcClient.MonitorOPCItem(keyValuePair.Key, keyValuePair.Value); });
            //    }
            ////});
            await Task.Run(() =>
                Parallel.ForEach(_machineItems.getMachineFlagDict(), keyValuePair=>
                {
                    opcClient.MonitorOPCItem(keyValuePair.Key, keyValuePair.Value);
                }
            ));

            await Task.Run(() =>
                Parallel.ForEach(_alarmItems.getAlarmFlagDict(), keyValuePair =>
                {
                    opcClient.MonitorOPCItem(keyValuePair.Key, keyValuePair.Value);
                }
            ));

            _machineItems.Dispose();
        }

        /// <summary>
        /// OPC数据变化响应事件
        /// </summary>
        /// <param name="list"></param>
        private void OpcClient_OpcDataChangedEvent(List<OPCChangeModel> list)
        {
            //Console.WriteLine("调用Method1的线程ID为：{0}", Thread.CurrentThread.ManagedThreadId);
            //OPC值变化监视事件处理函数
            foreach (OPCChangeModel model in list)
            {
                if (model.Index / 10000 == 0)
                {
                    switch (model.Index / 100)
                    {
                        //第一排
                        case 0:
                            MachineFlagSet(GlobalVars.DF07Flag, model, model.Index);
                            break;
                        case 1:
                            MachineFlagSet(GlobalVars.DF06Flag, model, model.Index);
                            break;
                        case 2:
                            MachineFlagSet(GlobalVars.SF08Flag, model, model.Index);
                            break;
                        case 3:
                            MachineFlagSet(GlobalVars.SF07Flag, model, model.Index);
                            break;
                        case 4:
                            MachineFlagSet(GlobalVars.SF06Flag, model, model.Index);
                            break;
                        case 5:
                            MachineFlagSet(GlobalVars.SF05Flag, model, model.Index);
                            break;
                        case 6:
                            MachineFlagSet(GlobalVars.SF04Flag, model, model.Index);
                            break;
                        case 7:
                            MachineFlagSet(GlobalVars.SF03Flag, model, model.Index);
                            break;
                        case 8:
                            MachineFlagSet(GlobalVars.SF02Flag, model, model.Index);
                            break;
                        case 9:
                            MachineFlagSet(GlobalVars.SF01Flag, model, model.Index);
                            break;
                        case 10:
                            MachineFlagSet(GlobalVars.DF05Flag, model, model.Index);
                            break;
                        case 11:
                            MachineFlagSet(GlobalVars.DF04Flag, model, model.Index);
                            break;
                        case 12:
                            MachineFlagSet(GlobalVars.DF03Flag, model, model.Index);
                            break;
                        case 13:
                            MachineFlagSet(GlobalVars.DF02Flag, model, model.Index);
                            break;
                        case 14:
                            MachineFlagSet(GlobalVars.DF01Flag, model, model.Index);
                            break;
                        //第二排
                        case 15:
                            MachineFlagSet(GlobalVars.DF17Flag, model, model.Index);
                            break;
                        case 16:
                            MachineFlagSet(GlobalVars.DF16Flag, model, model.Index);
                            break;
                        case 17:
                            MachineFlagSet(GlobalVars.DF15Flag, model, model.Index);
                            break;
                        case 18:
                            MachineFlagSet(GlobalVars.SF12Flag, model, model.Index);
                            break;
                        case 19:
                            MachineFlagSet(GlobalVars.SF11Flag, model, model.Index);
                            break;
                        case 20:
                            MachineFlagSet(GlobalVars.SF10Flag, model, model.Index);
                            break;
                        case 21:
                            MachineFlagSet(GlobalVars.SF09Flag, model, model.Index);
                            break;
                        case 22:
                            MachineFlagSet(GlobalVars.DF14Flag, model, model.Index);
                            break;
                        case 23:
                            MachineFlagSet(GlobalVars.DF13Flag, model, model.Index);
                            break;
                        case 24:
                            MachineFlagSet(GlobalVars.DF12Flag, model, model.Index);
                            break;
                        case 25:
                            MachineFlagSet(GlobalVars.DF11Flag, model, model.Index);
                            break;
                        case 26:
                            MachineFlagSet(GlobalVars.DF10Flag, model, model.Index);
                            break;
                        case 27:
                            MachineFlagSet(GlobalVars.DF09Flag, model, model.Index);
                            break;
                        case 28:
                            MachineFlagSet(GlobalVars.DF08Flag, model, model.Index);
                            break;
                        //第三排
                        case 29:
                            MachineFlagSet(GlobalVars.SF13Flag, model, model.Index);
                            break;
                        case 30:
                            MachineFlagSet(GlobalVars.SF14Flag, model, model.Index);
                            break;
                        case 31:
                            MachineFlagSet(GlobalVars.DF19Flag, model, model.Index);
                            break;
                        case 32:
                            MachineFlagSet(GlobalVars.SE13Flag, model, model.Index);
                            break;
                    }
                }
                if(model.Index/10000>0)
                {
                    AlarmFlagSet(model,model.Index);
                }
            }
            //label184.Text = machinesFlags.SR01Flag.MachineStatus.ToString();
        }

        /// <summary>
        /// 机器状态数据更新函数
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="model"></param>
        /// <param name="index"></param>
        private void MachineFlagSet(machineFlag flag,OPCChangeModel model,int index)
        {
            switch (index%100)
            {
                //MachineFlagSet(machinesFlags.SR01Flag, model);
                case 1://机器开机状态位
                    flag.MachineStartusQuality = model.Quality;
                    flag.IsMachineStart = Convert.ToBoolean(model.Value);
                    break;
                case 2://机器炉子状态位
                    flag.FurnaceStartusQuality = model.Quality;
                    flag.IsFurnaceStart = Convert.ToBoolean(model.Value);
                    break;
                case 3://机器升料机状态位
                    flag.LiterStartusQuality = model.Quality;
                    flag.IsLiterStart = Convert.ToBoolean(model.Value);
                    break;
                case 4://机器报警状态位
                    flag.AlarmStatusQuality = model.Quality;
                    flag.IsAlarm = Convert.ToBoolean(model.Value);
                    break;
                case 5://烤模时间设定
                    flag.FlareMoldTimeSetting = Convert.ToInt32(model.Value);
                    break;
                case 6://浸料时间设定
                    flag.DipingMaterialTimeSetting = Convert.ToInt32(model.Value);
                    break;
                case 7://烤料时间设定
                    flag.FlareMaterialTimeSetting = Convert.ToInt32(model.Value);
                    break;
                case 8://冷却时间设定
                    flag.CoolingTimeSetting = Convert.ToInt32(model.Value);
                    break;

            }
            BannerMessageSet(flag, index / 100);
        }

        /// <summary>
        /// Banner数据更新函数
        /// </summary>
        /// <param name="flag"></param>
        /// <param name="index"></param>
        private void BannerMessageSet(machineFlag flag,int index)
        {
            //int _quantityOfMachine = 33;
            //int[] _executing = new int[_quantityOfMachine];
            //int[] _executingAndMaking = new int[_quantityOfMachine];
            //int[] _executingAndStartFurnace = new int[_quantityOfMachine];
            //int[] _executingAndStopFurnace = new int[_quantityOfMachine];
            //int[] _alarming = new int[_quantityOfMachine];
            //开机数量
            GlobalVars.executing[index] = flag.getMachineStart();
            bannerMessages.Executing =GlobalVars.executing.Sum().ToString();
            //停机数量
            bannerMessages.NoExecuting = (33 - GlobalVars.executing.Sum()).ToString();
            //开炉做管数量
            GlobalVars.executingAndMaking[index]=flag.getMaking();
            bannerMessages.ExecutingAndMaking = GlobalVars.executingAndMaking.Sum().ToString();
            //开炉空转数量
            GlobalVars.executingAndStartFurnace[index] = flag.getIdling();
            bannerMessages.ExecutingAndStartFurnace = GlobalVars.executingAndStartFurnace.Sum().ToString();
            //不开炉空转数量
            GlobalVars.executingAndStopFurnace[index] = flag.getIdlingAndFurnaceStop();
            bannerMessages.ExecutingAndStopFurnace = GlobalVars.executingAndStopFurnace.Sum().ToString();
            //报警数量
            GlobalVars.alarming[index] = flag.getAlarm();
            bannerMessages.Alarming = GlobalVars.alarming.Sum().ToString();
            //开机率
            if (GlobalVars.executing.Sum() > 0)
            {
                bannerMessages.UtilizationRatio = (int)Math.Round((double)(GlobalVars.executing.Sum()) * 100.0 / 33.0, 0);
                bannerMessages.UtilizationRatioStr = ((int)Math.Round((double)(GlobalVars.executing.Sum()) * 100.0 / 33.0, 0)).ToString() + "%";
            }
            //做管率
            if (GlobalVars.executingAndMaking.Sum() > 0)
            {
                bannerMessages.MakingRatio = (int)Math.Round((double)(GlobalVars.executingAndMaking.Sum()) * 100.0 / 33.0, 1);
                bannerMessages.MakingRatioStr = ((int)Math.Round((double)(GlobalVars.executingAndMaking.Sum()) * 100.0 / 33.0, 1)) + "%";
            }
        }

        /// <summary>
        /// 报警状态位置位函数
        /// </summary>
        /// <param name="model"></param>
        /// <param name="index"></param>
        private void AlarmFlagSet(OPCChangeModel model,int index)
        {
            try
            {
                int match = GlobalVars.alarmMessages.FindIndex(a => a.Index == index);
                GlobalVars.alarmMessages[match].AlarmFlag =Convert.ToBoolean(model.Value);
                GlobalVars.alarmMessages[match].TimeStamp = model.TimeStamp;
                UpdateAlarmList();
            }
            catch
            {
                
            }
        }

        /// <summary>
        /// 报警信息list刷新委托函数
        /// </summary>
        private void UpdateAlarmList()
        {
            ObservableCollection<GlobalVars.AlarmMessage> alarmMessagesDS = new ObservableCollection<GlobalVars.AlarmMessage>(GlobalVars.alarmMessages);
            //alarmMessagesDS.Clear();
            //List<GlobalVars.AlarmMessage> alarmMessagesDS = new List<GlobalVars.AlarmMessage>();
            foreach (var item in GlobalVars.alarmMessages)
            {
                if (item.AlarmFlag)
                {
                    //GlobalVars.AlarmMessage alarmMessage = new GlobalVars.AlarmMessage();
                    alarmMessagesDS.Add(item);
                }
            }
            //alarmMessagesDS.Sort((a, b) => b.TimeStamp.CompareTo(a.TimeStamp));
            //alarmMessagesDS.ForEach(x=>)
            GlobalVars.alarmsMessagesList.AlarmMessagesDS = alarmMessagesDS;
        }

        /// <summary>
        /// 获取机器的所有被触发的报警信息
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public string GetAlarmMessages(int index)
        {
            string _alarmStr = string.Empty;
            foreach (var item in GlobalVars.alarmMessages)
            {
                if (item.AlarmFlag)
                {
                    _alarmStr = _alarmStr + item.AlarmMessages + "; " + item.TimeStamp + '\n';
                }
            }
            return _alarmStr;
        }
        #region 大自动机tooltips
        private void ImageDF01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF01Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF01Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(15);

            }
            GlobalVars.DF01Flag.Toolstip = str;
        }

        private void ImageDF02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF02Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF02Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(14);
            }
            GlobalVars.DF02Flag.Toolstip = str;
        }

        private void ImageDF03_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF03Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF03Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF03Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF03Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF03Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF03Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(13);
            }
            GlobalVars.DF03Flag.Toolstip = str;
        }

        private void ImageDF04_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF04Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF04Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF04Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF04Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF04Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF04Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(12);
            }
            GlobalVars.DF04Flag.Toolstip = str;
        }

        private void ImageDF05_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF05Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF05Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF05Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF05Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF05Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF05Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(11);
            }
            GlobalVars.DF05Flag.Toolstip = str;
        }

        private void ImageDF06_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF06Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF06Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF06Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF06Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF06Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF06Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(2);
            }
            GlobalVars.DF06Flag.Toolstip = str;
        }

        private void ImageDF07_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF07Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF07Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF07Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF07Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF07Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF07Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(1);
            }
            GlobalVars.DF07Flag.Toolstip = str;
        }

        private void ImageDF08_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF08Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF08Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF08Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF08Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF08Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF08Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(29);
            }
            GlobalVars.DF08Flag.Toolstip = str;
        }

        private void ImageDF09_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF09Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF09Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF09Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF09Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF09Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF09Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(28);
            }
            GlobalVars.DF09Flag.Toolstip = str;
        }

        private void ImageDF10_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF10Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF10Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF10Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF10Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF10Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF10Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(27);
            }
            GlobalVars.DF10Flag.Toolstip = str;
        }

        private void ImageDF11_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF11Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF11Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF11Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF11Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF11Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF11Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(26);
            }
            GlobalVars.DF11Flag.Toolstip = str;
        }

        private void ImageDF12_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF12Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF12Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF12Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF12Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF12Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF12Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(25);
            }
            GlobalVars.DF12Flag.Toolstip = str;
        }

        private void ImageDF13_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF13Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF13Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF13Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF13Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF13Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF13Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(24);
            }
            GlobalVars.DF13Flag.Toolstip = str;
        }

        private void ImageDF14_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF14Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF14Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF14Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF14Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF14Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF14Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(23);
            }
            GlobalVars.DF14Flag.Toolstip = str;
        }

        private void ImageDF15_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF15Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF15Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF15Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF15Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF15Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF15Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(18);
            }
            GlobalVars.DF15Flag.Toolstip = str;
        }

        private void ImageDF16_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF16Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF16Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF16Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF16Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF16Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF16Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(17);
            }
            GlobalVars.DF16Flag.Toolstip = str;
        }

        private void ImageDF17_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF17Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF17Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF17Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF17Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF17Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF17Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(16);
            }
            GlobalVars.DF17Flag.Toolstip = str;
        }

        private void ImageDF19_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.DF19Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.DF19Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.DF19Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.DF19Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.DF19Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.DF19Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(32);
            }
            GlobalVars.DF19Flag.Toolstip = str;
        }

        #endregion

        #region 小自动机tooltip
        private void ImageSF01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF01Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF01Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(10);
            }
            GlobalVars.SF01Flag.Toolstip = str;
        }

        private void ImageSF02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF02Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF02Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(9);
            }
            GlobalVars.SF02Flag.Toolstip = str;
        }

        private void ImageSF03_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF03Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF03Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF03Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF03Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF03Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF03Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(8);
            }
            GlobalVars.SF03Flag.Toolstip = str;
        }

        private void ImageSF04_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF04Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF04Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF04Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF04Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF04Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF04Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(7);
            }
            GlobalVars.SF04Flag.Toolstip = str;
        }

        private void ImageSF05_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF05Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF05Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF05Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF05Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF05Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF05Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(6);
            }
            GlobalVars.SF05Flag.Toolstip = str;
        }

        private void ImageSF06_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF06Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF06Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF06Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF06Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF06Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF06Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(5);
            }
            GlobalVars.SF06Flag.Toolstip = str;
        }

        private void ImageSF07_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF07Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF07Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF07Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF07Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF07Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF07Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(4);
            }
            GlobalVars.SF07Flag.Toolstip = str;
        }

        private void ImageSF08_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF08Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF08Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF08Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF08Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF08Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF08Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(3);
            }
            GlobalVars.SF08Flag.Toolstip = str;
        }

        private void ImageSF09_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF09Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF09Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF09Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF09Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF09Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF09Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(22);
            }
            GlobalVars.SF09Flag.Toolstip = str;
        }

        private void ImageSF10_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF10Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF10Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF10Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF10Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF10Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF10Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(21);
            }
            GlobalVars.SF10Flag.Toolstip = str;
        }

        private void ImageSF11_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF11Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF11Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF11Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF11Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF11Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF11Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(20);
            }
            GlobalVars.SF11Flag.Toolstip = str;
        }

        private void ImageSF12_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF12Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF12Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF12Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF12Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF12Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF12Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(19);
            }
            GlobalVars.SF12Flag.Toolstip = str;
        }

        private void ImageSF13_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF13Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF13Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF13Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF13Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF13Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF13Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(30);
            }
            GlobalVars.SF13Flag.Toolstip = str;
        }

        private void ImageSF14_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SF14Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SF14Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SF14Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SF14Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SF14Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SF14Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(31);
            }
            GlobalVars.SF14Flag.Toolstip = str;
        }

        private void ImageSE13_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + GlobalVars.SE13Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + GlobalVars.SE13Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + GlobalVars.SE13Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + GlobalVars.SE13Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + GlobalVars.SE13Flag.BrushOilTimeSetting.ToString() + "\n";
            if (GlobalVars.SE13Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                str += GetAlarmMessages(33);
            }
            GlobalVars.SE13Flag.Toolstip = str;
        }
        #endregion
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            cancelTokenSource.Cancel();
            opcClient.Disconnect();
        }
    }
}
