using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UIElements;

public class GameController : MonoBehaviour
{
    public GameObject splash;
    [HideInInspector]public Color32 appleColor = new Color32(159,24,4,255),melanciaColor = new Color32(159,24,4,255),coconutColor = new Color32(107,67,41,255), 
    orangeColor = new Color32(255,132,13,255),pineappleColor = new Color32(188,96,21,255),pearColor = new Color32(176,186,0,255), uiRedColor = new Color32(255,255,255,255),
    uiYellowColor = new Color32(255,255,0,255),uiGreenwColor = new Color32(0,255,0,255);
    [HideInInspector]public int score,fruitCount,fruitCountEven;
    private UiController uiController;
    private int highscore;
    private GameData gamedata;
    [SerializeField] private GameObject fruitSpawner, blade, destroyer;
    void Start()
    {
        uiController =  FindObjectOfType<UiController>();
        gamedata = FindObjectOfType<GameData>();
        highscore=gamedata.GetScore();
        score=0;
        fruitCount=0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void StartGame(){
        uiController.txtScore.text = "Pontuação: "+ score.ToString();

    }
    public void UpdateScore(int points){
        score+=points;
        uiController.txtScore.text="Pontuação: "+score.ToString();
    }

    public void GameOver(){
        fruitSpawner.gameObject.SetActive(false);
        destroyer.gameObject.SetActive(false);
        blade.gameObject.SetActive(false);
        if(score>highscore){
            gamedata.SaveScore(score);
        }

    }

    public void RestartGame(){
        score=0;
        fruitCount=0;
        UpdateScore(0);
        fruitSpawner.gameObject.SetActive(true);
        destroyer.gameObject.SetActive(true);
        blade.gameObject.SetActive(true);

    }
}
