using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public TMP_Text txtScore,txtHighscoreGame,txtHighscoreGameover,txtHighscoreMainMenu;
    public Image[] imgLives;
   
    public Button btnPause,btnResume,btnMainMenu,btnClosePauseMenu,btnSoundsMenuPause,btnSoundsMainMenu;
    public GameObject panelGame,panelPause,panelGameover,panelMainMenu;
    public Image heart;
    private GameController gameController;
    private GameData gameData;
    public Sprite imgSoundOn,imgSoundOff;

    private AudioController audioController;
    void Start()
    {
        panelGame.gameObject.SetActive(false);
        panelGameover.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        gameController =  FindObjectOfType<GameController>();
        audioController =  FindObjectOfType<AudioController>();
        gameData = FindObjectOfType<GameData>();
        txtHighscoreGame.text = "Maior Pontuação: "+gameData.GetScore().ToString();
        txtHighscoreMainMenu.text = "Maior Pontuação: "+gameData.GetScore().ToString(); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ButtonPauseGame(){
        panelGame.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(true);
        Time.timeScale=0f;//pausando o jogo
    }

    public void ButtonClosePanelPause(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        Time.timeScale=1f;//despausando o jogo
        gameController.SoundsData();
    }

    public void ShowBombPanelGameover(){
        gameController.GameOver();
        panelGame.gameObject.SetActive(false);
        panelGameover.gameObject.SetActive(true);
        
        txtHighscoreGame.text = "Maior Pontuação: "+gameData.GetScore().ToString();
        txtHighscoreGameover.text = "Maior Pontuação: "+gameData.GetScore().ToString();     
        
    }
    public void ShowPanelGameover(){
        panelGameover.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        gameController.GameOver();
        txtHighscoreGame.text = "Maior Pontuação: "+gameData.GetScore().ToString();  
        txtHighscoreGameover.text = "Maior Pontuação: "+gameData.GetScore().ToString();   
    }
    public void ButtonRestartGame(){
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        panelGameover.gameObject.SetActive(false);
        gameController.RestartGame();
        txtScore.text = "Pontuação: "+gameController.score.ToString();
        

        for (int i = 0; i < imgLives.Length; i++)
        {
            imgLives[i].color=gameController.uiGreenwColor;
        }
        heart.color=gameController.uiGreenwColor;  
    }
    public void ButtonSounds(){
        if(gameController.soundOnOff){
            gameController.soundOnOff=false;
            btnSoundsMenuPause.gameObject.GetComponent<Image>().sprite = imgSoundOff;
            btnSoundsMainMenu.gameObject.GetComponent<Image>().sprite = imgSoundOff;
        }else{
            gameController.soundOnOff=true;
            btnSoundsMenuPause.gameObject.GetComponent<Image>().sprite = imgSoundOn;
            btnSoundsMainMenu.gameObject.GetComponent<Image>().sprite = imgSoundOn;
        }
        audioController.EnableAndDisableAudio();
    }
    public void ButtonBackMainMenu(){
        panelGame.gameObject.SetActive(false);
        panelGameover.gameObject.SetActive(false);
        panelPause.gameObject.SetActive(false);
        panelMainMenu.gameObject.SetActive(true);
        gameController.BackMainMenu();
        txtHighscoreMainMenu.text = "Maior Pontuação: "+gameData.GetScore().ToString(); 

        for (int i = 0; i < imgLives.Length; i++)
        {
            imgLives[i].color=gameController.uiGreenwColor;
        }
        heart.color=gameController.uiGreenwColor;  

    }
    public void ButtonStartGame(){
        panelMainMenu.gameObject.SetActive(false);
        panelGame.gameObject.SetActive(true);
        gameController.StartGame();
        txtScore.text = "Pontuação: "+gameController.score.ToString();

    }
     public void ButtonExitGame(){
        AndroidJavaObject activity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentyActivity");
        activity.Call<bool>("moveTaskToBack",true);
    }

}
