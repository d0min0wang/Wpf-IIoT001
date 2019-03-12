using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_IIoT001
{
    public class machineItems:IDisposable
    {
        //机器状态位字典
        private Dictionary<string, int> _machineFlagDict=new Dictionary<string, int>();

        //机器状态位置类的构造函数
        public machineItems()
        {
            //第一排
            //DF07 Index:0
            AddStatusItems("制造车间","S7-200", "大机#07", (int)MachineIndex.DF07);
            //DF06 Index:1
            AddStatusItems("制造车间", "S7-200", "大机#06", (int)MachineIndex.DF06);
            //SF08 Index:2
            AddStatusItems("制造车间", "S7-200", "小机#08",(int)MachineIndex.SF08);
            //SF07 Index:3
            //_machineFlagDict.Add("制造车间小机#07.#01.状态.机器运行标志", 301);
            AddStatusItems("制造车间","S7-200", "小机#07", (int)MachineIndex.SF07);
            //SF06 Index:4
            AddStatusItems("制造车间", "S7-200", "小机#06",  (int)MachineIndex.SF06);
            //SF05 Index:5
            AddStatusItems("制造车间", "S7-200", "小机#05",  (int)MachineIndex.SF05);
            //SF04 Index:6
            AddStatusItems("制造车间", "S7-200", "小机#04",  (int)MachineIndex.SF04);
            //SF03 Index:7
            AddStatusItems("制造车间", "S7-200", "小机#03",  (int)MachineIndex.SF03);
            //SF02 Index:8
            AddStatusItems("制造车间", "S7-200", "小机#02",  (int)MachineIndex.SF02);
            //SF01 Index:9
            AddStatusItems("制造车间", "S7-200", "小机#01",  (int)MachineIndex.SF01);
            //DF05 Index:10
            AddStatusItems("制造车间", "S7-200", "大机#05",  (int)MachineIndex.DF05);
            //DF04 Index:11
            AddStatusItems("制造车间", "S7-200", "大机#04",  (int)MachineIndex.DF04);
            //DF03 Index:12
            AddStatusItems("制造车间", "S7-200", "大机#03",  (int)MachineIndex.DF03);
            //DF02 Index:13
            AddStatusItems("制造车间", "S7-200","大机#02",  (int)MachineIndex.DF02);
            //DF01 Index:14
            AddStatusItems("制造车间", "S7-200","大机#01",  (int)MachineIndex.DF01);

            //第二排
            //DF17 Index:15
            AddStatusItems("制造车间", "S7-200", "大机#17",  (int)MachineIndex.DF17);
            //DF16 Index:16
            AddStatusItems("制造车间", "S7-200","大机#16",  (int)MachineIndex.DF16);
            //DF15 Index:17
            AddStatusItems("制造车间", "S7-200", "大机#15",  (int)MachineIndex.DF15);
            //SF12 Index:18
            AddStatusItems("制造车间", "S7-200", "小机#12",  (int)MachineIndex.SF12);
            //SF11 Index:19
            AddStatusItems("制造车间", "S7-200", "小机#11",  (int)MachineIndex.SF11);
            //SF10 Index:20
            AddStatusItems("制造车间", "S7-200","小机#10",  (int)MachineIndex.SF10);
            //SF09 Index:21
            AddStatusItems("制造车间", "S7-200","小机#09",  (int)MachineIndex.SF09);
            //DF14 Index:22
            AddStatusItems("制造车间", "S7-200","大机#14",  (int)MachineIndex.DF14);
            //DF13 Index:23
            AddStatusItems("制造车间", "S7-200", "大机#13",  (int)MachineIndex.DF13);
            //DF12 Index:24
            AddStatusItems("制造车间", "S7-200", "大机#12",  (int)MachineIndex.DF12);
            //DF11 Index:25
            AddStatusItems("制造车间", "S7-200","大机#11",  (int)MachineIndex.DF11);
            //DF10 Index:26
            AddStatusItems("制造车间", "S7-200","大机#10",  (int)MachineIndex.DF10);
            //DF09 Index:27
            AddStatusItems("制造车间", "S7-200","大机#09",  (int)MachineIndex.DF09);
            //DF08 Index:28
            AddStatusItems("制造车间", "S7-200","大机#08",  (int)MachineIndex.DF08);

            //第三排
            //SF13 Index:29
            AddStatusItems("制造车间", "S7-200","小机#13",  (int)MachineIndex.SF13);
            //SF14 Index:30
            AddStatusItems("制造车间", "S7-200","小机#14",  (int)MachineIndex.SF14);
            //DF19 Index:31
            AddStatusItems("制造车间", "S7-1200", "大机#19",  (int)MachineIndex.DF19);
            //SE13 Index:32
            AddStatusItems("制造车间", "S7-200","手吹小机#13",  (int)MachineIndex.SE13);
        }

        private void AddStatusItems(string workshop, string plcType, string machineNo, int index)
        {
            Type type = null;
            //遍历Enum获取并添加所有报警信息
            switch (plcType)
            {
                case "S7-200":
                    type = typeof(S7200StatusInfo);
                    break;
                case "S7-1200":
                    type = typeof(S71200StatusInfo);
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
                _handleName = workshop + machineNo + "." + _description;
                _machineFlagDict.Add(_handleName, index * 100 + (int)x.GetValue(null));
            }
        }

        public Dictionary<string, int> getMachineFlagDict()
        {
            return _machineFlagDict;
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
                _machineFlagDict = null;

                disposedValue = true;
            }
        }

        // TODO: 仅当以上 Dispose(bool disposing) 拥有用于释放未托管资源的代码时才替代终结器。
        // ~machineItems() {
        //   // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
        //   Dispose(false);
        // }

        // 添加此代码以正确实现可处置模式。
        public void Dispose()
        {
            // 请勿更改此代码。将清理代码放入以上 Dispose(bool disposing) 中。
            Dispose(true);
            // TODO: 如果在以上内容中替代了终结器，则取消注释以下行。
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
