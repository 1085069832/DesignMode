using UnityEngine;
using System.Collections;

public class GameFacade
{
    static GameFacade gameFacade = new GameFacade();
    GameFacade() { }

    public static GameFacade Instance
    {
        get
        {
            return gameFacade;
        }
    }

    public bool IsGameOver { get; set; }

    ArchievementSystem archievementSystem;
    CampSystem campSystem;
    CharacterSystem characterSystem;
    EnergySystem energySystem;
    GameEventSystem gameEventSytem;
    StageSystem stageSystem;

    CampInfoUI campInfoUI;
    GamePauseUI gamePauseUI;
    GameStateInfoUI gameStateInfoUI;
    SoliderInfoUI soliderInfoUI;

    public void Init()
    {
        archievementSystem = new ArchievementSystem();
        campSystem = new CampSystem();
        characterSystem = new CharacterSystem();
        energySystem = new EnergySystem();
        gameEventSytem = new GameEventSystem();
        stageSystem = new StageSystem();

        campInfoUI = new CampInfoUI();
        gamePauseUI = new GamePauseUI();
        gameStateInfoUI = new GameStateInfoUI();
        soliderInfoUI = new SoliderInfoUI();

        archievementSystem.Init();
        campSystem.Init();
        characterSystem.Init();
        energySystem.Init();
        gameEventSytem.Init();
        stageSystem.Init();

        campInfoUI.Init();
        gamePauseUI.Init();
        gameStateInfoUI.Init();
        soliderInfoUI.Init();
    }

    public void Update()
    {
        archievementSystem.Update();
        campSystem.Update();
        characterSystem.Update();
        energySystem.Update();
        gameEventSytem.Update();
        stageSystem.Update();

        campInfoUI.Update();
        gamePauseUI.Update();
        gameStateInfoUI.Update();
        soliderInfoUI.Update();
    }

    public void Release()
    {
        archievementSystem.Release();
        campSystem.Release();
        characterSystem.Release();
        energySystem.Release();
        gameEventSytem.Release();
        stageSystem.Release();

        campInfoUI.Release();
        gamePauseUI.Release();
        gameStateInfoUI.Release();
        soliderInfoUI.Release();
    }
}
