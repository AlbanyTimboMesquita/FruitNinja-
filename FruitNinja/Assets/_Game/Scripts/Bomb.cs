using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float startForce;
    [SerializeField] private GameObject beamLight;
    private AudioController audioController;
 
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        audioController = FindObjectOfType<AudioController>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
       Rotate(); 
    }
    private void Rotate(){
        transform.Rotate(new Vector3(0f,150,0f) * Time.deltaTime);
    }
    public void BombGameOver(){
        //speed=0f;
        myRB.bodyType = RigidbodyType2D.Kinematic;
        myRB.simulated = false;

        CircleCollider2D myCollider = this.gameObject.GetComponent<CircleCollider2D>();
        myCollider.enabled=false;
        GameObject tempBeamLight = Instantiate(beamLight, this.transform.position, Quaternion.identity) as GameObject;
        this.gameObject.GetComponent<AudioSource>().clip =audioController.bombExplodeAudio;
        this.gameObject.GetComponent<AudioSource>().Play();
    }

    private void ApplyForce(){
         myRB.AddForce(transform.up*startForce,ForceMode2D.Impulse); 
    }

}
