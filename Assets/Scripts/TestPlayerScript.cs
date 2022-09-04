using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerScript : MonoBehaviour
{
    private Vector3 newPostion;
    private float newT;
    private Camera _camera;

    public float speed = 0.04f;

    // Start is called before the first frame update
    void Start()
    {
        newPostion = transform.position;
        _camera = Camera.main;
        _camera.GetComponent<TestCameraFollow>().ObjectToFollow = gameObject;
        Debug.Log(_camera.gameObject.name);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            if(Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100))
            {
                newPostion = hit.point;
                newT = Time.time;
            }

            Debug.Log(hit.point);
        }

        transform.position = Vector3.Lerp(transform.position, newPostion, speed);
    }
}