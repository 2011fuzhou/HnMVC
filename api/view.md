---
description: View is a MonoBehavior which is focus to show ui elements and fire event.
---

# View

### void InitMediator\(\)

#### Remarks

Override InitMediator to bind meaitors to view.

```text
protected override void InitMediator() {
        BindMediator(typeof(CubeMediator));
    }
```

### void OnStart\(\)

#### Remarks

Intead of unity function "Start"

### void OnUpdate\(\)

#### Remarks

Instead of unity function "Update"

### void DispatchMediator\(enum\)

### void DispatchMediator\(enum, params object\[\] param\)

#### Param

enum: mediator event type

param: parameters to send

#### Remarks

Fire a mediator event to other mediators. All the mediators will call the action function if they have listen to the mediator event.

### void DispatchObject\(GameObject go, enum\)

### void DispatchObject\(GameObject go, enum, params object\[\] param\)

#### Param

go: this function will fire event to the go object

enum: mediator event type

param: parameters to send

#### Remarks

Fire a mediator event to the go object, the go object is the only one which gets the event.

### void DispatchCommand\(enum\)

### void DispatchCommand\(enum, params object\[\] param\)

#### Param

enum: command event type

param: parameters to send

#### Remarks

Fire a command event to command. All the commands will call the action function if they have listen to the command event.



## Example

```text
public class CubeView : View {

    public Text ScoreText;

    protected override void InitMediator() {
        BindMediator(typeof(CubeMediator));
    }

    protected override void OnStart() {
       
    }

    protected override void OnUpdate() {
        
    }

    public void UpdateScore(int score) {
        // Update UI text.
        // 更新界面上的文字显示,View类仅仅做界面显示和发起交互.
        if (null == ScoreText) {
            return;
        }
        ScoreText.text = "" + score;
    }

    public void AddAndUpdateScore() {
        // Fire  add score event to command class.
        // 触发增加分数事件,监听了此事件的command类会触发执行对应处理函数.
        DispatchCommand(CommandEvent.AddScore);
        // Fire  get score event to command class.
        // 触发获取分数事件,监听了此事件的command类会触发执行对应处理函数.
        DispatchCommand(CommandEvent.GetScore);
    }

    public void ChangeObjectShownScore() {
        // Fire change score event to the object "gameObject", it's Fire to itself here.
        // Must define AddObjectListener in gameObject mediator class.
        // 向指定的gameObject物体发送更改分数指令,可以是自身或其他游戏物体,在该游戏物体的
        // Mediator类中必须使用"AddObjectListener"添加物体监听器.

        // It's just change the ui text here, the real score is still not change.
        // 这里仅仅改变了界面文字,如果要改变真实的分数,需要通过command去修改数据类.
        DispatchObject(gameObject, MediatorEvent.GetScore, 99);
    }
}

```

