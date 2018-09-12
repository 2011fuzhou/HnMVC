using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HnFramework.MVC;

public class Test1Contex : Contex {

    public override void InitApp() {
        // Bind App class to contex.You can ignore this if app class is useless.
        // 绑定App类到contex,如果app类无用,或者不需要做全局初始化,可忽略此步.
        BindApp(TestApp.Instance<TestApp>());
    }

    public override void ExitScene() {
        // Uninitialize scene function
        // 场景反初始化函数,可以在此做一些场景资源的销毁.
    }

    public override void InitCommand() {
        // Initialize command function, All command class should be create here.
        // Command类初始化函数,所有的Command类应当在此进行创建.
        BindCommand(new Test1Command(this));
        BindCommand(new CubeCommand(this));
    }

    public override void InitScene() {
        // Initialize scene function.
        // 场景初始化函数,可以做一些场景初始化工作.
    }

    public override void OnStart() {
        
    }

    public override void OnUpdate() {
        
    }

    public override void OnAwake() {

    }
}
