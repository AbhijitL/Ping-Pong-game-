using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    private ScoreController sController;
    private Rigidbody2D mybody;
    public int scores;
    private float speedValue = 4.25f;
    // Start is called before the first frame update
    void Start()
    {
        sController = GameObject.Find("ScoreController").GetComponent<ScoreController>();
        mybody = GameObject.Find("Ball").GetComponent<Rigidbody2D>();
        mybody.AddForce(new Vector2(speedValue * 50, 0));
    }

    // Update is called once per frame
    void Update()
    {
        Bound();
    }


    void Bound()
    {
        if(transform.position.x > 7.69)
        {
            sController.AddScoreToPlayer();
            scores = 1;
            StartCoroutine(StartOverAgain());
        }else if(transform.position.x < -7.69)
        {
            sController.AddScoreToEnemy();
            scores = 0;
            StartCoroutine(StartOverAgain());
        }
    }
    void newStart()
    {
        if(scores == 1)
        {
            mybody.AddForce(new Vector2(speedValue * 50, 0));
        }else if(scores == 0)
        {
            mybody.AddForce(new Vector2(-speedValue * 50, 0));
        }
    }
    void goBack()
    {
        transform.position = Vector2.zero;
        mybody.velocity = Vector2.zero;
    }
    IEnumerator StartOverAgain()
    {
        goBack();
        yield return new WaitForSeconds(0.8f);
        newStart();
    }
}
