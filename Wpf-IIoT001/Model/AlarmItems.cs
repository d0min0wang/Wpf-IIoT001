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
            AddAlarmItems("制造车间","DF", "大机#07", "#01", (int)MachineIndex.DF07);
            //DF06 Index:2
            AddAlarmItems("制造车间", "DF", "大机#06", "#01", (int)MachineIndex.DF06);
            //SF08 Index:3
            AddAlarmItems("制造车间", "SF", "小机#08", "#01", (int)MachineIndex.SF08);
            //SF07 Index:4
            //_machineFlagDict.Add("制造车间小机#07.#01.状态.机器运行标志", 301);
            AddAlarmItems("制造车间", "SF", "小机#07", "#01", (int)MachineIndex.SF07);
            //SF06 Index:5
            AddAlarmItems("制造车间", "SF", "小机#06", "#01", (int)MachineIndex.SF06);
            //SF05 Index:6
            AddAlarmItems("制造车间", "SF", "小机#05", "#01", (int)MachineIndex.SF05);
            //SF04 Index:7
            AddAlarmItems("制造车间", "SF", "小机#04", "#01", (int)MachineIndex.SF04);
            //SF03 Index:8
            AddAlarmItems("制造车间", "SF", "小机#03", "#01", (int)MachineIndex.SF03);
            //SF02 Index:9
            AddAlarmItems("制造车间", "SF", "小机#02", "#01", (int)MachineIndex.SF02);
            //SF01 Index:10
            AddAlarmItems("制造车间", "SF", "小机#01", "#01", (int)MachineIndex.SF01);
            //DF05 Index:11
            AddAlarmItems("制造车间", "DF", "大机#05", "#01", (int)MachineIndex.DF05);
            //DF04 Index:12
            AddAlarmItems("制造车间", "DF", "大机#04", "#01", (int)MachineIndex.DF04);
            //DF03 Index:13
            AddAlarmItems("制造车间", "DF", "大机#03", "#01", (int)MachineIndex.DF03);
            //DF02 Index:14
            AddAlarmItems("制造车间", "DF", "大机#02", "#01", (int)MachineIndex.DF02);
            //DF01 Index:15
            AddAlarmItems("制造车间", "DF", "大机#01", "#01", (int)MachineIndex.DF01);

            //第二排
            //DF17 Index:16
            AddAlarmItems("制造车间", "DF", "大机#17", "#01", (int)MachineIndex.DF17);
            //DF16 Index:17
            AddAlarmItems("制造车间", "DF", "大机#16", "#01", (int)MachineIndex.DF16);
            //DF15 Index:18
            AddAlarmItems("制造车间", "DF", "大机#15", "#01", (int)MachineIndex.DF15);
            //SF12 Index:19
            AddAlarmItems("制造车间", "SF", "小机#12", "#01", (int)MachineIndex.SF12);
            //SF11 Index:20
            AddAlarmItems("制造车间", "SF", "小机#11", "#01", (int)MachineIndex.SF11);
            //SF10 Index:21
            AddAlarmItems("制造车间", "SF", "小机#10", "#01", (int)MachineIndex.SF10);
            //SF09 Index:22
            AddAlarmItems("制造车间", "SF", "小机#09", "#01", (int)MachineIndex.SF09);
            //DF14 Index:23
            AddAlarmItems("制造车间", "DF", "大机#14", "#01", (int)MachineIndex.SF08);
            //DF13 Index:24
            AddAlarmItems("制造车间", "DF", "大机#13", "#01", (int)MachineIndex.DF13);
            //DF12 Index:25
            AddAlarmItems("制造车间", "DF", "大机#12", "#01", (int)MachineIndex.DF12);
            //DF11 Index:26
            AddAlarmItems("制造车间", "DF", "大机#11", "#01", (int)MachineIndex.DF11);
            //DF10 Index:27
            AddAlarmItems("制造车间", "DF", "大机#10", "#01", (int)MachineIndex.DF10);
            //DF09 Index:28
            AddAlarmItems("制造车间", "DF", "大机#09", "#01", (int)MachineIndex.DF09);
            //DF08 Index:29
            AddAlarmItems("制造车间", "DF", "大机#08", "#01", (int)MachineIndex.DF08);

            //第三排
            //SF13 Index:30
            AddAlarmItems("制造车间", "SF", "小机#13", "#01", (int)MachineIndex.SF13);
            //SF14 Index:31
            AddAlarmItems("制造车间", "SF", "小机#14", "#01", (int)MachineIndex.SF14);
            //DF19 Index:32
            //AddAlarmItems("制造车间","DF", "大机#19", "#01", 31);
            //SE13 Index:33
            AddAlarmItems("制造车间", "SE", "手吹小机#13", "#01", (int)MachineIndex.SE13);
        }


        private void AddAlarmItems(string workshop,string machineType, string machineNo, string plcNo, int index)
        {
            Type type=null;
            //遍历Enum获取并添加所有报警信息
            switch(machineType)
            {
                case "DF":
                    type = typeof(AlarmInfoOfDF);
                    break;
                case "SF":
                    type = typeof(AlarmInfoOfSF);
                    break;
                case "SE":
                    type = typeof(AlarmInfoOfSE);
                    break;
            }
            

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
