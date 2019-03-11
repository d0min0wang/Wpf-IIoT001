using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;

namespace Wpf_IIoT001
{
    public class AlarmItems:IDisposable
    {
        //机器报警位字典
        private Dictionary<string, int> _alarmFlagDict = new Dictionary<string, int>();

        public AlarmItems()
        {
            //第一排
            //DF07 Index:1
            AddDFAlarmItems("制造车间", "大机#07", "#01", 1);
            //DF06 Index:2
            AddDFAlarmItems("制造车间", "大机#06", "#01", 2);
            //SF08 Index:3
            AddSFAlarmItems("制造车间", "小机#08", "#01", 3);
            //SF07 Index:4
            //_machineFlagDict.Add("制造车间小机#07.#01.状态.机器运行标志", 301);
            AddSFAlarmItems("制造车间", "小机#07", "#01", 4);
            //SF06 Index:5
            AddSFAlarmItems("制造车间", "小机#06", "#01", 5);
            //SF05 Index:6
            AddSFAlarmItems("制造车间", "小机#05", "#01", 6);
            //SF04 Index:7
            AddSFAlarmItems("制造车间", "小机#04", "#01", 7);
            //SF03 Index:8
            AddSFAlarmItems("制造车间", "小机#03", "#01", 8);
            //SF02 Index:9
            AddSFAlarmItems("制造车间", "小机#02", "#01", 9);
            //SF01 Index:10
            AddSFAlarmItems("制造车间", "小机#01", "#01", 10);
            //DF05 Index:11
            AddDFAlarmItems("制造车间", "大机#05", "#01", 11);
            //DF04 Index:12
            AddDFAlarmItems("制造车间", "大机#04", "#01", 12);
            //DF03 Index:13
            AddDFAlarmItems("制造车间", "大机#03", "#01", 13);
            //DF02 Index:14
            AddDFAlarmItems("制造车间", "大机#02", "#01", 14);
            //DF01 Index:15
            AddDFAlarmItems("制造车间", "大机#01", "#01", 15);

            //第二排
            //DF17 Index:16
            AddDFAlarmItems("制造车间", "大机#17", "#01", 16);
            //DF16 Index:17
            AddDFAlarmItems("制造车间", "大机#16", "#01", 17);
            //DF15 Index:18
            AddDFAlarmItems("制造车间", "大机#15", "#01", 18);
            //SF12 Index:19
            AddSFAlarmItems("制造车间", "小机#12", "#01", 19);
            //SF11 Index:20
            AddSFAlarmItems("制造车间", "小机#11", "#01", 20);
            //SF10 Index:21
            AddSFAlarmItems("制造车间", "小机#10", "#01", 21);
            //SF09 Index:22
            AddSFAlarmItems("制造车间", "小机#09", "#01", 22);
            //DF14 Index:23
            AddDFAlarmItems("制造车间", "大机#14", "#01", 23);
            //DF13 Index:24
            AddDFAlarmItems("制造车间", "大机#13", "#01", 24);
            //DF12 Index:25
            AddDFAlarmItems("制造车间", "大机#12", "#01", 25);
            //DF11 Index:26
            AddDFAlarmItems("制造车间", "大机#11", "#01", 26);
            //DF10 Index:27
            AddDFAlarmItems("制造车间", "大机#10", "#01", 27);
            //DF09 Index:28
            AddDFAlarmItems("制造车间", "大机#09", "#01", 28);
            //DF08 Index:29
            AddDFAlarmItems("制造车间", "大机#08", "#01", 29);

            //第三排
            //SF13 Index:30
            AddSFAlarmItems("制造车间", "小机#13", "#01", 30);
            //SF14 Index:31
            AddSFAlarmItems("制造车间", "小机#14", "#01", 31);
            //DF19 Index:32
            //AddDFAlarmItems("制造车间", "大机#19", "#01", 31);
            //SE13 Index:33
            AddSFAlarmItems("制造车间", "手吹小机#13", "#01", 33);
        }


        private void AddDFAlarmItems(string workshop, string machineNo, string plcNo, int index)
        {
            //遍历Enum获取Descriprion
            Type type = typeof(AlarmInfoOfDF);

            foreach (FieldInfo x in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                string _handleName;
                string _description = string.Empty;
                object[] array = x.GetCustomAttributes(typeof(DescriptionAttribute), false);
                if (array.Length > 0)
                {
                    _description = ((DescriptionAttribute)array[0]).Description;
                }
                else
                {
                    _description = ""; //none description,set empty
                }
                _handleName = workshop + machineNo + "." + plcNo + ".报警信息." + _description;
                _alarmFlagDict.Add(_handleName, index * 10000 + (int)x.GetValue(null));
                //初始化报警信息List
                AlarmMessage alarmMessage = new AlarmMessage();
                alarmMessage.MachineNo = machineNo;
                alarmMessage.Index = index * 10000 + (int)x.GetValue(null);
                alarmMessage.AlarmMessages = _description;
                GlobalVars.alarmMessages.Add(alarmMessage);
            }
        }

        private void AddSFAlarmItems(string workshop, string machineNo, string plcNo, int index)
        {
            Type type = typeof(AlarmInfoOfSF);

            foreach (FieldInfo x in type.GetFields(BindingFlags.Public | BindingFlags.Static))
            {
                string _handleName;
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
                _handleName = workshop + machineNo + "." + plcNo + ".报警信息." + _description;
                _alarmFlagDict.Add(_handleName, index * 10000 + (int)x.GetValue(null));
                //初始化报警信息List
                AlarmMessage alarmMessage = new AlarmMessage();
                alarmMessage.MachineNo = machineNo;
                alarmMessage.Index = index * 10000 + (int)x.GetValue(null);
                alarmMessage.AlarmMessages = _description;
                GlobalVars.alarmMessages.Add(alarmMessage);
            }
        }

        public Dictionary<string, int> getAlarmFlagDict()
        {
            return _alarmFlagDict;
        }

        #region IDisposable Support
        private bool disposedValue = false; // 要检测冗余调用

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: 释放托管状态(托管对象)。
                }

                // TODO: 释放未托管的资源(未托管的对象)并在以下内容中替代终结器。
                // TODO: 将大型字段设置为 null。
                _alarmFlagDict = null;
                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~AlarmItems() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            // GC.SuppressFinalize(this);
        }
        #endregion

        #region 遍历enum并获取Description
        //Type type = typeof(AlarmInfoOfDF);

        //    foreach (FieldInfo x in type.GetFields(BindingFlags.Public | BindingFlags.Static))
        //    {
        //        string description = string.Empty;
        //object[] array = x.GetCustomAttributes(typeof(DescriptionAttribute), false);
        //        if (array.Length > 0)
        //        {
        //            description = ((DescriptionAttribute) array[0]).Description;
        //            Console.WriteLine(description);
        //        }
        //        else
        //        {
        //            description = ""; //none description,set empty
        //        }
        //    }
        #endregion
    }
}
