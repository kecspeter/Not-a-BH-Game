using Assets.Scripts.Character.Classes;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CapsuleScript : MonoBehaviour
{
    private PCRogue myClass;

    // Start is called before the first frame update
    void Start()
    {
        myClass = new PCRogue();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Capsule speed: " + myClass.Speed);
    }
}
