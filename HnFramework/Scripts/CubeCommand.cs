using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HnFramework.MVC;

public class CubeCommand : Command {

    public CubeCommand(Contex contex) : base(contex) { }

    

    public override void OnStart() {
        AddListener(CommandEvent.GetScore, OnGetScore);
        AddListener(CommandEvent.AddScore, OnAddScore);
        // When you are using thread in command class, you should using message.
        // 当你在Command类中使用多线程时，应当用消息的形式使线程与MonoBehavior交互.
        // OnMessage(CommandEvent.GetScoreThread, OnGetScoreThread);
    }

    void OnGetScore(object[] param) {
        // Get score from model and return to mediator.
        // 从数据类中获取分数并返回给界面的mediator类.
        ScoreModel scoreModel = GetModel<ScoreModel>(ModelType.ScoreModel);
        DispatchMediator(MediatorEvent.GetScore, scoreModel.Score);

        // If you are using thread.
        // CreateThread(ThreadFunc)
    }

    void OnAddScore(object[] param) {
        ScoreModel scoreModel = GetModel<ScoreModel>(ModelType.ScoreModel);
        scoreModel.Score++;
    }

    // If you are using thread.
    //void ThreadFunc() {
    //    PostMessage(CommandEvent.GetScoreThread);
    //}
    //
    //void OnGetScoreThread(object[] param) {
    //    ScoreModel scoreModel = GetModel<ScoreModel>(ModelType.ScoreModel);
    //    DispatchMediator(MediatorEvent.GetScore, scoreModel.Score);
    //}
}
