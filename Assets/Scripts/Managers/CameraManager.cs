using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CameraMode
{
    Stationary,
    Follow
}

public class CameraManager : Singleton<CameraManager>
{
    [Header("CameraParent")]
    public GameObject CameraParent;
    private Camera mainCamera;
    // TODO: Testing virtual camera scenarios
    public GameObject VirtualCameraObject;

    private GameObject objectToFollow;
    private CameraMode currCameraMode;

    [Header("SmoothCameraSpeed")]
    public float SmoothSpeed = 4.0f;


    public void SetupManager(CameraMode mode)
    {
        SetMainCamera(mode);
        //SetCameraState(null, CameraMode.Stationary);
    }

    private void SetMainCamera(CameraMode mode)
    {
        mainCamera = CameraParent.GetComponentInChildren<Camera>();
        currCameraMode = mode;
    }


    //This is called by UIBillboardBehaviour so they can orient to wherever the gameplay camera is.
    public Transform GetGameplayCameraTransform()
    {
        return mainCamera.transform;
    }

    public Camera GetCamera()
    {
        return mainCamera;
    }

    public void FollowPlayer(PlayerController playerController)
    {
        objectToFollow = playerController.gameObject;
    }
    

    public void LateUpdate()
    {
        UpdateCameraPosition(mainCamera);    
    }

    // TODO: Velocity changes investigation
    private void UpdateCameraPosition(Camera camera)
    {
        switch (currCameraMode)
        {
            case CameraMode.Follow:
                UpdateCameraPositionFollowObject(camera);
                break;
            case CameraMode.Stationary:
            default:
                break;
        }

    }
    private void UpdateCameraPositionFollowObject(Camera camera)
    {
        Vector3 ToDamp = new Vector3(
            objectToFollow.transform.position.x,
            objectToFollow.transform.position.y,
            camera.gameObject.transform.position.z);

        Vector3 velocity = new Vector3(0, 0, 0);
        Vector3 smoothPosition = Vector3.SmoothDamp(
            camera.gameObject.transform.position,
            ToDamp,
            ref velocity,
            SmoothSpeed * Time.deltaTime);

        camera.gameObject.transform.position = smoothPosition;
    }
}

