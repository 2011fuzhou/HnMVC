---
description: >-
  An application object provides member functions for initializing your
  application (and each instance of it) and for running the application.
---

# App

 Each application that uses the HnMVC  can only contain one object derived from APP.  This object is constructed when the contex class calls the Awake function.  You should bind app to contex class in the start scene or any other scene that you want to make a test.

```text
// in the contex class of start scene.
public override void InitApp() {
        // Bind App class to contex.You can ignore this if app class is useless.
        // 绑定App类到contex,如果app类无用,或者不需要做全局初始化,可忽略此步.
        BindApp(TestApp.Instance<TestApp>());
    }
```

### void OnInitInstance\(\);

#### Remarks

 Override OnInitInstance to initialize each new instance of your application running under unity. 

### void OnExitInstance\(\);

#### Remarks

 Override this function to clean up when your application terminates.

## Example

```text
public class TestApp : App {

    public override void OnInitInstance() {
        // Application initialize instance function, execute only once. 
        // You can read config file, initialize manager here.
        // 程序初始化入口，整个程序生命周期中仅会执行一次,可以在此读取配置文件，初始化Manager,加解密等.
        PoolManager.Init();
    }

    public override void OnExitInstance() {
       // Application exit instance function, execute only once.
       // 程序反初始化出口，程序结束前自动调用，用于释放资源等.
       PoolManager.UnInit();
    }
}

```

