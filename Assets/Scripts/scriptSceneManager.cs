using UnityEngine;
using Unity;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
public class scriptSceneManager : MonoBehaviour
{
    public int gameScore;
    public float afkTimer = 0;
    public GameObject winScreenUI;
    public GameObject startScreenUI;
    public GameObject generalUI;
    public GameObject generalScoreCounter;
    public GameObject finalScoreCounter;
    public TMP_Text scoreCounter;
    public TMP_Text finalScore;

    //The scene manager sets all of the UI, as well as tracking the gamescore and the AFK timer
    private void Awake()
    {
        Time.timeScale = 0f;
    }
    void Start()
    {
        winScreenUI = GameObject.Find("Win Screen");
        winScreenUI.SetActive(false);
        generalUI = GameObject.Find("General UI");
        generalUI.SetActive(false);
        generalUI.SetActive(false);
        gameScore = 0;
        afkTimer = 0;
        startScreenUI.SetActive(true);
        scoreCounter = generalScoreCounter.GetComponent<TMP_Text>();
        finalScore = generalScoreCounter.GetComponent<TMP_Text>();

        
    }
    public void gameStart()
    {
        startScreenUI.SetActive(false );
        generalUI.SetActive(true);
        Time.timeScale = 1.0f;
    }
    private void Update()
    {
        scoreCounter.text = gameScore.ToString();
    }
    void FixedUpdate()
    {
        afkTimer = afkTimer + Time.deltaTime;
        if (afkTimer > 60)
        {
            resetGame();
        }
    }
    public void addScore (int points)
    {
        gameScore = gameScore + points;
    }
    public void endgameWrapup()
    {
        winScreenUI.SetActive(true);
        generalUI.SetActive(false);
        finalScore.text = gameScore.ToString();
    }
    public void resetAFKTimer()
    {
        afkTimer = 0;
    }
    public void resetGame()
    {
        gameScore = 0;
        afkTimer = 0;
        Time.timeScale = 0f;
        winScreenUI.SetActive(false);
        generalUI.SetActive(false);
        startScreenUI.SetActive(true);
    }
}
