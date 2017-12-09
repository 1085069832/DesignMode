using UnityEngine;
using System.Collections;

public class BattleState : ISceneState
{

    public BattleState(SceneStateController sceneStateController) : base("BattleScene", sceneStateController)
    {
    }

    public override void StateStart()
    {
        GameFacade.Instance.Init();
    }

    public override void StateUpdate()
    {
        if (GameFacade.Instance.IsGameOver)
        {
            mSceneStateController.SetState(new MainState(mSceneStateController));
        }

        GameFacade.Instance.Update();
    }

    public override void StateEnd()
    {
        GameFacade.Instance.Release();
    }
}
