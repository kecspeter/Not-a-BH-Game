using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private Camera followedCamera = null;
    public Camera FollowedCamera { get => this.followedCamera; set => this.followedCamera = value; }

    void Start()
    {
        //If no camera is attached to the player use default camera
        //Might be deleted later
        if (FollowedCamera == null)
        {
            FollowedCamera = Camera.main;
        }

    }

    void Update()
    {
        
    }


    private void CameraFollow()
    {
        
    }
}
