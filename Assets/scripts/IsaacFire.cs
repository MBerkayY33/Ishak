using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacFire : MonoBehaviour
{
    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bullet;

    [SerializeField]
    float
        fireSpeed,
        fireDuration;

    private float fireStartTime;

    void Start()
    {
        fireStartTime = Mathf.NegativeInfinity;
    }

    void Update()
    {
        FireControl();
    }

    private void FireControl()
    {
        if (Time.time > fireStartTime + fireDuration)
        {
            float horizontal = Input.GetAxisRaw("HorizontalFire");
            float vertical = Input.GetAxisRaw("VerticalFire");

            // Eðer hiçbir tuþa basýlmamýþsa, çýk
            if (horizontal == 0 && vertical == 0) return;

            Vector2 direction;

            if (Mathf.Abs(horizontal) > Mathf.Abs(vertical))
            {
                direction = (horizontal < 0) ? Vector2.left : Vector2.right;
            }
            else if (Mathf.Abs(vertical) > Mathf.Abs(horizontal))
            {
                direction = (vertical > 0) ? Vector2.down : Vector2.up;
            }
            else
            {
                // Eþitse ve sýfýrdan farklýysa çapraz yön
                direction = new Vector2(horizontal, -vertical).normalized;
            }

            GameObject newBullet = BasicBulletCreate();
            newBullet.GetComponent<Rigidbody2D>().velocity = direction * fireSpeed;
        }
    }

    private GameObject BasicBulletCreate()
    {
        GameObject newBullet = Instantiate(bullet, firePoint.position, firePoint.rotation);
        fireStartTime = Time.time;
        return newBullet;
    }
}
