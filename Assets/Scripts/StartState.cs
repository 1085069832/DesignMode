using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class StartState : ISceneState
{
    Image logo;
    float timer;

    public StartState(SceneStateController sceneStateController) : base("StartScene", sceneStateController)
    {
    }

    public override void StateStart()
    {
        logo = GameObject.Find("Logo").GetComponent<Image>();
        timer = Time.time;
    }

    public override void StateUpdate()
    {
        logo.color = Color.Lerp(logo.color, Color.white, 0.1f);

        if (Time.time - timer >= 3)
        {
            mSceneStateController.SetState(new MainState(mSceneStateController));
        }
    }
}