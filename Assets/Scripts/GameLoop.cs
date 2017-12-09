using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLoop : MonoBehaviour
{
    SceneStateController sceneStateController;

    void Awake()
    {
        DontDestroyOnLoad(this);
    }

    // Use this for initialization
    void Start()
    {
        sceneStateController = new SceneStateController();

        sceneStateController.SetState(new StartState(sceneStateController));
    }

    // Update is called once per frame
    void Update()
    {
        sceneStateController.StateUpdate();
    }
}
