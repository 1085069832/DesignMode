using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneStateController
{
    ISceneState mSceneState;
    AsyncOperation mAO;
    bool sceneIsDone;

    public void SetState(ISceneState sceneState)
    {
        if (mSceneState != null)
        {
            mSceneState.StateEnd();//清理
        }

        mSceneState = sceneState;
        sceneIsDone = false;
        mAO = SceneManager.LoadSceneAsync(mSceneState.SceneName);
    }

    public void StateUpdate()
    {
        if (mAO != null && !mAO.isDone) return;

        if (mAO != null && mAO.isDone && !sceneIsDone)
        {
            //加载完成
            mSceneState.StateStart();
            sceneIsDone = true;
        }

        if (mSceneState != null && sceneIsDone)
        {
            mSceneState.StateUpdate();
        }
    }
}
