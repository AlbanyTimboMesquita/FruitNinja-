using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FruitSpawner : MonoBehaviour
{
    [SerializeField] private GameObject[] fruitsPrefab;
    [SerializeField] private Transform[] spawnPoints;
    [SerializeField] private float minDelay,maxDelay;
    private GameController gameController;
    [HideInInspector] public Coroutine spawnCoroutine;
    
    private void Awake() {
         gameController = FindObjectOfType<GameController>();
    }
    public IEnumerator Spawn(){
        
        while(gameController.gameStart){
        float delay =Random.Range(minDelay,maxDelay);
        yield return new WaitForSeconds(delay);

        int spawnIndex = Random.Range(0,spawnPoints.Length);
        Transform spawnPoint =  spawnPoints[spawnIndex];

        GameObject fruitPrefab = Instantiate(fruitsPrefab[Random.Range(0,fruitsPrefab.Length)],spawnPoint.position,spawnPoint.rotation);
        fruitPrefab.transform.parent=gameController.allObjects;

        spawnPoint.gameObject.GetComponent<AudioSource>().Play();
        Destroy(fruitPrefab,5f);
        }

       
    }

}
