using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameData : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SaveScore(int score){
        PlayerPrefs.SetInt("highscore",score);
    }
    public int GetScore(){
        return PlayerPrefs.GetInt("highscore");
    }
    public void SaveSounds(int valor){
        PlayerPrefs.SetInt("sounds",valor);

    }
    public int GetSounds(){
        return PlayerPrefs.GetInt("sounds");
    }

}
