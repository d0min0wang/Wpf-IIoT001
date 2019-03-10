using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_IIoT001
{
    public class Alarm
    {
        private Dictionary<string, int> machineDFAlarmDict = new Dictionary<string, int>();
        private Dictionary<string, int> machineSFAlarmDict = new Dictionary<string, int>();

        public void setMachineDFAlarm()
        {
            machineDFAlarmDict.Clear();
            ///01号大机
            //int i = 1;
            //machineDFAlarmDict.Add("制造车间大机#01.#01.报警信息.请注意:这板模有管没脱掉", 172);
            //machineDFAlarmDict.Add("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模小车未归位", i*100+i);
            for (int i = 1; i <= 19; i++)
            {
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模小车未归位").ToString(), i * 100 + 1);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.开机时两个小车不能同时有模具").ToString(), i * 100 + 2);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车未归边").ToString(), i * 100 + 3);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉1号位无模具").ToString(), i * 100 + 4);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉插销未回零").ToString(), i * 100 + 5);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉2号位无模具").ToString(), i * 100 + 6);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉插销未归零").ToString(), i * 100 + 7);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉电机未开启").ToString(), i * 100 + 8);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉2号夹子松开不到位").ToString(), i * 100 + 9);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉2号位无模具").ToString(), i * 100 + 10);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉3号位无模具").ToString(), i * 100 + 11);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉2号夹子夹不到位").ToString(), i * 100 + 12);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉电机未开启").ToString(), i * 100 + 13);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉2号夹子松开不到位").ToString(), i * 100 + 14);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.水箱位无模具").ToString(), i * 100 + 15);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉1号位无模具").ToString(), i * 100 + 16);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉2号夹子夹不到位").ToString(), i * 100 + 17);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模机后退不到位").ToString(), i * 100 + 18);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.刷油机后退不到位").ToString(), i * 100 + 19);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模机前进不到位").ToString(), i * 100 + 20);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.刷油机前进不到位").ToString(), i * 100 + 21);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉伺服电机报警").ToString(), i * 100 + 22);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉伺服电机报警").ToString(), i * 100 + 23);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉前门下降不到位").ToString(), i * 100 + 24);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉后门下降不到位").ToString(), i * 100 + 25);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉前门下降不到位").ToString(), i * 100 + 26);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉后门下降不到位").ToString(), i * 100 + 27);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料气缸上升不到位").ToString(), i * 100 + 30);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料气缸下降不到位").ToString(), i * 100 + 31);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.水箱下降不到位").ToString(), i * 100 + 32);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模机翻板翻不到位").ToString(), i * 100 + 33);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模机不动作").ToString(), i * 100 + 34);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.刷油机2个感应器同时接通").ToString(), i * 100 + 35);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料气缸2个感应器同时接通").ToString(), i * 100 + 36);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉2号夹子2个感应器同时接通").ToString(), i * 100 + 37);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉2号夹子2个感应器同时接通").ToString(), i * 100 + 38);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模小车前进不到位").ToString(), i * 100 + 39);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模小车后退不到位").ToString(), i * 100 + 40);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模小车2个或2个以上感应器同时接通").ToString(), i * 100 + 41);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车前进不到位").ToString(), i * 100 + 42);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车后退不到位").ToString(), i * 100 + 43);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车2个或2个以上感应器同时接通").ToString(), i * 100 + 44);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车前减速开关有问题").ToString(), i * 100 + 45);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车后减速开关有问题").ToString(), i * 100 + 46);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模小车前减速开关有问题").ToString(), i * 100 + 47);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模小车后减速开关有问题").ToString(), i * 100 + 48);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车工件感应有问题").ToString(), i * 100 + 49);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模小车工件感应有问题").ToString(), i * 100 + 50);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉1号夹子松开不到位").ToString(), i * 100 + 51);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉1号夹子夹不到位").ToString(), i * 100 + 52);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉1号夹子松开不到位").ToString(), i * 100 + 53);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉1号夹子夹不到位").ToString(), i * 100 + 54);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.预热炉1号夹子2个感应器同时接通").ToString(), i * 100 + 55);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.烤料炉1号夹子2个感应器同时接通").ToString(), i * 100 + 56);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱膜小车驱动器报警").ToString(), i * 100 + 57);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车驱动器报警").ToString(), i * 100 + 58);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱膜小车出炉定位有问题").ToString(), i * 100 + 59);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料小车出炉定位有问题").ToString(), i * 100 + 60);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.8个工件感应有问题").ToString(), i * 100 + 61);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.机器没有动作，请重新启动").ToString(), i * 100 + 62);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.没有料了，请及时加料").ToString(), i * 100 + 67);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.初始化完成").ToString(), i * 100 + 68);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.设定产量已到达").ToString(), i * 100 + 69);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料机已开，但脱模机没有开").ToString(), i * 100 + 71);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.请注意:这板模有管没脱掉").ToString(), i * 100 + 72);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料机已开，但水箱没有开").ToString(), i * 100 + 73);
                machineDFAlarmDict.Add(("制造车间大机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.由于长时间不做管，系统自动关炉子，请重新开炉子做管").ToString(), i * 100 + 74);
            }
        }

        public void setMachineSFAlarm()
        {
            machineSFAlarmDict.Clear();
            for (int i = 1; i <= 14; i++)
            {
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.模具小车没到脱膜机位置，请注意。").ToString(), i * 100 + 1);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模机感应器出问题，请检查。").ToString(), i * 100 + 2);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.刷油机感应器出问题，请检查。").ToString(), i * 100 + 3);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料气缸感应器出问题，请检查。").ToString(), i * 100 + 4);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱膜气缸感应器出问题，请检查。").ToString(), i * 100 + 5);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱膜气缸下降出问题，请检查。").ToString(), i * 100 + 6);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱膜气缸上升出问题，请检查。").ToString(), i * 100 + 7);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料气缸下降出问题，请检查。").ToString(), i * 100 + 8);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料气缸上升出问题，请检查。").ToString(), i * 100 + 9);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.刷油机前行出问题，请检查。").ToString(), i * 100 + 10);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.刷油机后行出问题，请检查。").ToString(), i * 100 + 11);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.模具小车没到刷油机位置，请注意。").ToString(), i * 100 + 12);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.水箱出问题，请检查。").ToString(), i * 100 + 13);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.前炉门出问题，请检查。").ToString(), i * 100 + 14);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.模具小车没到水箱位置，请注意。").ToString(), i * 100 + 15);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.后炉门出问题，请检查。").ToString(), i * 100 + 16);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.模具小车没到炉子位置，请注意。").ToString(), i * 100 + 17);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.模具小车没到浸料机位置，请注意。").ToString(), i * 100 + 18);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.伺服电机报警，请关电重启。").ToString(), i * 100 + 19);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料机驱动器报警，请断电重启。").ToString(), i * 100 + 20);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱膜机前进出问题，请检查。").ToString(), i * 100 + 21);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.脱模机后退出问题，请检查。").ToString(), i * 100 + 22);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.伺服电机已关，请打开。").ToString(), i * 100 + 23);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料机液面感应器出问题，请检查。").ToString(), i * 100 + 24);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料机下降一速应该大于二速，请重新设定。").ToString(), i * 100 + 25);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.急停已按下，请注意。").ToString(), i * 100 + 26);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.伺服电机没有回零点。").ToString(), i * 100 + 27);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.机器没有动作，请重新启动。").ToString(), i * 100 + 28);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.浸料机没有料了，请加料。").ToString(), i * 100 + 33);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.产量已完成，请注意。").ToString(), i * 100 + 34);
                machineSFAlarmDict.Add(("制造车间小机#" + i.ToString("00") + ".#" + i.ToString("00") + ".报警信息.由于长时间不做管，系统自动关炉子，请重新开炉子做管。").ToString(), i * 100 + 35);
            }

        }

        public Dictionary<string, int> getMachineDFAlarm()
        {
            return machineDFAlarmDict;
        }

        public Dictionary<string, int> getMachineSFAlarm()
        {
            return machineSFAlarmDict;
        }
    }
}
