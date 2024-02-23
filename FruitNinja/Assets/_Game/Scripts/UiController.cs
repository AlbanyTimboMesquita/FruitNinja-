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
    public GameObject panelGame,panelPause,panelGameover;
    public Image heart;
    private GameController gameController;
    void Start()
    {
        panelGame.gameObject.SetActive(true);
        panelPause.gameObject.SetActive(false);
        gameController =  FindObjectOfType<GameController>();
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

    public IEnumerator ShowBombPanelGameover(){
        gameController.GameOver();
        panelGame.gameObject.SetActive(false);
        panelGameover.gameObject.SetActive(true);
        yield return new WaitForSeconds(3f);
        
    }
    public void ShowPanelGameover(){
        panelGameover.gameObject.SetActive(true);
        panelGame.gameObject.SetActive(false);
        gameController.GameOver();
    }
}
