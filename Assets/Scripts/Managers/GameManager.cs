using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum GameMode
{
    GameMode1,
    GameMode2
}

public class GameManager : Singleton<GameManager>
{
    public GameMode currentGameMode;


    [Header("Player Options")]
    public GameObject PlayerPrefab;
    public Transform SpawnPoint;

    //In case of more (player and non playable) characters it can be handy
    private List<PlayerController> characters;

    //Game state related
    public bool IsPaused;

    void Start()
    {
        IsPaused = false;
        characters = new List<PlayerController>();


        SetupGameByGameMode();
        SetupUI();
    }

    private void SetupGameByGameMode()
    {
        switch(currentGameMode)
        {
            case GameMode.GameMode1:
                SetupGameMode1();
                break;
            default:
                SetupGameMode1();
                break;
        }
    }

    private void SetupGameMode1()
    {

        AddPlayer(PlayerPrefab.GetComponent<PlayerController>());

        SetupPlayers();
        SetupCamera();

        CameraManager.Instance.FollowPlayer(characters[0]);
    }

    private void SetupCamera()
    {
        CameraManager.Instance.SetupManager(CameraMode.Follow);
    }

    private void SetupPlayers()
    {
        //Setup each player and bond ID to them
        for (int i = 0; i < characters.Count; i++)
        {
            characters[i].SetupPlayer(i);
        }

        
    }

    private void AddPlayer(PlayerController playerController)
    {
        characters.Add(playerController);
    }


    private void SetupUI()
    {
        UIManager.Instance.SetupManager();
    }

    public void TogglePause()
    {
        IsPaused = !IsPaused;

        ToggleTimeScale();


        UpdateUIMenu();
    }

    private void UpdateUIMenu()
    {
        UIManager.Instance.UpdateUIMenuState(IsPaused);
    }


    private void ToggleTimeScale()
    {
        float newTimeScale = 0f;

        if(IsPaused)
        {
            newTimeScale = 0f;
        }
        else
        {
            newTimeScale = 1f;
        }
        Time.timeScale = newTimeScale;
    }

    protected GameManager() { }

}
