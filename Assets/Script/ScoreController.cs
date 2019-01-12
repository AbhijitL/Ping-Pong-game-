using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreController : MonoBehaviour
{
    private GameController gameController;
    public Text playerScoreText, enemyScoreText, resultText;
    public bool isAI;
    public int playerScore, enemyScore;
    

    // Start is called before the first frame update
    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (gameController.startedFromP1)
            isAI = true;
        if (!gameController.startedFromP1)
            isAI = false;


        playerScoreText.text = playerScore.ToString();
        enemyScoreText.text = enemyScore.ToString();
        if(playerScore == 5)
        {
            Time.timeScale = 0;
            playerScoreText.gameObject.SetActive(false);
            enemyScoreText.gameObject.SetActive(false);
            resultText.gameObject.SetActive(true);
            resultText.text = "Player 1 won";
            StartCoroutine(Restart());
            
        }else if(enemyScore == 5)
        {
            Time.timeScale = 0;
            playerScoreText.gameObject.SetActive(false);
            enemyScoreText.gameObject.SetActive(false);
            resultText.gameObject.SetActive(true);
            if (isAI)
                resultText.text = "Ai won";
            else if (!isAI)
                resultText.text = "playere 2 won";
            StartCoroutine(Restart());
        }

        
        
    }

    public void AddScoreToPlayer()
    {
        playerScore++;
        playerScoreText.text = playerScore.ToString();
    }
    public void AddScoreToEnemy()
    {
        enemyScore++;
        enemyScoreText.text = enemyScore.ToString();
    }
    IEnumerator Restart()
    {
        yield return new WaitForSecondsRealtime(2);
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

}
