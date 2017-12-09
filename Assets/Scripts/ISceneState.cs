using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ISceneState
{
    string mSceneName;
    protected SceneStateController mSceneStateController;

    public ISceneState(string sceneName, SceneStateController sceneStateController)
    {
        mSceneName = sceneName;
        mSceneStateController = sceneStateController;
    }

    public string SceneName
    {
        get
        {
            return mSceneName;
        }
    }

    public virtual void StateStart() { }
    public virtual void StateEnd() { }
    public virtual void StateUpdate() { }
}
