using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FruitCollider : MonoBehaviour
{
    private Fruit fruit;
    private GameController gameController;
    void Start()
    {
        fruit = this.gameObject.GetComponent<Fruit>();
        gameController = FindObjectOfType<GameController>();
    }
private void OnTriggerEnter2D(Collider2D target) {
    if (target.gameObject.CompareTag("Blade")){
        GameObject tempFruitSliced = Instantiate(fruit.fruitSliced, transform.position, Quaternion.identity);
        GameObject tempSplash =Instantiate(gameController.splash,tempFruitSliced.transform.position,Quaternion.identity);
        tempSplash.GetComponentInChildren<SpriteRenderer>().color = fruit.ChangeSplashColor(this.gameObject);
        tempFruitSliced.transform.GetChild(0).gameObject.GetComponent<Rigidbody>().AddForce(-tempFruitSliced.transform.GetChild(0).transform.right*Random.Range(5f,10f),ForceMode.Impulse);
        tempFruitSliced.transform.GetChild(1).gameObject.GetComponent<Rigidbody>().AddForce(tempFruitSliced.transform.GetChild(1).transform.right*Random.Range(5f,10f),ForceMode.Impulse);
        Destroy(tempFruitSliced, 5f);
        Destroy(this.gameObject);
    }
    
}

    
    
}
