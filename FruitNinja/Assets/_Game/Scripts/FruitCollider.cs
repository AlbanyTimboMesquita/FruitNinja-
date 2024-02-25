using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    private Fruit fruit;
    private GameController gameController;
    private UiController uiController;
    private AudioController audioController;
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>();
        gameController = FindObjectOfType<GameController>();
        uiController = FindObjectOfType<UiController>();
        audioController =  FindObjectOfType<AudioController>();
    }
private void OnTriggerEnter2D(Collider2D target) {
    if (target.gameObject.CompareTag("Blade")){
        //inicio audio aleatorio blade
        target.gameObject.GetComponent<AudioSource>().clip = audioController.bladeAudio[Random.Range(0,audioController.bladeAudio.Length)];
        target.gameObject.GetComponent<AudioSource>().Play();
        //fim audio aleatorio blade 
        GameObject tempFruitSliced = Instantiate(fruit.fruitSliced, transform.position, Quaternion.identity);
        //inicio audio aleatorio fruta splash
        tempFruitSliced.gameObject.GetComponent<AudioSource>().clip = audioController.fruitSplashAudio[Random.Range(0, audioController.fruitSplashAudio.Length)];
        tempFruitSliced.gameObject.GetComponent<AudioSource>().Play();
        //fim audio aleatorio fruta splash   Não quer funcionar     
        GameObject tempSplash =Instantiate(gameController.splash,tempFruitSliced.transform.position,Quaternion.identity);
        tempSplash.GetComponentInChildren<SpriteRenderer>().color = fruit.ChangeSplashColor(this.gameObject);



        gameController.UpdateScore(this.gameObject.GetComponent<Fruit>().points);

        tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right*Random.Range(5f,10f),ForceMode.Impulse);
        tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right*Random.Range(5f,10f),ForceMode.Impulse);


        Destroy(tempSplash, 5f);
        Destroy(tempFruitSliced, 5f);
        Destroy(this.gameObject);

    }else if(target.gameObject.CompareTag("Destroyer")){
        gameController.fruitCountEven++;
        
        if(gameController.fruitCountEven%2==0){
        gameController.fruitCount++;

            if(gameController.fruitCount<=3){
            uiController.imgLives[gameController.fruitCount-1].color=gameController.uiRedColor;
                switch (gameController.fruitCount)
                {
                    case(1):
                    uiController.heart.color=gameController.uiYellowColor;
                    return;
                    case(2):
                    uiController.heart.color=gameController.orangeColor;
                    return;
                    case(3):
                    uiController.heart.color=gameController.uiRedColor;
                    //Fim de jogo
                    uiController.ShowPanelGameover();
                    return;
                }
           
            }
        }

    }
    
}

    
    
}
