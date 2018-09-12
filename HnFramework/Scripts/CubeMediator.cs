using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HnFramework.MVC;

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
