using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour
{
    private Vector3 newPostion;
    private float newT;
    private Camera _camera;
    private GameObject _marker;

    public float speed = 0.03f;


    private TextMeshProUGUI UITextPlayerPos;

    void Start()
    {
        newPostion = transform.position;
        _camera = Camera.main;
        _camera.GetComponent<TestCameraFollow>().ObjectToFollow = gameObject;

        //_marker = GameObject.

        UITextPlayerPos = GameObject.FindWithTag("UITestPlayerPosition").GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {

        MoveCheck();
        
        RefreshDebugValues();
    }


    private void MoveCheck()
    {
        if (Input.GetMouseButtonDown(1))
        {
            newPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            newPostion.z = transform.position.z;
            newT = Time.time;

            //Debug.Log(newPostion);
        }

        transform.position = Vector3.Lerp(transform.position, newPostion, speed);

    }



    private void RefreshDebugValues()
    {
        if (UITextPlayerPos != null)
        {
            UITextPlayerPos.text = transform.position.ToString();
        }
    }
}