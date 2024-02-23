using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomb : MonoBehaviour
{
    private Rigidbody2D myRB;
    [SerializeField] private float speed,startForce;
    [SerializeField] private GameObject beamLight;
 
    void Start()
    {
        myRB = this.gameObject.GetComponent<Rigidbody2D>();
        ApplyForce();
    }

    // Update is called once per frame
    void Update()
    {
       Rotate(); 
    }
    private void Rotate(){
        transform.Rotate(new Vector3(0f,speed,0f) * Time.deltaTime);
    }
    public void BombGameOver(){
        speed=0f;
        myRB.bodyType = RigidbodyType2D.Kinematic;
        myRB.simulated = false;

        CircleCollider2D myCollider = this.gameObject.GetComponent<CircleCollider2D>();
        myCollider.enabled=false;
        GameObject tempBeamLight = Instantiate(beamLight, this.transform.position, Quaternion.identity) as GameObject;
    }

    private void ApplyForce(){
         myRB.AddForce(transform.up*startForce,ForceMode2D.Impulse); 
    }

}
