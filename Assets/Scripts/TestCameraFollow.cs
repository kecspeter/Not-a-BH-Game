using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow = null;
    public GameObject ObjectToFollow { get => this.objectToFollow; set => this.objectToFollow = value; }

    void Start()
    {
        
    }

    // LateUpdate is used to update transform after player position change
    void LateUpdate()
    {
        if (ObjectToFollow != null)
        {
            transform.position = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, transform.position.z);
        }
    }
}
