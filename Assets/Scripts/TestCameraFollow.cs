using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestCameraFollow : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToFollow = null;
    public GameObject ObjectToFollow { get => this.objectToFollow; set => this.objectToFollow = value; }

    [SerializeField]
    private float maxDistFromCenter = 2.5f;
    public float MaxDistFromCenter { get => this.maxDistFromCenter; set => this.maxDistFromCenter = value; }

    [SerializeField]
    private float minDistFromCenter = 0.0f;
    public float MinDistFromCenter { get => this.minDistFromCenter; set => this.minDistFromCenter = value; }


    void Start()
    {
    }

    // LateUpdate is used to update transform after player position change
    void LateUpdate()
    {
        

        if (ObjectToFollow != null)
        {
            Vector3 objectPos = new Vector3(ObjectToFollow.transform.position.x, ObjectToFollow.transform.position.y, transform.position.z);
            Vector3 hoverPos = objectPos;

            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;

            float mouseDistance = Vector3.Distance(transform.position, mousePos);
            Debug.Log(mouseDistance);
            if (mouseDistance < MinDistFromCenter)
            {
                transform.position = objectPos;
            }
            else
            {
                if (mouseDistance <= MaxDistFromCenter)
                {
                    Vector3 dir = Vector3.Normalize(mousePos - objectPos) * mouseDistance;
                    hoverPos = objectPos + dir;
                    //hoverPos = objectPos + (mousePos - objectPos) / MaxDistFromCenter;
                }
                else
                {
                    Vector3 dir = Vector3.Normalize(mousePos - objectPos) * MaxDistFromCenter;
                    hoverPos = objectPos + dir;
                }
                transform.position = hoverPos;
            }

        }

    }
}
