using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainState : ISceneState
{
    Button startBt;
    public MainState(SceneStateController sceneStateController) : base("MainScene", sceneStateController)
    {
    }

    public override void StateStart()
    {
        startBt = GameObject.Find("StartBt").GetComponent<Button>();
        startBt.onClick.AddListener(OnStartGame);
    }

    public override void StateEnd()
    {
        startBt.onClick.RemoveListener(OnStartGame);
    }

    void OnStartGame()
    {
        mSceneStateController.SetState(new BattleState(mSceneStateController));
    }
}
