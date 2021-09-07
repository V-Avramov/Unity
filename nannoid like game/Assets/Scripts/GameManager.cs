using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // the game manager is static so that it can be used in other scripts
    public static GameManager gm;
    public int score = 0;

    //public int beatLevelScore = 0;
    public bool gameIsOver = false;

    public Text scoreDisplay;

    public GameObject userInterface;

    //public GameObject playAgainButton;
    public GameObject playAgainInterface;
    public string playAgainLevelToLoad;

    //public GameObject nextLevelButton;
    public GameObject nextLevelInterface;
    public string nextLevelToLoad;

    private GameObject destrObj;
    // Start is called before the first frame update
    void Start()
    {
        // set the interfaces as inactive just in case
        userInterface.SetActive(false);
        playAgainInterface.SetActive(false);
        nextLevelInterface.SetActive(false);

        // calculate the score needed to beat the level
        destrObj = GameObject.Find("DestructableObjects");
        int numOfSquares = destrObj.transform.childCount;

        if (gm == null)
        {
            gm = gameObject.GetComponent<GameManager>();
        }

        scoreDisplay.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (!gameIsOver)
        {
            if (destrObj.transform.childCount <= 0/*score >= beatLevelScore*/)
            {
                BeatLevel();
            }
        }
    }

    void BeatLevel()
    {
        userInterface.SetActive(true);
        nextLevelInterface.SetActive(true);
        GameObject floatingBall = GameObject.Find("FloatingBall");
        Destroy(floatingBall);
        gameIsOver = true;
    }

    public void targetHit(int scoreAmount)
    {
        score += scoreAmount;
        scoreDisplay.text = score.ToString();
    }

    public void RestartGame()
    {
        // we are just loading a scene (or reloading this scene)
        // which is an easy way to restart the level
        SceneManager.LoadScene(playAgainLevelToLoad);
    }

    public void NextLevel()
    {
        // we are just loading the specified next level (scene)
        SceneManager.LoadScene(nextLevelToLoad);
    }
}
