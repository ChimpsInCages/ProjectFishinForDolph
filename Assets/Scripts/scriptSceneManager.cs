using UnityEngine;
using Unity;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using Unity.Mathematics;
using System.Collections;
public class scriptSceneManager : MonoBehaviour
{
    public int gameScore;
    public float afkTimer = 0;
    public float fishSpwanTimer = 1;
    bool spawnStart = false;
    public GameObject winScreenUI;
    public GameObject startScreenUI;
    public GameObject generalUI;
    public GameObject generalScoreCounter;
    public GameObject finalScoreCounter;
    public GameObject prefabFish;
    public TMP_Text scoreCounter;
    public TMP_Text finalScore;
    Vector2 screenEdges;
    

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
        screenEdges = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        spawnStart = true;




    }
    public void gameStart()
    {
        startScreenUI.SetActive(false );
        generalUI.SetActive(true);
        Time.timeScale = 1.0f;  
        StartCoroutine(fishWave());
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
    private void fishSpawn()
    {
        GameObject f = Instantiate(prefabFish) as GameObject;
        f.transform.position = new Vector2(screenEdges.x * -2, UnityEngine.Random.Range(-screenEdges.y, screenEdges.y * 0.7f));
    }
    IEnumerator fishWave()
    {
        while (spawnStart == true)
            {
            yield return new WaitForSeconds(fishSpwanTimer);
            fishSpawn();
            }
        
    }
}
