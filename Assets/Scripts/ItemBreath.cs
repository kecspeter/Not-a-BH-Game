using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemBreath : MonoBehaviour
{

    [SerializeField]
    private float breathTime = 0.5f; //in s
    public float BreathTime { get => this.breathTime; set => this.breathTime = value; }

    [SerializeField]
    private float maxSizePerc = 1.18f; // scale multiply
    public float MaxSizePerc { get => this.maxSizePerc; set => this.maxSizePerc = value; }

    private float prevFrameTime;

    private Transform _objectTransform;
    private float _maxSizePerc;
    private int _breathTime;

    void Start()
    {
        prevFrameTime = Time.time;
        _objectTransform = gameObject.GetComponent<Transform>();

    }


    void Update()
    {
        
        float period = prevFrameTime / BreathTime;
        float currPeriod = Mathf.Sin(period);

        float scaleModifier = 1 - MaxSizePerc;
        Vector3 newScale = new Vector3(1 + currPeriod * scaleModifier, 1 + currPeriod * scaleModifier, 1);
        _objectTransform.localScale = newScale;
        prevFrameTime = Time.time;
    }
}
