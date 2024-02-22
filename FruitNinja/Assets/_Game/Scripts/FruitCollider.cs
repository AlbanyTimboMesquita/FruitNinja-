using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    private Fruit fruit;
    private GameController gameController;
    private UiController uiController;
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>();
        gameController = FindObjectOfType<GameController>();
        uiController = FindObjectOfType<UiController>();
    }
private void OnTriggerEnter2D(Collider2D target) {
    if (target.gameObject.CompareTag("Blade")){
        GameObject tempFruitSliced = Instantiate(fruit.fruitSliced, transform.position, Quaternion.identity);
        GameObject tempSplash =Instantiate(gameController.splash,tempFruitSliced.transform.position,Quaternion.identity);
        tempSplash.GetComponentInChildren<SpriteRenderer>().color = fruit.ChangeSplashColor(this.gameObject);

        gameController.UpdateScore(this.gameObject.GetComponent<Fruit>().points);

        tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right*Random.Range(5f,10f),ForceMode.Impulse);
        tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right*Random.Range(5f,10f),ForceMode.Impulse);
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
                    Debug.Log("Perdeu");
                    return;
                }
           
            }
        }

    }
    
}

    
    
}
