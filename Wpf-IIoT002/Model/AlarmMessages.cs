using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using OPCAutomation;

namespace Wpf_IIoT001
{
    public class AlarmMessage
    {
        private String _machineNo;
        private int _index;
        private Boolean _alarmFlag = false;
        private string _alarmMessage = string.Empty;
        private DateTime _timeStamp;

        public string MachineNo
        {
            get { return _machineNo; }
            set { _machineNo = value; }
        }

        public int Index
        {
            get { return _index; }
            set { _index = value; }
        }
        public Boolean AlarmFlag
        {
            get { return _alarmFlag; }
            set { _alarmFlag = value; }
        }

        public string AlarmMessages
        {
            get { return _alarmMessage; }
            set { _alarmMessage = value; }
        }

        public DateTime TimeStamp
        {
            get { return _timeStamp; }
            set { _timeStamp = value; }
        }
    }

    public class AlarmMessages
    {
        //private AlarmMessage[] alarmMessages=new AlarmMessage[1976] ;
        private List<AlarmMessage> alarmMessages = new List<AlarmMessage>();

        public AlarmMessages()
        {
            //第一排
            //DF07 Index:0
            AddDFAlarmItems("制造车间", "大机#07", "#01", 1);
            //DF06 Index:1
            AddDFAlarmItems("制造车间", "大机#06", "#01", 2);
            //SF08 Index:2
            AddSFAlarmItems("制造车间", "小机#08", "#01", 3);
            //SF07 Index:3
            //_machineFlagDict.Add("制造车间小机#07.#01.状态.机器运行标志", 301);
            AddSFAlarmItems("制造车间", "小机#07", "#01", 4);
            //SF06 Index:4
            AddSFAlarmItems("制造车间", "小机#06", "#01", 5);
            //SF05 Index:5
            AddSFAlarmItems("制造车间", "小机#05", "#01", 6);
            //SF04 Index:6
            AddSFAlarmItems("制造车间", "小机#04", "#01", 7);
            //SF03 Index:7
            AddSFAlarmItems("制造车间", "小机#03", "#01", 8);
            //SF02 Index:8
            AddSFAlarmItems("制造车间", "小机#02", "#01", 9);
            //SF01 Index:9
            AddSFAlarmItems("制造车间", "小机#01", "#01", 10);
            //DF05 Index:10
            AddDFAlarmItems("制造车间", "大机#05", "#01", 11);
            //DF04 Index:11
            AddDFAlarmItems("制造车间", "大机#04", "#01", 12);
            //DF03 Index:12
            AddDFAlarmItems("制造车间", "大机#03", "#01", 13);
            //DF02 Index:13
            AddDFAlarmItems("制造车间", "大机#02", "#01", 14);
            //DF01 Index:14
            AddDFAlarmItems("制造车间", "大机#01", "#01", 15);

            //第二排
            //DF17 Index:15
            AddDFAlarmItems("制造车间", "大机#17", "#01", 17);
            //DF16 Index:16
            AddDFAlarmItems("制造车间", "大机#16", "#01", 17);
            //DF15 Index:17
            AddDFAlarmItems("制造车间", "大机#15", "#01", 18);
            //SF12 Index:18
            AddSFAlarmItems("制造车间", "小机#12", "#01", 19);
            //SF11 Index:19
            AddSFAlarmItems("制造车间", "小机#11", "#01", 20);
            //SF10 Index:20
            AddSFAlarmItems("制造车间", "小机#10", "#01", 21);
            //SF09 Index:22
            AddSFAlarmItems("制造车间", "小机#09", "#01", 22);
            //DF14 Index:22
            AddDFAlarmItems("制造车间", "大机#14", "#01", 23);
            //DF13 Index:23
            AddDFAlarmItems("制造车间", "大机#13", "#01", 24);
            //DF12 Index:24
            AddDFAlarmItems("制造车间", "大机#12", "#01", 25);
            //DF11 Index:25
            AddDFAlarmItems("制造车间", "大机#11", "#01", 26);
            //DF10 Index:26
            AddDFAlarmItems("制造车间", "大机#10", "#01", 27);
            //DF09 Index:27
            AddDFAlarmItems("制造车间", "大机#09", "#01", 28);
            //DF08 Index:28
            AddDFAlarmItems("制造车间", "大机#08", "#01", 29);

            //第三排
            //SF13 Index:29
            AddSFAlarmItems("制造车间", "小机#13", "#01", 30);
            //SF14 Index:30
            AddSFAlarmItems("制造车间", "小机#14", "#01", 31);
            //DF19 Index:31
            //AddDFAlarmItems("制造车间", "大机#19", "#01", 31);
            //SE13 Index:32
            AddSFAlarmItems("制造车间", "手吹小机#14", "#01", 33);
        }

        private void AddDFAlarmItems(string workshop, string machineNo, string plcNo, int index)
        {
            //遍历Enum获取Descriprion
            Type type = typeof(AlarmInfoOfDF);

            foreach (FieldInfo x in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                //string _handleName;
                //int _index;
                string _description = string.Empty;
                object[] array = x.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (array.Length > 0)
                {
                    _description = ((DescriptionAttribute)array[0]).Description;
                    //Console.WriteLine(description);
                }
                else
                {
                    _description = ""; //none description,set empty
                }
                //_handleName = workshop + machineNo + "." + plcNo + ".报警信息." + _description;
                //_index = (int)x.GetValue(null);
                //_alarmFlagDict.Add(_handleName, index * 10000 + (int)x.GetValue(null));
                AlarmMessage alarmMessage = new AlarmMessage();
                alarmMessage.MachineNo = workshop+ machineNo;
                alarmMessage.Index = index * 10000 + (int)x.GetValue(null);
                alarmMessage.AlarmMessages = _description;
                alarmMessages.Add(alarmMessage);
            }
        }

        private void AddSFAlarmItems(string workshop, string machineNo, string plcNo, int index)
        {
            //遍历Enum获取Descriprion
            Type type = typeof(AlarmInfoOfSF);

            foreach (FieldInfo x in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                //string _handleName;
                //int _index;
                string _description = string.Empty;
                object[] array = x.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (array.Length > 0)
                {
                    _description = ((DescriptionAttribute)array[0]).Description;
                    //Console.WriteLine(description);
                }
                else
                {
                    _description = ""; //none description,set empty
                }
                //_handleName = workshop + machineNo + "." + plcNo + ".报警信息." + _description;
                //_index = (int)x.GetValue(null);
                //_alarmFlagDict.Add(_handleName, index * 10000 + (int)x.GetValue(null));
                AlarmMessage alarmMessage = new AlarmMessage();
                alarmMessage.MachineNo = workshop + machineNo;
                alarmMessage.Index = index * 10000 + (int)x.GetValue(null);
                alarmMessage.AlarmMessages = _description;
                alarmMessages.Add(alarmMessage);
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
