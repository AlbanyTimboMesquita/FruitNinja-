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
    public Transform allObjects,allSplashes,allSlicedFruits,allLightBeams;
    [HideInInspector] public bool soundOnOff,gameStart;
    private FruitSpawner fruitSpawnerScript;
    void Start()
    {
        soundOnOff=true;
        gameStart=false;
        uiController =  FindObjectOfType<UiController>();
        fruitSpawnerScript = FindObjectOfType<FruitSpawner>();
        gamedata = FindObjectOfType<GameData>();
        highscore=gamedata.GetScore();
        score=0;
        fruitCount=0;
        Initialize();
        SoundsData();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void Initialize(){
        int soundValue = gamedata.GetSounds();
        if(soundValue==1){
            soundOnOff=true;
            uiController.btnSoundsMenuPause.gameObject.GetComponent<UnityEngine.UI.Image>().sprite=uiController.imgSoundOn;
            uiController.btnSoundsMainMenu.gameObject.GetComponent<UnityEngine.UI.Image>().sprite=uiController.imgSoundOn;
        }else{
            soundOnOff=false;
            uiController.btnSoundsMenuPause.gameObject.GetComponent<UnityEngine.UI.Image>().sprite=uiController.imgSoundOff;
            uiController.btnSoundsMainMenu.gameObject.GetComponent<UnityEngine.UI.Image>().sprite=uiController.imgSoundOff;
        }
    }
    public void StartGame(){
        //uiController.txtScore.text = "Pontuação: "+ score.ToString();
        RestartGame();

    }
    public void UpdateScore(int points){
        score+=points;
        uiController.txtScore.text="Pontuação: "+score.ToString();
    }

    public void GameOver(){
        fruitSpawner.gameObject.SetActive(false);
        destroyer.gameObject.SetActive(false);
        blade.gameObject.SetActive(false);
        gameStart=false;
        StopCoroutine(fruitSpawnerScript.spawnCoroutine);
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
        gameStart=true;
        fruitSpawnerScript = FindObjectOfType<FruitSpawner>();
        fruitSpawnerScript.spawnCoroutine = StartCoroutine(fruitSpawnerScript.Spawn());
        foreach (Transform child in allLightBeams)
        {
            Destroy(child.gameObject);
        }

    }
    public void SoundsData(){
        if(soundOnOff){
            //1
            gamedata.SaveSounds(1);
            soundOnOff = true;
        }else{
            //0
            gamedata.SaveSounds(0);
            soundOnOff = false;
        }
    }
    public void BackMainMenu(){
        score=0;
        fruitCount=0;
        fruitSpawner.gameObject.SetActive(false);
        blade.gameObject.SetActive(false);
        destroyer.gameObject.SetActive(false);
        Time.timeScale =1f;
        gameStart=false;
        StopCoroutine(fruitSpawnerScript.spawnCoroutine);

        foreach (Transform child in allObjects)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in allSlicedFruits)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in allSplashes)
        {
            Destroy(child.gameObject);
        }
        foreach (Transform child in allLightBeams)
        {
            Destroy(child.gameObject);
        }

    }
   
}
