using System;
using System.Collections.Generic;
using System.Linq;
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
            AddS7_200Items("制造车间", "大机#07", "#01", (int)MachineIndex.DF07);
            //DF06 Index:1
            AddS7_200Items("制造车间", "大机#06", "#01", (int)MachineIndex.DF06);
            //SF08 Index:2
            AddS7_200Items("制造车间", "小机#08", "#01", (int)MachineIndex.SF08);
            //SF07 Index:3
            //_machineFlagDict.Add("制造车间小机#07.#01.状态.机器运行标志", 301);
            AddS7_200Items("制造车间", "小机#07", "#01", (int)MachineIndex.SF07);
            //SF06 Index:4
            AddS7_200Items("制造车间", "小机#06", "#01", (int)MachineIndex.SF06);
            //SF05 Index:5
            AddS7_200Items("制造车间", "小机#05", "#01", (int)MachineIndex.SF05);
            //SF04 Index:6
            AddS7_200Items("制造车间", "小机#04", "#01", (int)MachineIndex.SF04);
            //SF03 Index:7
            AddS7_200Items("制造车间", "小机#03", "#01", (int)MachineIndex.SF03);
            //SF02 Index:8
            AddS7_200Items("制造车间", "小机#02", "#01", (int)MachineIndex.SF02);
            //SF01 Index:9
            AddS7_200Items("制造车间", "小机#01", "#01", (int)MachineIndex.SF01);
            //DF05 Index:10
            AddS7_200Items("制造车间", "大机#05", "#01", (int)MachineIndex.DF05);
            //DF04 Index:11
            AddS7_200Items("制造车间", "大机#04", "#01", (int)MachineIndex.DF04);
            //DF03 Index:12
            AddS7_200Items("制造车间", "大机#03", "#01", (int)MachineIndex.DF03);
            //DF02 Index:13
            AddS7_200Items("制造车间", "大机#02", "#01", (int)MachineIndex.DF02);
            //DF01 Index:14
            AddS7_200Items("制造车间", "大机#01", "#01", (int)MachineIndex.DF01);

            //第二排
            //DF17 Index:15
            AddS7_200Items("制造车间", "大机#17", "#01", (int)MachineIndex.DF17);
            //DF16 Index:16
            AddS7_200Items("制造车间", "大机#16", "#01", (int)MachineIndex.DF16);
            //DF15 Index:17
            AddS7_200Items("制造车间", "大机#15", "#01", (int)MachineIndex.DF15);
            //SF12 Index:18
            AddS7_200Items("制造车间", "小机#12", "#01", (int)MachineIndex.SF12);
            //SF11 Index:19
            AddS7_200Items("制造车间", "小机#11", "#01", (int)MachineIndex.SF11);
            //SF10 Index:20
            AddS7_200Items("制造车间", "小机#10", "#01", (int)MachineIndex.SF10);
            //SF09 Index:21
            AddS7_200Items("制造车间", "小机#09", "#01", (int)MachineIndex.SF09);
            //DF14 Index:22
            AddS7_200Items("制造车间", "大机#14", "#01", (int)MachineIndex.DF14);
            //DF13 Index:23
            AddS7_200Items("制造车间", "大机#13", "#01", (int)MachineIndex.DF13);
            //DF12 Index:24
            AddS7_200Items("制造车间", "大机#12", "#01", (int)MachineIndex.DF12);
            //DF11 Index:25
            AddS7_200Items("制造车间", "大机#11", "#01", (int)MachineIndex.DF11);
            //DF10 Index:26
            AddS7_200Items("制造车间", "大机#10", "#01", (int)MachineIndex.DF10);
            //DF09 Index:27
            AddS7_200Items("制造车间", "大机#09", "#01", (int)MachineIndex.DF09);
            //DF08 Index:28
            AddS7_200Items("制造车间", "大机#08", "#01", (int)MachineIndex.DF08);

            //第三排
            //SF13 Index:29
            AddS7_200Items("制造车间", "小机#13", "#01", (int)MachineIndex.SF13);
            //SF14 Index:30
            AddS7_200Items("制造车间", "小机#14", "#01", (int)MachineIndex.SF14);
            //DF19 Index:31
            AddS7_1200Items("制造车间", "大机#19", "#01", (int)MachineIndex.DF19);
            //SE13 Index:32
            AddS7_200Items("制造车间", "手吹小机#13", "#01", (int)MachineIndex.SE13);
        }

        private void AddS7_200Items(string workshop,string machineNo,string plcNo,int index)
        {
            string _handleName;
            _handleName = workshop + machineNo + "." + plcNo + ".状态.机器运行标志";
            _machineFlagDict.Add(_handleName, index * 100 + 1);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.炉子电源开关";
            _machineFlagDict.Add(_handleName, index * 100 + 2);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.升料机开关";
            _machineFlagDict.Add(_handleName, index * 100 + 3);

            _handleName = workshop + machineNo + "." + plcNo + ".报警信息.报警提示";
            _machineFlagDict.Add(_handleName, index * 100 + 4);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.烤模时间设定";
            _machineFlagDict.Add(_handleName, index * 100 + 5);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.浸料时间设定";
            _machineFlagDict.Add(_handleName, index * 100 + 6);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.烤料时间设定";
            _machineFlagDict.Add(_handleName, index * 100 + 7);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.冷却时间设定";
            _machineFlagDict.Add(_handleName, index * 100 + 8);
        }

        private void AddS7_1200Items(string workshop, string machineNo, string plcNo, int index)
        {
            string _handleName;
            _handleName = workshop + machineNo + "." + plcNo + ".状态.机器运行标志";
            _machineFlagDict.Add(_handleName, index * 100 + 1);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.烤模炉子电源开关";
            _machineFlagDict.Add(_handleName, index * 100 + 2);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.升料机开关";
            _machineFlagDict.Add(_handleName, index * 100 + 3);

            _handleName = workshop + machineNo + "." + plcNo + ".报警信息.报警提示";
            _machineFlagDict.Add(_handleName, index * 100 + 4);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.烤模时间设定";
            _machineFlagDict.Add(_handleName, index * 100 + 5);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.浸料时间设定";
            _machineFlagDict.Add(_handleName, index * 100 + 6);

            _handleName = workshop + machineNo + ".#02" + ".状态.烤料时间设定";
            _machineFlagDict.Add(_handleName, index * 100 + 7);

            _handleName = workshop + machineNo + ".#02" + ".状态.冷却时间设定";
            _machineFlagDict.Add(_handleName, index * 100 + 8);

            _handleName = workshop + machineNo + "." + plcNo + ".状态.烤料炉子电源开关";
            _machineFlagDict.Add(_handleName, index * 100 + 9);
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
