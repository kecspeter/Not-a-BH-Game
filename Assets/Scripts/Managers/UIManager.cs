using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UIManager : Singleton<UIManager>
{
    [Header("UI Canvas GameObject")]
    public GameObject Canvas;

    public TextMeshProUGUI PauseStatus;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdatePauseStatus();
    }

    private void UpdatePauseStatus()
    {
        
    }

    public void SetupManager()
    {
    }

    public void UpdateUIMenuState(bool isPaused)
    {
        if(PauseStatus != null)
        {
            PauseStatus.text = isPaused ? "Paused" : "Running";
        }
    }
}
