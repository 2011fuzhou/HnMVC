using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HnFramework.MVC;

public class TestApp : App {

    public override void OnInitInstance() {
        // Application initialize instance function, execute only once. 
        // You can read config file, initialize manager here.
        // 程序初始化入口，整个程序生命周期中仅会执行一次,可以在此读取配置文件，初始化Manager,加解密等.
        // e.g.  PoolManager.Init();
    }

    public override void OnExitInstance() {
       // Application exit instance function, execute only once.
       // 程序反初始化出口，程序结束前自动调用，用于释放资源等.
       // e.g.  PoolManager.UnInit();
    }
}
