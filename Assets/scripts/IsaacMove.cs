using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsaacMove : MonoBehaviour
{

    private Rigidbody2D rbIsa;

    [SerializeField] GameObject eye;
    [SerializeField] SpriteRenderer left, right, up, down, downfire, upfire;
    [SerializeField] float speed;


    private float
        horizontal,
        vertical,
        horizontalFire,
        verticalFire;
    void Start()
    {
        rbIsa = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        MoveYaIsa();
        EyeUpdate();

    }

    private void MoveYaIsa()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        horizontalFire = Input.GetAxisRaw("HorizontalFire");
        verticalFire = Input.GetAxisRaw("VerticalFire");

        rbIsa.velocity = new Vector2(rbIsa.velocity.x, rbIsa.velocity.y + vertical * speed * Time.deltaTime);
        rbIsa.velocity = new Vector2(rbIsa.velocity.x + horizontal * speed * Time.deltaTime, rbIsa.velocity.y);
    }

    private void EyeUpdate()
    {
        Vector2 offset = new Vector2(0, 0.333f);
        bool hideEye = false;

        if(horizontalFire!=0 || verticalFire != 0)
        {
            if (horizontalFire < 0)
                GetComponent<SpriteRenderer>().sprite = right.sprite;
            if (horizontalFire > 0)
                GetComponent<SpriteRenderer>().sprite = left.sprite;

            if (verticalFire < 0)
                GetComponent<SpriteRenderer>().sprite = downfire.sprite;
            if (verticalFire >= 0 && horizontalFire == 0)
                GetComponent<SpriteRenderer>().sprite = upfire.sprite;
        }
        else
        {
            if (horizontal < 0)
                GetComponent<SpriteRenderer>().sprite = left.sprite;
            else if (horizontal > 0)
                GetComponent<SpriteRenderer>().sprite = right.sprite;

            if (vertical > 0)
                GetComponent<SpriteRenderer>().sprite = up.sprite;
            else if (vertical <= 0 && horizontal == 0)
                GetComponent<SpriteRenderer>().sprite = down.sprite;
        }

        eye.transform.position = transform.position + (Vector3)offset;
        eye.GetComponent<SpriteRenderer>().enabled = !hideEye;
    }


}
