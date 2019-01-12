using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Vector3 move = Vector3.zero;
    public bool player2;
    private float pSpeed = 0.15f,AIspeed = 6.12f;
    public GameObject ball;
    private float upBound = 4.14f;

    private ScoreController sController;

    // Start is called before the first frame update
    void Start()
    {
        sController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player2)
            pMovement();
        if (!player2)
            AImovement();
        if (sController.isAI)
            player2 = false;
        else if (!sController.isAI)
            player2 = true;
    }

    void pMovement()
    {
        if (Input.GetKey(KeyCode.UpArrow))
            transform.position = new Vector2(transform.position.x, transform.position.y + pSpeed);
        else if (Input.GetKey(KeyCode.DownArrow))
            transform.position = new Vector2(transform.position.x, transform.position.y - pSpeed);
    }
    void Bound()
    {
        transform.position = new Vector2(transform.position.x, Mathf.Clamp(transform.position.y, -upBound, upBound));
    }
    void AImovement()
    {
        if (!ball)
            ball = GameObject.Find("Ball");
        float direction = ball.transform.position.y - transform.position.y;
        if (direction > 0)
            move.y = AIspeed * Mathf.Min(direction, 1.5f);
        if (direction < 0)
            move.y = -AIspeed * Mathf.Min(-direction, 1.5f);
        transform.position += move * Time.deltaTime;
    }
}
