using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField]private float startForce;
    public GameObject fruitSliced;
    private GameController gameController;
    
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        gameController = FindObjectOfType<GameController>();
        ApplyForce();

        
    }

    // Update is called once per frame
    void Update()
    {
      
    }
    private void ApplyForce(){
         myRB.AddForce(transform.up*startForce,ForceMode2D.Impulse); 
    }

    public Color32 ChangeSplashColor(GameObject Go)
    {
        string cloneobjectname = Go.transform.name;
        Color32 defaultColor = new Color32(255,255,255,255);
        switch (cloneobjectname)
        {
            case "apple(Clone)":
            return gameController.appleColor;

            case "melancia(Clone)":
            return gameController.melanciaColor;

            case "orange(Clone)":
            return gameController.orangeColor;

            case "pear(Clone)":
            return gameController.pearColor;

            case "coconut(Clone)":
            return gameController.coconutColor;

            case "pineapple(Clone)":
            return gameController.pineappleColor;

        }
        return defaultColor;
    }
}
