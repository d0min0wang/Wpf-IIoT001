using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_IIoT001
{
    /// <summary>
    /// S7-200状态位
    /// </summary>
    public enum S7200StatusInfo
    {
        [Description("#01.状态.机器运行标志")]
        status01=1,
        [Description("#01.状态.炉子电源开关")]
        status02=2,
        [Description("#01.状态.升料机开关")]
        status03=3,
        [Description("#01.报警信息.报警提示")]
        status04=4,
        [Description("#01.状态.烤模时间设定")]
        status05=5,
        [Description("#01.状态.浸料时间设定")]
        status06=6,
        [Description("#01.状态.烤料时间设定")]
        status07=7,
        [Description("#01.状态.冷却时间设定")]
        status08=8
    }

    /// <summary>
    /// S7-1200状态位
    /// </summary>
    public enum S71200StatusInfo
    {
        [Description("#01.状态.机器运行标志")]
        status01=1,
        [Description("#01.状态.烤模炉子电源开关")]
        status02=2,
        [Description("#01.状态.升料机开关")]
        status03=3,
        [Description("#02.报警信息.报警提示")]
        status04=4,
        [Description("#01.状态.烤模时间设定")]
        status05=5,
        [Description("#01.状态.浸料时间设定")]
        status06=6,
        [Description("#02.状态.烤料时间设定")]
        status07=7,
        [Description("#02.状态.冷却时间设定")]
        status09=8,
        [Description("#01.状态.烤料炉子电源开关")]
        status10=9
        
    }
}
