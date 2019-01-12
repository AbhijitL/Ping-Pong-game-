using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private float upBound = 4.14f;
    private float speed = 0.15f;
    float previousPositionY;
    int direction = 0;

    Transform mytransform;
    // Start is called before the first frame update
    void Start()
    {
        mytransform = transform;
        previousPositionY = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            moveUp();
        else if (Input.GetKey(KeyCode.S))
            moveDown();
        Bound();

        if (previousPositionY > transform.position.y)
            direction = -1;
        else if (previousPositionY < transform.position.y)
            direction = 1;
        else
            direction = 0;

    }

    void LateUpdate()
    {
        previousPositionY = transform.position.y;
    }

    void moveUp()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y + speed);
    }
    void moveDown()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - speed);
    }
    void Bound()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -upBound, upBound));
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        float adjust = 5 * direction;
        target.rigidbody.velocity = new Vector2(target.rigidbody.velocity.x, target.rigidbody.velocity.y + adjust);
    }
}
