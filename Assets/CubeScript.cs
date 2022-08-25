using Assets.Scripts.Character.PCharacterClasses;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScript : MonoBehaviour
{
    private PCWarrior myClass;

    // Start is called before the first frame update
    void Start()
    {
        myClass = new PCWarrior();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Cube hp: " + myClass.Health);
    }
}
