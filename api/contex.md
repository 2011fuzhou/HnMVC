---
description: Context is a MonoBehaviour that instantiates your command and model.
---

# Contex

  The Context is where all the delegate and event store. it provides member functions for initializing the scene. You should bind app and command in contex.

### void InitApp\(\)

#### Remarks

Override InitApp to bind app instance to contex.

```text
public override void InitApp() {
        // Bind App class to contex.You can ignore this if app class is useless.
        // 绑定App类到contex,如果app类无用,或者不需要做全局初始化,可忽略此步.
        BindApp(TestApp.Instance<TestApp>());
    }
```

### void InitScene\(\)

#### Remarks

Override InitScene to initialize each scene, e.g. create gameobject, make gameobject initialize etc.

### void ExitScene\(\)

#### Remarks

Override ExitScene to clean up each scene.

### void InitCommand\(\)

#### Remarks

Override InitCommand to bind command to contex. You should bind all commands that will be used in the scene.

```text
public override void InitCommand() {
        // Initialize command function, All command class should be create here.
        // Command类初始化函数,所有的Command类应当在此进行创建.
        BindCommand(new Test1Command(this));
        BindCommand(new CubeCommand(this));
    }
```

### void OnAwake\(\)

#### Remarks

Instead of unity function "Awake". 

### void OnStart\(\)

#### Remarks

Instead of unity function "Start".

### void OnUpdate\(\)

#### Remarks

Instead of unity function "Update".

## Example

```text
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
```

