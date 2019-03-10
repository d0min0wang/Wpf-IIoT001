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
            //研发二楼车间
            //DY04 Index:0
            _machineFlagDict.Add("研发楼二楼车间DY04.#01.状态.机器运行标志", 1);
            _machineFlagDict.Add("研发楼二楼车间DY04.#01.状态.炉子电源开关", 2);
            _machineFlagDict.Add("研发楼二楼车间DY04.#01.状态.升料机开关", 3);
            _machineFlagDict.Add("研发楼二楼车间DY04.#01.报警信息.报警提示", 4);
            //DY03 Index:1
            _machineFlagDict.Add("研发楼二楼车间DY03.#01.状态.机器运行标志", 101);
            _machineFlagDict.Add("研发楼二楼车间DY03.#01.状态.炉子电源开关", 102);
            _machineFlagDict.Add("研发楼二楼车间DY03.#01.状态.升料机开关", 103);
            _machineFlagDict.Add("研发楼二楼车间DY03.#01.报警信息.报警提示", 104);
            //DY02 Index:2
            _machineFlagDict.Add("研发楼二楼车间DY02.#01.状态.机器运行标志", 201);
            _machineFlagDict.Add("研发楼二楼车间DY02.#01.状态.炉子电源开关", 202);
            _machineFlagDict.Add("研发楼二楼车间DY02.#01.状态.升料机开关", 203);
            _machineFlagDict.Add("研发楼二楼车间DY02.#01.报警信息.报警提示", 204);
            //DY01 Index:3
            _machineFlagDict.Add("研发楼二楼车间DY01.#01.状态.机器运行标志", 301);
            _machineFlagDict.Add("研发楼二楼车间DY01.#01.状态.炉子电源开关", 302);
            _machineFlagDict.Add("研发楼二楼车间DY01.#01.状态.升料机开关", 303);
            _machineFlagDict.Add("研发楼二楼车间DY01.#01.报警信息.报警提示", 304);
            //SG01 Index:4
            _machineFlagDict.Add("研发楼二楼车间SG01.#01.状态.机器运行标志", 401);
            _machineFlagDict.Add("研发楼二楼车间SG01.#01.状态.炉子电源开关", 402);
            _machineFlagDict.Add("研发楼二楼车间SG01.#01.状态.升料机开关", 403);
            _machineFlagDict.Add("研发楼二楼车间SG01.#01.报警信息.报警提示", 404);
            //SG02 Index:5
            _machineFlagDict.Add("研发楼二楼车间SG02.#01.状态.机器运行标志", 501);
            _machineFlagDict.Add("研发楼二楼车间SG02.#01.状态.炉子电源开关", 502);
            _machineFlagDict.Add("研发楼二楼车间SG02.#01.状态.升料机开关", 503);
            _machineFlagDict.Add("研发楼二楼车间SG02.#01.报警信息.报警提示", 504);
            //SG03 Index:6
            _machineFlagDict.Add("研发楼二楼车间SG03.#01.状态.机器运行标志", 601);
            _machineFlagDict.Add("研发楼二楼车间SG03.#01.状态.炉子电源开关", 602);
            _machineFlagDict.Add("研发楼二楼车间SG03.#01.状态.升料机开关", 603);
            _machineFlagDict.Add("研发楼二楼车间SG03.#01.报警信息.报警提示", 604);
            //SE14 Index:7
            _machineFlagDict.Add("研发楼二楼车间SE14.#01.状态.机器运行标志", 701);
            _machineFlagDict.Add("研发楼二楼车间SE14.#01.状态.炉子电源开关", 702);
            _machineFlagDict.Add("研发楼二楼车间SE14.#01.状态.升料机开关", 703);
            _machineFlagDict.Add("研发楼二楼车间SE14.#01.报警信息.报警提示", 704);
            //SE12 Index:8
            _machineFlagDict.Add("研发楼二楼车间SE12.#01.状态.机器运行标志", 801);
            _machineFlagDict.Add("研发楼二楼车间SE12.#01.状态.炉子电源开关", 802);
            _machineFlagDict.Add("研发楼二楼车间SE12.#01.状态.升料机开关", 803);
            _machineFlagDict.Add("研发楼二楼车间SE12.#01.报警信息.报警提示", 804);
            //SE11 Index:9
            _machineFlagDict.Add("研发楼二楼车间SE11.#01.状态.机器运行标志", 901);
            _machineFlagDict.Add("研发楼二楼车间SE11.#01.状态.炉子电源开关", 902);
            _machineFlagDict.Add("研发楼二楼车间SE11.#01.状态.升料机开关", 903);
            _machineFlagDict.Add("研发楼二楼车间SE11.#01.报警信息.报警提示", 904);
            //SY01 Index:10
            _machineFlagDict.Add("研发楼二楼车间SY01.#01.状态.机器运行标志", 1001);
            _machineFlagDict.Add("研发楼二楼车间SY01.#01.状态.炉子电源开关", 1002);
            _machineFlagDict.Add("研发楼二楼车间SY01.#01.状态.升料机开关", 1003);
            _machineFlagDict.Add("研发楼二楼车间SY01.#01.报警信息.报警提示", 1004);
            //研发二楼洁净车间
            //DE03 Index:11
            _machineFlagDict.Add("研发楼二楼洁净车间DE03.#01.状态.机器运行标志", 1101);
            _machineFlagDict.Add("研发楼二楼洁净车间DE03.#01.状态.烤模炉子电源开关", 1102);
            _machineFlagDict.Add("研发楼二楼洁净车间DE03.#01.状态.升料机开关", 1103);
            _machineFlagDict.Add("研发楼二楼洁净车间DE03.#01.报警信息.报警提示", 1104);
            _machineFlagDict.Add("研发楼二楼洁净车间DE03.#01.状态.烤料炉子电源开关", 1105);
            //DE02 Index:12
            _machineFlagDict.Add("研发楼二楼洁净车间DE02.#01.状态.机器运行标志", 1201);
            _machineFlagDict.Add("研发楼二楼洁净车间DE02.#01.状态.烤模炉子电源开关", 1202);
            _machineFlagDict.Add("研发楼二楼洁净车间DE02.#01.状态.升料机开关", 1203);
            _machineFlagDict.Add("研发楼二楼洁净车间DE02.#01.报警信息.报警提示", 1204);
            _machineFlagDict.Add("研发楼二楼洁净车间DE02.#01.状态.烤料炉子电源开关", 1205);
            //DE01 Index:13
            _machineFlagDict.Add("研发楼二楼洁净车间DE01.#01.状态.机器运行标志", 1301);
            _machineFlagDict.Add("研发楼二楼洁净车间DE01.#01.状态.烤模炉子电源开关", 1302);
            _machineFlagDict.Add("研发楼二楼洁净车间DE01.#01.状态.升料机开关", 1303);
            _machineFlagDict.Add("研发楼二楼洁净车间DE01.#01.报警信息.报警提示", 1304);
            _machineFlagDict.Add("研发楼二楼洁净车间DE01.#01.状态.烤料炉子电源开关", 1305);
            //SE08 Index:14
            _machineFlagDict.Add("研发楼二楼洁净车间SE08.#01.状态.机器运行标志", 1401);
            _machineFlagDict.Add("研发楼二楼洁净车间SE08.#01.状态.炉子电源开关", 1402);
            _machineFlagDict.Add("研发楼二楼洁净车间SE08.#01.状态.升料机开关", 1403);
            _machineFlagDict.Add("研发楼二楼洁净车间SE08.#01.报警信息.报警提示", 1404);
            //SE07 Index:15
            _machineFlagDict.Add("研发楼二楼洁净车间SE07.#01.状态.机器运行标志", 1501);
            _machineFlagDict.Add("研发楼二楼洁净车间SE07.#01.状态.炉子电源开关", 1502);
            _machineFlagDict.Add("研发楼二楼洁净车间SE07.#01.状态.升料机开关", 1503);
            _machineFlagDict.Add("研发楼二楼洁净车间SE07.#01.报警信息.报警提示", 1504);
            //SE06 Index:16
            _machineFlagDict.Add("研发楼二楼洁净车间SE06.#01.状态.机器运行标志", 1601);
            _machineFlagDict.Add("研发楼二楼洁净车间SE06.#01.状态.炉子电源开关", 1602);
            _machineFlagDict.Add("研发楼二楼洁净车间SE06.#01.状态.升料机开关", 1603);
            _machineFlagDict.Add("研发楼二楼洁净车间SE06.#01.报警信息.报警提示", 1604);
            //SE05 Index:17
            _machineFlagDict.Add("研发楼二楼洁净车间SE05.#01.状态.机器运行标志", 1701);
            _machineFlagDict.Add("研发楼二楼洁净车间SE05.#01.状态.炉子电源开关", 1702);
            _machineFlagDict.Add("研发楼二楼洁净车间SE05.#01.状态.升料机开关", 1703);
            _machineFlagDict.Add("研发楼二楼洁净车间SE05.#01.报警信息.报警提示", 1704);
            //SE04 Index:18
            _machineFlagDict.Add("研发楼二楼洁净车间SE04.#01.状态.机器运行标志", 1801);
            _machineFlagDict.Add("研发楼二楼洁净车间SE04.#01.状态.炉子电源开关", 1802);
            _machineFlagDict.Add("研发楼二楼洁净车间SE04.#01.状态.升料机开关", 1803);
            _machineFlagDict.Add("研发楼二楼洁净车间SE04.#01.报警信息.报警提示", 1804);
            //SE03 Index:19
            _machineFlagDict.Add("研发楼二楼洁净车间SE03.#01.状态.机器运行标志", 1901);
            _machineFlagDict.Add("研发楼二楼洁净车间SE03.#01.状态.炉子电源开关", 1902);
            _machineFlagDict.Add("研发楼二楼洁净车间SE03.#01.状态.升料机开关", 1903);
            _machineFlagDict.Add("研发楼二楼洁净车间SE03.#01.报警信息.报警提示", 1904);
            //SE02 Index:20
            _machineFlagDict.Add("研发楼二楼洁净车间SE02.#01.状态.机器运行标志", 2001);
            _machineFlagDict.Add("研发楼二楼洁净车间SE02.#01.状态.炉子电源开关", 2002);
            _machineFlagDict.Add("研发楼二楼洁净车间SE02.#01.状态.升料机开关", 2003);
            _machineFlagDict.Add("研发楼二楼洁净车间SE02.#01.报警信息.报警提示", 2004);
            //SE01 Index:21
            _machineFlagDict.Add("研发楼二楼洁净车间SE01.#01.状态.机器运行标志", 2101);
            _machineFlagDict.Add("研发楼二楼洁净车间SE01.#01.状态.炉子电源开关", 2102);
            _machineFlagDict.Add("研发楼二楼洁净车间SE01.#01.状态.升料机开关", 2103);
            _machineFlagDict.Add("研发楼二楼洁净车间SE01.#01.报警信息.报警提示", 2104);
            //研发一楼车间
            //DF20 Index:22
            _machineFlagDict.Add("研发楼一楼车间DF20.#01.状态.机器运行标志", 2201);
            _machineFlagDict.Add("研发楼一楼车间DF20.#01.状态.炉子电源开关", 2202);
            _machineFlagDict.Add("研发楼一楼车间DF20.#01.状态.升料机开关", 2203);
            _machineFlagDict.Add("研发楼一楼车间DF20.#01.报警信息.报警提示", 2204);
            //DF18 Index:23
            _machineFlagDict.Add("研发楼一楼车间DF18.#01.状态.机器运行标志", 2301);
            _machineFlagDict.Add("研发楼一楼车间DF18.#01.状态.炉子电源开关", 2302);
            _machineFlagDict.Add("研发楼一楼车间DF18.#01.状态.升料机开关", 2303);
            _machineFlagDict.Add("研发楼一楼车间DF18.#01.报警信息.报警提示", 2304);
            //DE12 Index:24
            _machineFlagDict.Add("研发楼一楼车间DE12.#01.状态.机器运行标志", 2401);
            _machineFlagDict.Add("研发楼一楼车间DE12.#01.状态.炉子电源开关", 2402);
            _machineFlagDict.Add("研发楼一楼车间DE12.#01.状态.升料机开关", 2403);
            _machineFlagDict.Add("研发楼一楼车间DE12.#01.报警信息.报警提示", 2404);
            //DE11 Index:25
            _machineFlagDict.Add("研发楼一楼车间DE11.#01.状态.机器运行标志", 2501);
            _machineFlagDict.Add("研发楼一楼车间DE11.#01.状态.炉子电源开关", 2502);
            _machineFlagDict.Add("研发楼一楼车间DE11.#01.状态.升料机开关", 2503);
            _machineFlagDict.Add("研发楼一楼车间DE11.#01.报警信息.报警提示", 2504);
            //SM02 Index:26
            _machineFlagDict.Add("研发楼一楼车间SM02.#01.状态.机器运行标志", 2601);
            _machineFlagDict.Add("研发楼一楼车间SM02.#01.状态.炉子电源开关", 2602);
            _machineFlagDict.Add("研发楼一楼车间SM02.#01.状态.升料机开关", 2603);
            _machineFlagDict.Add("研发楼一楼车间SM02.#01.报警信息.报警提示", 2604);
            //SM01 Index:27
            _machineFlagDict.Add("研发楼一楼车间SM01.#01.状态.机器运行标志", 2701);
            _machineFlagDict.Add("研发楼一楼车间SM01.#01.状态.炉子电源开关", 2702);
            _machineFlagDict.Add("研发楼一楼车间SM01.#01.状态.升料机开关", 2703);
            _machineFlagDict.Add("研发楼一楼车间SM01.#01.报警信息.报警提示", 2704);            
            //SR02 Index:28
            _machineFlagDict.Add("研发楼一楼车间SR02.#01.状态.机器运行标志", 2801);
            _machineFlagDict.Add("研发楼一楼车间SR02.#01.状态.炉子电源开关", 2802);
            _machineFlagDict.Add("研发楼一楼车间SR02.#01.状态.升料机开关", 2803);
            _machineFlagDict.Add("研发楼一楼车间SR02.#01.报警信息.报警提示", 2804);
            //SR01 Index:29
            _machineFlagDict.Add("研发楼一楼车间SR01.#01.状态.机器运行标志", 2901);
            _machineFlagDict.Add("研发楼一楼车间SR01.#01.状态.炉子电源开关", 2902);
            _machineFlagDict.Add("研发楼一楼车间SR01.#01.状态.升料机开关", 2903);
            _machineFlagDict.Add("研发楼一楼车间SR01.#01.报警信息.报警提示", 2904);
            //DF21 Index:30
            _machineFlagDict.Add("研发楼一楼车间DF21.#01.状态.机器运行标志", 3001);
            _machineFlagDict.Add("研发楼一楼车间DF21.#01.状态.炉子电源开关", 3002);
            _machineFlagDict.Add("研发楼一楼车间DF21.#01.状态.升料机开关", 3003);
            _machineFlagDict.Add("研发楼一楼车间DF21.#01.报警信息.报警提示", 3004);
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
