using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class GameController : MonoBehaviour
{

    public static GameController instance;
    private Button player1btn, player2btm;
    public bool startedFromP1;
    // Start is called before the first frame update
    void Awake()
    {
        MakeSingleTon();
    }
    void MakeSingleTon()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().buildIndex == 0)
        {
            if (!player1btn)
            {
                player1btn = GameObject.Find("Player1").GetComponent<Button>();
                player1btn.onClick.AddListener(VSAI);
            }else if (!player2btm)
            {
                player2btm = GameObject.Find("Player2").GetComponent<Button>();
                player2btm.onClick.AddListener(VSPlayer2);            }
        }
    }
    void VSAI()
    {
        startedFromP1 = true;
        SceneManager.LoadScene(1);
    }
    void VSPlayer2()
    {
        startedFromP1 = false;
        SceneManager.LoadScene(1);
    }
}
