using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMarkerPoint : MonoBehaviour
{

    [SerializeField]
    private float lifeTime = 600.0f;
    public float LifeTime { get => this.lifeTime;  set => this.lifeTime = value; }

    private float countDown;

    void Start()
    {
        countDown = lifeTime;
    }

    void Update()
    {
        transform.localScale = transform.localScale * Mathf.Sqrt(countDown / LifeTime);
        countDown--;
        if(countDown < 0)
        {
            Destroy(this.gameObject);
        }
    }
}
