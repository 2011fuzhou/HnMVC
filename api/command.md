---
description: Commands are the Controllers in the classic Model-View-Controller structure.
---

# Command

   Command listens to every dispatch from the command dispatcher. Whenever an event or Signal fires, contex would find the event listener of command,  and call the action function.

### Command\(Contex contex\)

#### Remarks

Constructor function require contex param.

### void InitModel\(\)

#### Remarks

Override InitModel to initialize models.You should call BindModel to bind models to command.

```text
public override void InitModel() {
        BindModel(ModelType.ScoreModel, ScoreModel.GetSingleton<ScoreModel>());
    }
```

### void  BindModel\(enum, Model model\)

#### Params

enum: model type

model: model class drived from Model

#### Remarks

Call BindModel  to bind models to command in InitModel function. 

Model.GetSingleton&lt;T&gt; that will instantiate an model which works in the application life time.

Model.GetInstance&lt;T&gt; that will instantiate an model which destroys with the scene.

### void AddListener\(enum, Action.Do doFunc\)

#### Params

enum: event type

doFunc: action function.

{% hint style="info" %}
delegate void Action.Do\(object\[\] param\)
{% endhint %}

#### Remarks

Call this function to listen to a event, when got a event which is fired by "DispatchCommand\(enum\)" in other commands or mediator or view, it'll call the action function.

### void OnMessage\(enum, Action.Do doFunc\)

#### Params

enum: event type

doFunc: action function.

#### Remarks

Call this function to listen to a event when you are using thread, when got a event fired, it'll call the action function.

### void OnStart\(\)

#### Remarks

Instead of unity function "Start", and you should add listener here.

```text
public override void OnStart() {
        AddListener(CommandEvent.GetScore, OnGetScore);
        AddListener(CommandEvent.AddScore, OnAddScore);
        // When you are using thread in command class, you should using message.
        // 当你在Command类中使用多线程时，应当用消息的形式使线程与MonoBehavior交互.
        // OnMessage(CommandEvent.GetScoreThread, OnGetScoreThread);
    }
```

## Example

```text
public class Test1Command : Command {

    public Test1Command(Contex contex) : base(contex) { }

    public override void InitModel() {
        // Bind model function, model instance will be destroy with the scene 
        // while you call the method Model.GetInstance, and it works in whole life time 
        // while you call the method Model.GetSingleton.
        // Model数据类在此进行绑定,调用GetSingleton则该数据类全局有效,GetInstance则只在当前场景有效,
        // 场景销毁则该数据类也进行销毁.

        //BindModel(ModelType.ScoreModel, ScoreModel.GetInstance<ScoreModel>());
        BindModel(ModelType.ScoreModel, ScoreModel.GetSingleton<ScoreModel>());
        // BindModel(ModelType.OtherModel,
        // BindModel(...
    }

    public override void OnStart() {

    }
}

```

