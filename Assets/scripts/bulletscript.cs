using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletscript : MonoBehaviour
{
    [SerializeField] float bulletDuration;

    private float
        startTime,
        currentTime;
    void Start()
    {
        startTime = Time.time;
        currentTime = Time.time;
    }

    void Update()
    {
        DestroyBullet();
    }

    private void DestroyBullet()
    {
        currentTime = Time.time;
        if (currentTime > startTime + bulletDuration)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "duvar")
        {
            Destroy(this.gameObject);
        }
    }
}
