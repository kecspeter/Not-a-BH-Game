using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBreath : MonoBehaviour
{

    [SerializeField]
    private int breathTime = 1000; //in ms
    public int BreathTime { get => this.breathTime; set => this.breathTime = value; }

    [SerializeField]
    private float maxSizePerc = 1.1f;
    public float MaxSizePerc { get => this.maxSizePerc; set => this.maxSizePerc = value; }

    private int time;

    private Transform _objectTransform;
    private float _maxSizePerc;
    private int _breathTime;

    void Start()
    {
        time = 1;
        _objectTransform = gameObject.GetComponent<Transform>();

    }


    void Update()
    {
        float currPeriod = time / BreathTime;
        float size = Mathf.Sin(currPeriod);


        Vector3 newScale = new Vector3(size, size, 1);
        _objectTransform.localScale = newScale;
        Debug.Log(newScale);
        time++;
    }
}
