using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Wpf_IIoT001
{
    public class GlobalVars
    {
        //第一排左起
        public static machineFlag DF07Flag = new machineFlag();
        public static machineFlag DF06Flag = new machineFlag();
        public static machineFlag SF08Flag = new machineFlag();
        public static machineFlag SF07Flag = new machineFlag();
        public static machineFlag SF06Flag = new machineFlag();
        public static machineFlag SF05Flag = new machineFlag();
        public static machineFlag SF04Flag = new machineFlag();
        public static machineFlag SF03Flag = new machineFlag();
        public static machineFlag SF02Flag = new machineFlag();
        public static machineFlag SF01Flag = new machineFlag();
        public static machineFlag DF05Flag = new machineFlag();
        public static machineFlag DF04Flag = new machineFlag();
        public static machineFlag DF03Flag = new machineFlag();
        public static machineFlag DF02Flag = new machineFlag();
        public static machineFlag DF01Flag = new machineFlag();
        //第二排租期
        public static machineFlag DF17Flag = new machineFlag();
        public static machineFlag DF16Flag = new machineFlag();
        public static machineFlag DF15Flag = new machineFlag();
        public static machineFlag SF12Flag = new machineFlag();
        public static machineFlag SF11Flag = new machineFlag();
        public static machineFlag SF10Flag = new machineFlag();
        public static machineFlag SF09Flag = new machineFlag();
        public static machineFlag DF14Flag = new machineFlag();
        public static machineFlag DF13Flag = new machineFlag();
        public static machineFlag DF12Flag = new machineFlag();
        public static machineFlag DF11Flag = new machineFlag();
        public static machineFlag DF10Flag = new machineFlag();
        public static machineFlag DF09Flag = new machineFlag();
        public static machineFlag DF08Flag = new machineFlag();
        //第三排左起
        public static machineFlag SF13Flag = new machineFlag();
        public static machineFlag SF14Flag = new machineFlag();
        public static machineFlag DF19Flag = new machineFlag();
        public static machineFlag SE13Flag = new machineFlag();

        //建立全局静态变量保存Banner信息
        public static BannerMessages bannerMessages = new BannerMessages();

        //建立全局静态变量以保存报警信息       
        public static List<AlarmMessage> alarmMessages = new List<AlarmMessage>();

        //建立全局变量保存被触发的报警信息List
        public static ObservableCollection<AlarmMessage> AlarmMessagesDS = new ObservableCollection<AlarmMessage>();

        //建立全局变量保存界面加载和服务器状态信息
        public static StatusMessages statusMessages = new StatusMessages();

        //建立全局变量保存每个机器的可计算信息
        //int _quantityOfMachine = 33;
        public static int[] executing = new int[33];
        public static int[] executingAndMaking = new int[33];
        public static int[] executingAndStartFurnace = new int[33];
        public static int[] executingAndStopFurnace = new int[33];
        public static int[] alarming = new int[33];
    }
}
