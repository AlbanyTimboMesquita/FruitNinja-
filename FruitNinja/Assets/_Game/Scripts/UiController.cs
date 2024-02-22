using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UiController : MonoBehaviour
{
    public TMP_Text txtScore,txtHighscore;
    public Image[] imgLives;
   
    public Button btnPause,btnResume,btnMainMenu,btnClosePauseMenu,btnSounds;
    public GameObject panelGame,panelPause;
     public Image heart;
    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
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
    }
}
