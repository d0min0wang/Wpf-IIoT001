using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Threading;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

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
            BindingInit();
            //Stopwatch watch = new Stopwatch();///用于计算时间
            //watch.Start();
            //Parallel.Invoke(
            //    () => OpcClientInit());
            //watch.Stop();
            //label184.Text = watch.ElapsedMilliseconds.ToString();
        }

        /// <summary>
        /// 初始化数据绑定函数
        /// </summary>
        private void BindingInit()
        {
            //Banner
            GridBanner.DataContext = bannerMessages;
            //第一排
            DF07Status.DataContext = machinesFlags.DF07Flag;
            DF06Status.DataContext = machinesFlags.DF06Flag;
            SF08Status.DataContext = machinesFlags.SF08Flag;
            SF07Status.DataContext = machinesFlags.SF07Flag;
            SF06Status.DataContext = machinesFlags.SF06Flag;
            SF05Status.DataContext = machinesFlags.SF05Flag;
            SF04Status.DataContext = machinesFlags.SF04Flag;
            SF03Status.DataContext = machinesFlags.SF03Flag;
            SF02Status.DataContext = machinesFlags.SF02Flag;
            SF01Status.DataContext = machinesFlags.SF01Flag;
            DF05Status.DataContext = machinesFlags.DF05Flag;
            DF04Status.DataContext = machinesFlags.DF04Flag;
            DF03Status.DataContext = machinesFlags.DF03Flag;
            DF02Status.DataContext = machinesFlags.DF02Flag;
            DF01Status.DataContext = machinesFlags.DF01Flag;
            //第二排
            DF17Status.DataContext = machinesFlags.DF17Flag;
            DF16Status.DataContext = machinesFlags.DF16Flag;
            DF15Status.DataContext = machinesFlags.DF15Flag;
            SF12Status.DataContext = machinesFlags.SF12Flag;
            SF11Status.DataContext = machinesFlags.SF11Flag;
            SF10Status.DataContext = machinesFlags.SF10Flag;
            SF09Status.DataContext = machinesFlags.SF09Flag;
            DF14Status.DataContext = machinesFlags.DF14Flag;
            DF13Status.DataContext = machinesFlags.DF13Flag;
            DF12Status.DataContext = machinesFlags.DF12Flag;
            DF11Status.DataContext = machinesFlags.DF11Flag;
            DF10Status.DataContext = machinesFlags.DF10Flag;
            DF09Status.DataContext = machinesFlags.DF09Flag;
            DF08Status.DataContext = machinesFlags.DF08Flag;

            //第三排
            SF13Status.DataContext = machinesFlags.SF13Flag;
            SF14Status.DataContext = machinesFlags.SF14Flag;
            DF19Status.DataContext = machinesFlags.DF19Flag;
            SE13Status.DataContext = machinesFlags.SE13Flag;
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
            machineItems MachineItems = new machineItems();
            ////await Task.Run(() =>
            ////{
            //    foreach (KeyValuePair<string, int> keyValuePair in MachineItems.getMachineFlagDict())
            //    {
            //    await Task.Run(() => { opcClient.MonitorOPCItem(keyValuePair.Key, keyValuePair.Value); });
            //    }
            ////});
            await Task.Run(() =>
                Parallel.ForEach(MachineItems.getMachineFlagDict(), keyValuePair=>
                {
                    opcClient.MonitorOPCItem(keyValuePair.Key, keyValuePair.Value);
                }
            ));
            MachineItems.Dispose();
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
                switch(model.Index/100)
                {
                    //第一排
                    case 0:
                        MachineFlagSet(machinesFlags.DF07Flag, model, model.Index);
                        break;
                    case 1:
                        MachineFlagSet(machinesFlags.DF06Flag, model, model.Index);
                        break;
                    case 2:
                        MachineFlagSet(machinesFlags.SF08Flag, model, model.Index);
                        break;
                    case 3:
                        MachineFlagSet(machinesFlags.SF07Flag, model, model.Index);
                        break;
                    case 4:
                        MachineFlagSet(machinesFlags.SF06Flag, model, model.Index);
                        break;
                    case 5:
                        MachineFlagSet(machinesFlags.SF05Flag, model, model.Index);
                        break;
                    case 6:
                        MachineFlagSet(machinesFlags.SF04Flag, model, model.Index);
                        break;                    
                    case 7:
                        MachineFlagSet(machinesFlags.SF03Flag, model, model.Index);
                        break;
                    case 8:
                        MachineFlagSet(machinesFlags.SF02Flag, model, model.Index);
                        break;
                    case 9:
                        MachineFlagSet(machinesFlags.SF01Flag, model, model.Index);
                        break;
                    case 10:
                        MachineFlagSet(machinesFlags.DF05Flag, model, model.Index);
                        break;
                    case 11:
                        MachineFlagSet(machinesFlags.DF04Flag, model, model.Index);
                        break;
                    case 12:
                        MachineFlagSet(machinesFlags.DF03Flag, model, model.Index);
                        break;
                    case 13:
                        MachineFlagSet(machinesFlags.DF02Flag, model, model.Index);
                        break;
                    case 14:
                        MachineFlagSet(machinesFlags.DF01Flag, model, model.Index);
                        break;
                    //第二排
                    case 15:
                        MachineFlagSet(machinesFlags.DF17Flag, model, model.Index);
                        break;
                    case 16:
                        MachineFlagSet(machinesFlags.DF16Flag, model, model.Index);
                        break;
                    case 17:
                        MachineFlagSet(machinesFlags.DF15Flag, model, model.Index);
                        break;
                    case 18:
                        MachineFlagSet(machinesFlags.SF12Flag, model, model.Index);
                        break;
                    case 19:
                        MachineFlagSet(machinesFlags.SF11Flag, model, model.Index);
                        break;
                    case 20:
                        MachineFlagSet(machinesFlags.SF10Flag, model, model.Index);
                        break;
                    case 21:
                        MachineFlagSet(machinesFlags.SF09Flag, model, model.Index);
                        break;
                    case 22:
                        MachineFlagSet(machinesFlags.DF14Flag, model, model.Index);
                        break;
                    case 23:
                        MachineFlagSet(machinesFlags.DF13Flag, model, model.Index);
                        break;
                    case 24:
                        MachineFlagSet(machinesFlags.DF12Flag, model, model.Index);
                        break;
                    case 25:
                        MachineFlagSet(machinesFlags.DF11Flag, model, model.Index);
                        break;
                    case 26:
                        MachineFlagSet(machinesFlags.DF10Flag, model, model.Index);
                        break;
                    case 27:
                        MachineFlagSet(machinesFlags.DF09Flag, model, model.Index);
                        break;
                    case 28:
                        MachineFlagSet(machinesFlags.DF08Flag, model, model.Index);
                        break;
                    //第三排
                    case 29:
                        MachineFlagSet(machinesFlags.SF13Flag, model, model.Index);
                        break;
                    case 30:
                        MachineFlagSet(machinesFlags.SF14Flag, model, model.Index);
                        break;
                    case 31:
                        MachineFlagSet(machinesFlags.DF19Flag, model, model.Index);
                        break;
                    case 32:
                        MachineFlagSet(machinesFlags.SE13Flag, model, model.Index);
                        break;
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
                case 1:
                    flag.MachineStartusQuality = model.Quality;
                    flag.IsMachineStart = Convert.ToBoolean(model.Value);
                    break;
                case 2:
                    flag.FurnaceStartusQuality = model.Quality;
                    flag.IsFurnaceStart = Convert.ToBoolean(model.Value);
                    break;
                case 3:
                    flag.LiterStartusQuality = model.Quality;
                    flag.IsLiterStart = Convert.ToBoolean(model.Value);
                    break;
                case 4:
                    flag.AlarmStatusQuality = model.Quality;
                    flag.IsAlarm = Convert.ToBoolean(model.Value);
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
            int _quantityOfMachine = 31;
            int[] _executing = new int[_quantityOfMachine];
            int[] _executingAndMaking = new int[_quantityOfMachine];
            int[] _executingAndStartFurnace = new int[_quantityOfMachine];
            int[] _executingAndStopFurnace = new int[_quantityOfMachine];
            int[] _alarming = new int[_quantityOfMachine];
            //开机数量
            _executing[index] = flag.getMachineStart();
            bannerMessages.Executing = _executing.Sum().ToString();
            //停机数量
            bannerMessages.NoExecuting = (31 - _executing.Sum()).ToString();
            //开炉做管数量
            _executingAndMaking[index]=flag.getMaking();
            bannerMessages.ExecutingAndMaking = _executingAndMaking.Sum().ToString();
            //开炉空转数量
            _executingAndStartFurnace[index] = flag.getIdling();
            bannerMessages.ExecutingAndStartFurnace = _executingAndStartFurnace.Sum().ToString();
            //不开炉空转数量
            _executingAndStopFurnace[index] = flag.getIdlingAndFurnaceStop();
            bannerMessages.ExecutingAndStopFurnace = _executingAndStopFurnace.Sum().ToString();
            //报警数量
            _alarming[index] = flag.getAlarm();
            bannerMessages.Alarming = _alarming.Sum().ToString();
            //开机率
            if (_executing.Sum() > 0)
            {
                bannerMessages.UtilizationRatio = (int)Math.Round((double)(_executing.Sum()) * 100.0 / 31.0, 0);
                bannerMessages.UtilizationRatioStr = ((int)Math.Round((double)(_executing.Sum()) * 100.0 / 31.0, 0)).ToString() + "%";
            }
            //做管率
            if (_executingAndMaking.Sum() > 0)
            {
                bannerMessages.MakingRatio = (int)Math.Round((double)(_executingAndMaking.Sum()) * 100.0 / 31.0, 1);
                bannerMessages.MakingRatioStr = ((int)Math.Round((double)(_executingAndMaking.Sum()) * 100.0 / 31.0, 1)) + "%";
            }
        }
        #region 大自动机tooltips
        private void ImageDF01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF01Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF01Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(1 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF01.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF01_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF01.DataContext = "";
        }

        private void ImageDF02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF02Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF02Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(2 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF02.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF02_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF02.DataContext = "";
        }

        private void ImageDF03_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF03Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF03Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF03Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF03Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF03Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF03Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(3 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF03.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF03_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF03.DataContext = "";
        }

        private void ImageDF04_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF04Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF04Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF04Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF04Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF04Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF04Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(4 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF04.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF04_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF04.DataContext = "";
        }

        private void ImageDF05_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF05Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF05Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF05Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF05Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF05Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF05Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(5 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF05.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF05_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF05.DataContext = "";
        }

        private void ImageDF06_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machineFlagDF[6].FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machineFlagDF[6].DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machineFlagDF[6].FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machineFlagDF[6].CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machineFlagDF[6].BrushOilTimeSetting.ToString() + "\n";
            if (machineFlagDF[6].getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(6 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF06.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF06_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF06.DataContext = "";
        }

        private void ImageDF07_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF07Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF07Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF07Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF07Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF07Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF07Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(7 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF07.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF07_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF07.DataContext = "";
        }

        private void ImageDF08_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF08Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF08Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF08Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF08Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF08Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF08Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(8 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF08.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF08_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF08.DataContext = "";
        }

        private void ImageDF09_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF09Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF09Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF09Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF09Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF09Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF09Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(9 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF09.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF09_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF09.DataContext = "";
        }

        private void ImageDF10_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF10Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF10Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF10Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF10Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF10Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF10Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(10 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF10.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF10_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF10.DataContext = "";
        }

        private void ImageDF11_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF11Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF11Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF11Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF11Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF11Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF11Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(11 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF11.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF11_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF11.DataContext = "";
        }

        private void ImageDF12_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF12Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF12Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF12Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF12Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF12Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF12Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(12 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF12.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF12_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF12.DataContext = "";
        }

        private void ImageDF13_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF13Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF13Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF13Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF13Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF13Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF13Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(13 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF13.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF13_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF13.DataContext = "";
        }

        private void ImageDF14_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF14Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF14Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF14Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF14Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF14Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF14Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(14 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF14.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF14_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF14.DataContext = "";
        }

        private void ImageDF15_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF15Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF15Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF15Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF15Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF15Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF15Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(15 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF15.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF15_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF15.DataContext = "";
        }

        private void ImageDF16_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF16Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF16Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF16Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF16Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF16Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF16Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(16 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF16.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF16_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF16.DataContext = "";
        }

        private void ImageDF17_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF17Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF17Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF17Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF17Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF17Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF17Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(17 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF17.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF17_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF17.DataContext = "";
        }

        private void ImageDF19_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.DF19Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.DF19Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.DF19Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.DF19Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.DF19Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.DF19Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesDF.GetAlarmMessage(19 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageDF19.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageDF19_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageDF19.DataContext = "";
        }

        #endregion

        #region 小自动机tooltip
        private void ImageSF01_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF01Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF01Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF01Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF01Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF01Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF01Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(1 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF01.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF01_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF01.DataContext = "";
        }

        private void ImageSF02_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF02Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF02Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF02Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF02Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF02Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF02Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(2 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF02.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF02_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF02.DataContext = "";
        }

        private void ImageSF03_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF03Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF03Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF03Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF03Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF03Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF03Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(3 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF03.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF03_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF03.DataContext = "";
        }

        private void ImageSF04_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF04Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF04Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF04Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF04Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF04Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF04Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(4 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF04.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF04_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF04.DataContext = "";
        }

        private void ImageSF05_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF05Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF05Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF05Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF05Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF05Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF05Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(5 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF05.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF05_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF05.DataContext = "";
        }

        private void ImageSF06_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF06Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF06Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF06Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF06Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF06Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF06Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(6 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF06.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF06_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF06.DataContext = "";
        }

        private void ImageSF07_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF07Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF07Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF07Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF07Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF07Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF07Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(7 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF07.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF07_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF07.DataContext = "";
        }

        private void ImageSF08_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF08Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF08Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF08Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF08Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF08Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF08Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(8 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF08.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF08_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF08.DataContext = "";
        }

        private void ImageSF09_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF09Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF09Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF09Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF09Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF09Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF09Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(9 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF09.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF09_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF09.DataContext = "";
        }

        private void ImageSF10_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF10Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF10Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF10Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF10Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF10Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF10Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(10 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF10.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF10_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF10.DataContext = "";
        }

        private void ImageSF11_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF11Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF11Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF11Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF11Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF11Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF11Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(11 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF11.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF11_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF11.DataContext = "";
        }

        private void ImageSF12_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF12Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF12Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF12Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF12Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF12Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF12Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(12 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF12.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF12_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF12.DataContext = "";
        }

        private void ImageSF13_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF13Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF13Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF13Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF13Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF13Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF13Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(13 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF13.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF13_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF13.DataContext = "";
        }

        private void ImageSF14_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SF14Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SF14Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SF14Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SF14Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SF14Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SF14Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(14 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSF14.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSF14_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSF14.DataContext = "";
        }

        private void ImageSE13_MouseEnter(object sender, MouseEventArgs e)
        {
            string str = "机器参数：\n"
                    + "烤模时间设定：" + machinesFlags.SE13Flag.FlareMoldTimeSetting.ToString() + "\n"
                    + "浸料时间设定：" + machinesFlags.SE13Flag.DipingMaterialTimeSetting.ToString() + "\n"
                    + "烤料时间设定：" + machinesFlags.SE13Flag.FlareMaterialTimeSetting.ToString() + "\n"
                    + "冷却时间设定：" + machinesFlags.SE13Flag.CoolingTimeSetting.ToString() + "\n"
                    + "刷油时间设定：" + machinesFlags.SE13Flag.BrushOilTimeSetting.ToString() + "\n";
            if (machinesFlags.SE13Flag.getAlarm() == 1)
            {
                str += "报警信息：" + "\n";
                AlarmMessage am = new AlarmMessage();
                for (int i = 1; i <= 74; i++)
                {
                    am = alarmMessagesSF.GetAlarmMessage(15 * 100 + i);
                    if (am.AlarmFlag)
                    {
                        str = str + am.AlarmMessages + "; " + am.TimeStamp + '\n';
                    }
                }

            }
            toolTipStr = str;
            this.ImageSE13.DataContext = toolTipStr;
            //this.label184.Text = toolTipStr;
        }

        private void ImageSE13_MouseLeave(object sender, MouseEventArgs e)
        {
            toolTipStr = "";
            this.ImageSE13.DataContext = "";
        }
        #endregion
        private void Window_Closing(object sender, CancelEventArgs e)
        {
            cancelTokenSource.Cancel();
            opcClient.Disconnect();
        }
    }
}
