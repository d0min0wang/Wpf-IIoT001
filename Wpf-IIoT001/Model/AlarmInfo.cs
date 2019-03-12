using System.ComponentModel;

namespace Wpf_IIoT001
{
    /// <summary>
    /// DF类机器报警信息
    /// </summary>
    public enum AlarmInfoOfDF
    {
        [Description("脱模小车未归位")]
        error1=1,
        [Description("开机时两个小车不能同时有模具")]
        error2=2,
        [Description("浸料小车未归边")]
        error3=3,
        [Description("预热炉1号位无模具")]
        error4 = 4,
        [Description("预热炉插销未回零")]
        error5 = 5,
        [Description("烤料炉2号位无模具")]
        error6 = 6,
        [Description("烤料炉插销未归零")]
        error7 = 7,
        [Description("预热炉电机未开启")]
        error8 = 8,
        [Description("预热炉2号夹子松开不到位")]
        error9 = 9,
        [Description("预热炉2号位无模具")]
        error10 = 10,
        [Description("预热炉3号位无模具")]
        error11 = 11,
        [Description("预热炉2号夹子夹不到位")]
        error12 = 12,
        [Description("烤料炉电机未开启")]
        error13 = 13,
        [Description("烤料炉2号夹子松开不到位")]
        error14 = 14,
        [Description("水箱位无模具")]
        error15 = 15,
        [Description("烤料炉1号位无模具")]
        error16 = 16,
        [Description("烤料炉2号夹子夹不到位")]
        error17 = 17,
        [Description("脱模机后退不到位")]
        error18 = 18,
        [Description("刷油机后退不到位")]
        error19 = 19,
        [Description("脱模机前进不到位")]
        error20 = 20,
        [Description("刷油机前进不到位")]
        error21 = 21,
        [Description("烤料炉伺服电机报警")]
        error22 = 22,
        [Description("预热炉伺服电机报警")]
        error23 = 23,
        [Description("预热炉前门下降不到位")]
        error24 = 24,
        [Description("预热炉后门下降不到位")]
        error25 = 25,
        [Description("烤料炉前门下降不到位")]
        error26 = 26,
        [Description("烤料炉后门下降不到位")]
        error27 = 27,
        [Description("浸料气缸上升不到位")]
        error28 = 28,
        [Description("浸料气缸下降不到位")]
        error29 = 29,
        [Description("水箱下降不到位")]
        error30 = 30,
        [Description("脱模机翻板翻不到位")]
        error31 = 31,
        [Description("脱模机不动作")]
        error32 = 32,
        [Description("刷油机2个感应器同时接通")]
        error33 = 33,
        [Description("浸料气缸2个感应器同时接通")]
        error34 = 34,
        [Description("预热炉2号夹子2个感应器同时接通")]
        error35 = 35,
        [Description("烤料炉2号夹子2个感应器同时接通")]
        error36 = 36,
        [Description("脱模小车前进不到位")]
        error37 = 37,
        [Description("脱模小车后退不到位")]
        error38 = 38,
        [Description("脱模小车2个或2个以上感应器同时接通")]
        error39 = 39,
        [Description("浸料小车前进不到位")]
        error40 = 40,
        [Description("浸料小车后退不到位")]
        error41 = 41,
        [Description("浸料小车2个或2个以上感应器同时接通")]
        error42 = 42,
        [Description("浸料小车前减速开关有问题")]
        error43 = 43,
        [Description("浸料小车后减速开关有问题")]
        error44 = 44,
        [Description("脱模小车前减速开关有问题")]
        error45 = 45,
        [Description("脱模小车后减速开关有问题")]
        error46 = 46,
        [Description("浸料小车工件感应有问题")]
        error47 = 47,
        [Description("脱模小车工件感应有问题")]
        error48 = 48,
        [Description("烤料炉1号夹子松开不到位")]
        error49 = 49,
        [Description("烤料炉1号夹子夹不到位")]
        error50 = 50,
        [Description("预热炉1号夹子松开不到位")]
        error51 = 51,
        [Description("预热炉1号夹子夹不到位")]
        error52 = 52,
        [Description("预热炉1号夹子2个感应器同时接通")]
        error53 = 53,
        [Description("烤料炉1号夹子2个感应器同时接通")]
        error54 = 54,
        [Description("脱膜小车驱动器报警")]
        error55 = 55,
        [Description("浸料小车驱动器报警")]
        error56 = 56,
        [Description("脱膜小车出炉定位有问题")]
        error57 = 57,
        [Description("浸料小车出炉定位有问题")]
        error58 = 58,
        [Description("8个工件感应有问题")]
        error59 = 59,
        [Description("机器没有动作，请重新启动")]
        error60 = 60,
        [Description("没有料了，请及时加料")]
        error61 = 61,
        [Description("初始化完成")]
        error62 = 62,
        [Description("设定产量已到达")]
        error63 = 63,
        [Description("浸料机已开，但脱模机没有开")]
        error64 = 64,
        [Description("请注意:这板模有管没脱掉")]
        error65 = 65,
        [Description("浸料机已开，但水箱没有开")]
        error66 = 66,
        [Description("由于长时间不做管，系统自动关炉子，请重新开炉子做管")]
        error67 = 67
    }

    /// <summary>
    /// SF类机器报警信息
    /// </summary>
    public enum AlarmInfoOfSF
    {
        [Description("模具小车没到脱膜机位置，请注意。")]
        error1 = 1,
        [Description("脱模机感应器出问题，请检查。")]
        error2 = 2,
        [Description("刷油机感应器出问题，请检查。")]
        error3 = 3,
        [Description("浸料气缸感应器出问题，请检查。")]
        error4 = 4,
        [Description("脱膜气缸感应器出问题，请检查。")]
        error5 = 5,
        [Description("脱膜气缸下降出问题，请检查。")]
        error6 = 6,
        [Description("脱膜气缸上升出问题，请检查。")]
        error7 = 7,
        [Description("浸料气缸下降出问题，请检查。")]
        error8 = 8,
        [Description("浸料气缸上升出问题，请检查。")]
        error9 = 9,
        [Description("刷油机前行出问题，请检查。")]
        error10 = 10,
        [Description("刷油机后行出问题，请检查。")]
        error11 = 11,
        [Description("模具小车没到刷油机位置，请注意。")]
        error12 = 12,
        [Description("水箱出问题，请检查。")]
        error13 = 13,
        [Description("前炉门出问题，请检查。")]
        error14 = 14,
        [Description("模具小车没到水箱位置，请注意。")]
        error15 = 15,
        [Description("后炉门出问题，请检查。")]
        error16 = 16,
        [Description("模具小车没到炉子位置，请注意。")]
        error17 = 17,
        [Description("模具小车没到浸料机位置，请注意。")]
        error18 = 18,
        [Description("伺服电机报警，请关电重启。")]
        error19 = 19,
        [Description("浸料机驱动器报警，请断电重启。")]
        error20 = 20,
        [Description("脱膜机前进出问题，请检查。")]
        error21 = 21,
        [Description("脱模机后退出问题，请检查。")]
        error22 = 22,
        [Description("伺服电机已关，请打开。")]
        error23 = 23,
        [Description("浸料机液面感应器出问题，请检查。")]
        error24 = 24,
        [Description("浸料机下降一速应该大于二速，请重新设定。")]
        error25 = 25,
        [Description("急停已按下，请注意。")]
        error26 = 26,
        [Description("伺服电机没有回零点。")]
        error27 = 27,
        [Description("机器没有动作，请重新启动。")]
        error28 = 28,
        [Description("浸料机没有料了，请加料。")]
        error29 = 29,
        [Description("产量已完成，请注意。")]
        error30 = 30,
        [Description("由于长时间不做管，系统自动关炉子，请重新开炉子做管。")]
        error31 = 31
    }

    /// <summary>
    /// SE类机器报警信息
    /// </summary>
    public enum AlarmInfoOfSE
    {
        [Description("模具小车没到脱膜机位置，请注意。")]
        error1 = 1,
        [Description("脱模机感应器出问题，请检查。")]
        error2 = 2,
        [Description("刷油机感应器出问题，请检查。")]
        error3 = 3,
        [Description("浸料气缸感应器出问题，请检查。")]
        error4 = 4,
        [Description("脱膜气缸感应器出问题，请检查。")]
        error5 = 5,
        [Description("脱膜气缸下降出问题，请检查。")]
        error6 = 6,
        [Description("脱膜气缸上升出问题，请检查。")]
        error7 = 7,
        [Description("浸料气缸下降出问题，请检查。")]
        error8 = 8,
        [Description("浸料气缸上升出问题，请检查。")]
        error9 = 9,
        [Description("刷油机前行出问题，请检查。")]
        error10 = 10,
        [Description("刷油机后行出问题，请检查。")]
        error11 = 11,
        [Description("模具小车没到刷油机位置，请注意。")]
        error12 = 12,
        [Description("水箱出问题，请检查。")]
        error13 = 13,
        [Description("前炉门出问题，请检查。")]
        error14 = 14,
        [Description("模具小车没到水箱位置，请注意。")]
        error15 = 15,
        [Description("后炉门出问题，请检查。")]
        error16 = 16,
        [Description("模具小车没到炉子位置，请注意。")]
        error17 = 17,
        [Description("模具小车没到浸料机位置，请注意。")]
        error18 = 18,
        [Description("伺服电机报警，请关电重启。")]
        error19 = 19,
        [Description("浸料机驱动器报警，请断电重启。")]
        error20 = 20,
        [Description("脱膜机前进出问题，请检查。")]
        error21 = 21,
        [Description("脱模机后退出问题，请检查。")]
        error22 = 22,
        [Description("伺服电机已关，请打开。")]
        error23 = 23,
        [Description("浸料机液面感应器出问题，请检查。")]
        error24 = 24,
        [Description("浸料机下降一速应该大于二速，请重新设定。")]
        error25 = 25,
        [Description("急停已按下，请注意。")]
        error26 = 26,
        [Description("伺服电机没有回零点。")]
        error27 = 27,
        [Description("机器没有动作，请重新启动。")]
        error28 = 28,
        [Description("浸料机没有料了，请加料。")]
        error29 = 29,
        [Description("产量已完成，请注意。")]
        error30 = 30,
        [Description("由于长时间不做管，系统自动关炉子，请重新开炉子做管。")]
        error31 = 31
    }
}
