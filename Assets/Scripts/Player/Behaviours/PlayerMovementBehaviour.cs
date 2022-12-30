using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementBehaviour : MonoBehaviour
{
    [Header("Component References")]
    public Rigidbody2D PlayerRigidbody;

    [Header("Movement Settings")]
    public float MovementSpeed = 5f;

    //Stored Values
    private Camera mainCamera;
    private Vector2 movementDirection;


    public void SetupBehaviour()
    {
        SetGameplayCamera();
    }

    void SetGameplayCamera()
    {
        mainCamera = CameraManager.Instance.GetCamera();
    }

    public void UpdateMovementData(Vector2 newMovementDirection)
    {
        movementDirection = newMovementDirection;
    }

    void Start()
    {
        //GameManager.Instance.TogglePause();
    }

    void FixedUpdate()
    {
        MoveThePlayer();
    }

    private float GetAngle()
    {
        return Vector2.Angle(Vector2.zero, movementDirection);
    }

    void MoveThePlayer()
    {
        //Vector2 movement = CameraDirection(movementDirection) * movementSpeed * Time.deltaTime;
        Debug.Log(GetAngle());
        PlayerRigidbody.velocity = movementDirection * MovementSpeed;
        Debug.Log(movementDirection);
        Debug.Log(PlayerRigidbody.velocity);
    }



    Vector3 CameraDirection(Vector3 movementDirection)
    {
        var cameraForward = mainCamera.transform.forward;
        var cameraRight = mainCamera.transform.right;

        cameraForward.y = 0f;
        cameraRight.y = 0f;

        return cameraForward * movementDirection.z + cameraRight * movementDirection.x;

    }
}
