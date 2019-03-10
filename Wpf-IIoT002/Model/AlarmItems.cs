using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_IIoT001.Model
{
    public class AlarmItems:IDisposable
    {
        //机器报警位字典
        private Dictionary<string, int> _alarmFlagDict = new Dictionary<string, int>();

        public AlarmItems()
        {

        }


        private void AddDFAlarmItems(string workshop, string machineNo, string plcNo, int index)
        {
            //遍历Enum并获取Descriprion
            Type type = typeof(AlarmInfoOfDF);

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
                _alarmFlagDict.Add(_handleName, index * 100 + 1);
            }
        }

        private void AddSFAlarmItems(string workshop, string machineNo, string plcNo, int index)
        {

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
