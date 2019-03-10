using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Wpf_IIoT001
{
    public class alarmFlags
    {
        //int _lenthOfDFAlarm=typeof(AlarmInfoOfDF).GetFields(BindingFlags.Public | BindingFlags.Static).Length;
        //int _lenthOfSFAlarm = typeof(AlarmInfoOfSF).GetFields(BindingFlags.Public | BindingFlags.Static).Length;
        static int _lenthOfDFAlarm = 67;
        static int _lenthOfSFAlarm = 31;
        //public static int[] _executing = new int[];
        //第一排左起
        public static int[] DF07Flag = new int[_lenthOfDFAlarm];
        public static int[] DF06Flag = new int[_lenthOfDFAlarm];
        public static int[] SF08Flag = new int[_lenthOfSFAlarm];
        public static int[] SF07Flag = new int[_lenthOfSFAlarm];
        public static int[] SF06Flag = new int[_lenthOfSFAlarm];
        public static int[] SF05Flag = new int[_lenthOfSFAlarm];
        public static int[] SF04Flag = new int[_lenthOfSFAlarm];
        public static int[] SF03Flag = new int[_lenthOfSFAlarm];
        public static int[] SF02Flag = new int[_lenthOfSFAlarm];
        public static int[] SF01Flag = new int[_lenthOfSFAlarm];
        public static int[] DF05Flag = new int[_lenthOfDFAlarm];
        public static int[] DF04Flag = new int[_lenthOfDFAlarm];
        public static int[] DF03Flag = new int[_lenthOfDFAlarm];
        public static int[] DF02Flag = new int[_lenthOfDFAlarm];
        public static int[] DF01Flag = new int[_lenthOfDFAlarm];
        //第二排左起
        public static int[] DF17Flag = new int[_lenthOfDFAlarm];
        public static int[] DF16Flag = new int[_lenthOfDFAlarm];
        public static int[] DF15Flag = new int[_lenthOfDFAlarm];
        public static int[] SF12Flag = new int[_lenthOfSFAlarm];
        public static int[] SF11Flag = new int[_lenthOfSFAlarm];
        public static int[] SF10Flag = new int[_lenthOfSFAlarm];
        public static int[] SF09Flag = new int[_lenthOfSFAlarm];
        public static int[] DF14Flag = new int[_lenthOfDFAlarm];
        public static int[] DF13Flag = new int[_lenthOfDFAlarm];
        public static int[] DF12Flag = new int[_lenthOfDFAlarm];
        public static int[] DF11Flag = new int[_lenthOfDFAlarm];
        public static int[] DF10Flag = new int[_lenthOfDFAlarm];
        public static int[] DF09Flag = new int[_lenthOfDFAlarm];
        public static int[] DF08Flag = new int[_lenthOfDFAlarm];
        //第三排左起
        public static int[] SF13Flag = new int[_lenthOfSFAlarm];
        public static int[] SF14Flag = new int[_lenthOfSFAlarm];
        public static int[] DF19Flag = new int[_lenthOfDFAlarm];
        public static int[] SE13Flag = new int[_lenthOfSFAlarm];
    }
}
