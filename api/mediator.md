---
description: The Mediator class is a separate of ui view and command.
---

# Mediator

 Mediator is a MonoBehavior, it's instantiated  when view class is constructed. It listens to every dispatch from the mediator dispatcher. Whenever an event or Signal fires, contex would find the event listener of mediator,  and call the action function.

### void OnInit\(\)

#### Remarks

Override OnInit to get view object and add listener here.

```text
private CubeView _cubeView;
public override void OnInit() {
        _cubeView = View as CubeView;
        if (null == _cubeView) {
            Debug.LogError("cube view is null");
            return;
        }
        AddListener(MediatorEvent.GetScore, OnGetScore);
        AddObjectListener(MediatorEvent.GetScore, OnGetScore);
    }
```

### void OnStart\(\)

#### Remarks

Instead of unity function "Start"

### void OnUpdate\(\)

#### Remarks

Instead of unity function "Update"

### void AddListener\(enum, Action.Do doFunc\)

#### Param

enum: Mediator event type.

doFunc: action function.

{% hint style="info" %}
delegate void Action.Do\(object\[\] param\)
{% endhint %}

#### Remarks

Call this function to listen to a event, when got a event which is fired by "DispatchMediator\(enum\)" in commands or other mediator or view, it'll call the action function.

### void AddObjectListener\(enum, Action.Do doFunc\)

#### Param

enum: Mediator event type.

doFunc: action function.

{% hint style="info" %}
delegate void Action.Do\(object\[\] param\)
{% endhint %}

#### Remarks

Call this function to listen to a event, when got a event which is fired by "DispatchObject\(GameObject go, enum\)" in  mediator or view, it'll call the action function. The events works for the gameobject only, other mediators won't got a event fired.

### void RemoveListener\(enum\)

#### Param

enum: Mediator event type

#### Remarks

Remove all mediator event listener of type "enum" by calling this method.

### void RemoveObjectListener\(enum\)

#### Param

enum: Mediator event type

#### Remarks

Remove all object listener of type "enum" by calling this method.

### void RemoveListener\(enum, Action.Do doFunc\)

#### Param

enum: Mediator event type

doFunc: action function.

#### Remarks

Remove the special mediator event listener of type "enum"  by calling this method.

### void RemoveObjectListener\(enum, Action.Do doFunc\)

#### Param

enum: Mediator event type

doFunc: action function.

#### Remarks

Remove the special object event listener of type "enum"  by calling this method.

### void DispatchMediator\(enum\)

### void DispatchMediator\(enum, params object\[\] param\)

#### Param

enum: Mediator event type

param: parameters to send

#### Remarks

Fire a mediator event to other mediators. All the mediators will call the action function if they have listen to the mediator event.

### void DispatchCommand\(enum\)

### void DispatchCommand\(enum, params object\[\] param\)

#### Param

enum: command event type

param: parameters to send

#### Remarks

Fire a command event to commands. All the commands will call the action function if they have listen to the command event.



## Example

```text
public class CubeMediator : Mediator {

    private CubeView _cubeView;

    public override void OnInit() {
        _cubeView = View as CubeView;
        if (null == _cubeView) {
            Debug.LogError("cube view is null");
            return;
        }
        AddListener(MediatorEvent.GetScore, OnGetScore);
        AddObjectListener(MediatorEvent.GetScore, OnGetScore);
    }

    protected override void OnStart() {
        
    }

    protected override void OnUpdate() {
        
    }

    void OnGetScore(object[] param) {
        if (null == _cubeView) {
            return;
        }
        _cubeView.UpdateScore((int)param[0]);
    }
}
```



