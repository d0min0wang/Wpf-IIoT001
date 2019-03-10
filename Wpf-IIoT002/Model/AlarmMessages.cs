using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;

namespace Wpf_IIoT001
{
    public class AlarmMessage
    {
        private String machineNo;
        private Boolean alarmFlag = false;
        private string alarmMessage = "";
        private DateTime timeStamp;

        public string MachineNo
        {
            get { return machineNo; }
            set { machineNo = value; }
        }
        public Boolean AlarmFlag
        {
            get { return alarmFlag; }
            set { alarmFlag = value; }
        }

        public string AlarmMessages
        {
            get { return alarmMessage; }
            set { alarmMessage = value; }
        }

        public DateTime TimeStamp
        {
            get { return timeStamp; }
            set { timeStamp = value; }
        }
    }

    public class machineAlarmMessagesDF
    {
        //private AlarmMessage[] alarmMessages=new AlarmMessage[1976] ;
        private List<AlarmMessage> alarmMessages = new List<AlarmMessage>();

        public void InitAlarmMessage()
        {
            for (int i = 0; i <= 1975; i++)
            {
                AlarmMessage alarmMessage = new AlarmMessage();
                alarmMessages.Add(alarmMessage);
                //alarmMessages[i] = new AlarmMessage();
            }

            for (int i = 1; i <= 19; i++)
            {
                alarmMessages[i * 100 + 1].AlarmMessages = "脱膜小车未归边";
                alarmMessages[i * 100 + 2].AlarmMessages = "开机时两个小车不能同时有模具";
                alarmMessages[i * 100 + 3].AlarmMessages = "浸料小车未归边";
                alarmMessages[i * 100 + 4].AlarmMessages = "预热炉1号位无模具";
                alarmMessages[i * 100 + 5].AlarmMessages = "预热炉插销未回零";
                alarmMessages[i * 100 + 6].AlarmMessages = "烤料炉2号位无模具";
                alarmMessages[i * 100 + 7].AlarmMessages = "烤料炉插销未回零";
                alarmMessages[i * 100 + 8].AlarmMessages = "预热炉电机未开启";
                alarmMessages[i * 100 + 9].AlarmMessages = "预热炉2号夹子松开不到位";
                alarmMessages[i * 100 + 10].AlarmMessages = "预热炉2号位无模具";
                alarmMessages[i * 100 + 11].AlarmMessages = "预热炉3号位无模具";
                alarmMessages[i * 100 + 12].AlarmMessages = "预热炉2号夹子夹不到位";
                alarmMessages[i * 100 + 13].AlarmMessages = "烤料炉电机未开启";
                alarmMessages[i * 100 + 14].AlarmMessages = "烤料炉2号夹子松开不到位";
                alarmMessages[i * 100 + 15].AlarmMessages = "水箱位无模具";
                alarmMessages[i * 100 + 16].AlarmMessages = "烤料炉1号位无模具";
                alarmMessages[i * 100 + 17].AlarmMessages = "烤料炉2号夹子夹不到位";
                alarmMessages[i * 100 + 18].AlarmMessages = "脱模机后退不到位";
                alarmMessages[i * 100 + 19].AlarmMessages = "刷油机后退不到位";
                alarmMessages[i * 100 + 20].AlarmMessages = "脱模机前进不到位";
                alarmMessages[i * 100 + 21].AlarmMessages = "刷油机前进不到位";
                alarmMessages[i * 100 + 22].AlarmMessages = "烤料炉伺服电机报警";
                alarmMessages[i * 100 + 23].AlarmMessages = "预热炉伺服电机报警";
                alarmMessages[i * 100 + 24].AlarmMessages = "预热炉前门下降不到位";
                alarmMessages[i * 100 + 25].AlarmMessages = "预热炉后门下降不到位";
                alarmMessages[i * 100 + 26].AlarmMessages = "烤料炉前门下降不到位";
                alarmMessages[i * 100 + 27].AlarmMessages = "烤料炉后门下降不到位";
                alarmMessages[i * 100 + 30].AlarmMessages = "浸料气缸上升不到位";
                alarmMessages[i * 100 + 31].AlarmMessages = "浸料气缸下降不到位";
                alarmMessages[i * 100 + 32].AlarmMessages = "水箱下降不到位";
                alarmMessages[i * 100 + 33].AlarmMessages = "脱模机翻板翻不到位";
                alarmMessages[i * 100 + 34].AlarmMessages = "脱模机不动作";
                alarmMessages[i * 100 + 35].AlarmMessages = "刷油机2个感应器同时接通";
                alarmMessages[i * 100 + 36].AlarmMessages = "浸料气缸2个感应器同时接通";
                alarmMessages[i * 100 + 37].AlarmMessages = "预热炉2号夹子2个感应器同时接通";
                alarmMessages[i * 100 + 38].AlarmMessages = "烤料炉2号夹子2个感应器同时接通";
                alarmMessages[i * 100 + 39].AlarmMessages = "脱模小车前进不到位";
                alarmMessages[i * 100 + 40].AlarmMessages = "脱模小车后退不到位";
                alarmMessages[i * 100 + 41].AlarmMessages = "脱模小车2个或2个以上感应器同时接通";
                alarmMessages[i * 100 + 42].AlarmMessages = "浸料小车前进不到位";
                alarmMessages[i * 100 + 43].AlarmMessages = "浸料小车后退不到位";
                alarmMessages[i * 100 + 44].AlarmMessages = "浸料小车2个或2个以上感应器同时接通";
                alarmMessages[i * 100 + 45].AlarmMessages = "浸料小车前减速开关有问题";
                alarmMessages[i * 100 + 46].AlarmMessages = "浸料小车后减速开关有问题";
                alarmMessages[i * 100 + 47].AlarmMessages = "脱模小车前减速开关有问题";
                alarmMessages[i * 100 + 48].AlarmMessages = "脱模小车后减速开关有问题";
                alarmMessages[i * 100 + 49].AlarmMessages = "浸料小车工件感应有问题";
                alarmMessages[i * 100 + 50].AlarmMessages = "脱模小车工件感应有问题";
                alarmMessages[i * 100 + 51].AlarmMessages = "烤料炉1号夹子松开不到位";
                alarmMessages[i * 100 + 52].AlarmMessages = "烤料炉1号夹子夹不到位";
                alarmMessages[i * 100 + 53].AlarmMessages = "预热炉1号夹子松开不到位";
                alarmMessages[i * 100 + 54].AlarmMessages = "预热炉1号夹子夹不到位";
                alarmMessages[i * 100 + 55].AlarmMessages = "预热炉1号夹子2个感应器同时接通";
                alarmMessages[i * 100 + 56].AlarmMessages = "烤料炉1号夹子2个感应器同时接通";
                alarmMessages[i * 100 + 57].AlarmMessages = "脱膜小车驱动器报警";
                alarmMessages[i * 100 + 58].AlarmMessages = "浸料小车驱动器报警";
                alarmMessages[i * 100 + 59].AlarmMessages = "脱膜小车出炉定位有问题";
                alarmMessages[i * 100 + 60].AlarmMessages = "浸料小车出炉定位有问题";
                alarmMessages[i * 100 + 61].AlarmMessages = "8个工件感应有问题";
                alarmMessages[i * 100 + 62].AlarmMessages = "机器没有动作，请重新启动";
                alarmMessages[i * 100 + 67].AlarmMessages = "没有料了，请及时加料";
                alarmMessages[i * 100 + 68].AlarmMessages = "初始化完成";
                alarmMessages[i * 100 + 69].AlarmMessages = "设定产量已到达";
                alarmMessages[i * 100 + 71].AlarmMessages = "浸料机已开，但脱模机没有开";
                alarmMessages[i * 100 + 72].AlarmMessages = "请注意: 这板模有管没脱掉";
                alarmMessages[i * 100 + 73].AlarmMessages = "浸料机已开，但水箱没有开";
                alarmMessages[i * 100 + 74].AlarmMessages = "由于长时间不做管，系统自动关炉子，请重新开炉子做管";
                for (int j = 1; j <= 74; j++)
                {
                    alarmMessages[i * 100 + j].MachineNo = "DF#" + i.ToString("00");
                }
            }
        }

        public AlarmMessage GetAlarmMessage(int position)
        {
            return alarmMessages[position];
        }
        public void SetAlarmMessage(int position, Boolean alarmflag, DateTime timestamp)
        {
            alarmMessages[position].AlarmFlag = alarmflag;
            alarmMessages[position].TimeStamp = timestamp;
        }
    }

    public class machineAlarmMessagesSF
    {
        private List<AlarmMessage> alarmMessages = new List<AlarmMessage>();

        public void InitAlarmMessage()
        {

            for (int i = 0; i <= 1435; i++)
            {
                AlarmMessage alarmMessage = new AlarmMessage();
                alarmMessages.Add(alarmMessage);
            }

            for (int i = 1; i <= 14; i++)
            {
                alarmMessages[i * 100 + 1].AlarmMessages = "模具小车没到脱膜机位置，请注意。";
                alarmMessages[i * 100 + 2].AlarmMessages = "脱模机感应器出问题，请检查。";
                alarmMessages[i * 100 + 3].AlarmMessages = "刷油机感应器出问题，请检查。";
                alarmMessages[i * 100 + 4].AlarmMessages = "浸料气缸感应器出问题，请检查。";
                alarmMessages[i * 100 + 5].AlarmMessages = "脱膜气缸感应器出问题，请检查。";
                alarmMessages[i * 100 + 6].AlarmMessages = "脱膜气缸下降出问题，请检查。";
                alarmMessages[i * 100 + 7].AlarmMessages = "脱膜气缸上升出问题，请检查。";
                alarmMessages[i * 100 + 8].AlarmMessages = "浸料气缸下降出问题，请检查。";
                alarmMessages[i * 100 + 9].AlarmMessages = "浸料气缸上升出问题，请检查。";
                alarmMessages[i * 100 + 10].AlarmMessages = "刷油机前行出问题，请检查。";
                alarmMessages[i * 100 + 11].AlarmMessages = "刷油机后行出问题，请检查。";
                alarmMessages[i * 100 + 12].AlarmMessages = "模具小车没到刷油机位置，请注意。";
                alarmMessages[i * 100 + 13].AlarmMessages = "水箱出问题，请检查。";
                alarmMessages[i * 100 + 14].AlarmMessages = "前炉门出问题，请检查。";
                alarmMessages[i * 100 + 15].AlarmMessages = "模具小车没到水箱位置，请注意。";
                alarmMessages[i * 100 + 16].AlarmMessages = "后炉门出问题，请检查。";
                alarmMessages[i * 100 + 17].AlarmMessages = "模具小车没到炉子位置，请注意。";
                alarmMessages[i * 100 + 18].AlarmMessages = "模具小车没到浸料机位置，请注意。";
                alarmMessages[i * 100 + 19].AlarmMessages = "伺服电机报警，请关电重启。";
                alarmMessages[i * 100 + 20].AlarmMessages = "浸料机驱动器报警，请断电重启。";
                alarmMessages[i * 100 + 21].AlarmMessages = "脱膜机前进出问题，请检查。";
                alarmMessages[i * 100 + 22].AlarmMessages = "脱模机后退出问题，请检查。";
                alarmMessages[i * 100 + 23].AlarmMessages = "伺服电机已关，请打开。";
                alarmMessages[i * 100 + 24].AlarmMessages = "浸料机液面感应器出问题，请检查。";
                alarmMessages[i * 100 + 25].AlarmMessages = "浸料机下降一速应该大于二速，请重新设定。";
                alarmMessages[i * 100 + 26].AlarmMessages = "急停已按下，请注意。";
                alarmMessages[i * 100 + 27].AlarmMessages = "伺服电机没有回零点。";
                alarmMessages[i * 100 + 28].AlarmMessages = "机器没有动作，请重新启动。";
                alarmMessages[i * 100 + 33].AlarmMessages = "浸料机没有料了，请加料。";
                alarmMessages[i * 100 + 34].AlarmMessages = "产量已完成，请注意。";
                alarmMessages[i * 100 + 35].AlarmMessages = "由于长时间不做管，系统自动关炉子，请重新开炉子做管。";
                for (int j = 1; j <= 35; j++)
                {
                    alarmMessages[i * 100 + j].MachineNo = "SF#" + i.ToString("00");
                }
            }
        }

        public AlarmMessage GetAlarmMessage(int position)
        {
            return alarmMessages[position];
        }
        public void SetAlarmMessage(int position, Boolean alarmflag, DateTime timestamp)
        {
            alarmMessages[position].AlarmFlag = alarmflag;
            alarmMessages[position].TimeStamp = timestamp;
        }
    }
}
