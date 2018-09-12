using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HnFramework.MVC;
using UnityEngine.UI;

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
        // Send add score event to command class.
        // 触发增加分数事件,监听了此事件的command类会触发执行对应处理函数.
        DispatchCommand(CommandEvent.AddScore);
        // Send get score event to command class.
        // 触发获取分数事件,监听了此事件的command类会触发执行对应处理函数.
        DispatchCommand(CommandEvent.GetScore);
    }

    public void ChangeObjectShownScore() {
        // Send change score event to the object "gameObject", it's send to itself here.
        // Must define AddObjectListener in gameObject mediator class.
        // 向指定的gameObject物体发送更改分数指令,可以是自身或其他游戏物体,在该游戏物体的
        // Mediator类中必须使用"AddObjectListener"添加物体监听器.

        // It's just change the ui text here, the real score is still not change.
        // 这里仅仅改变了界面文字,如果要改变真实的分数,需要通过command去修改数据类.
        DispatchObject(gameObject, MediatorEvent.GetScore, 99);
    }
}
