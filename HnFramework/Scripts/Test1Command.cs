using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HnFramework.MVC;

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
