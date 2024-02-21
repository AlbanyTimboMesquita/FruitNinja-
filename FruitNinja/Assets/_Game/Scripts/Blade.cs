using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Blade : MonoBehaviour
{
   private TrailRenderer trailRenderer;
   private CircleCollider2D circleCollider;
   private Vector2 previousPosition;
   [SerializeField] private float minCuttingVelocity=0.0001f;

   private void Awake() {
    trailRenderer = this.gameObject.GetComponent<TrailRenderer>();
    circleCollider =  this.gameObject.GetComponent<CircleCollider2D>();
   }
    void Start()
    {
        trailRenderer.enabled = false;
        circleCollider.enabled =  false;
        
    }

    // Update is called once per frame
    void Update()
    {
        CutSystem();
    }

    private void CutSystem(){
        if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
            UpdateCut();
        }else if(Input.touchCount==0){
            StopCut();

        }
    }

    private void StopCut()
    {
        if(this.transform.position == null){
            this.transform.position=Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        }
        circleCollider.enabled = false;
        trailRenderer.enabled = false;

    }

    private void UpdateCut()
    {
       Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
       this.transform.position = newPosition;
       float velocity = (newPosition-previousPosition).magnitude*Time.deltaTime;

       if (velocity> minCuttingVelocity){
        circleCollider.enabled = true;
        trailRenderer.enabled = true;
       }else{
        circleCollider.enabled = false;
        trailRenderer.enabled = false;
       }

       previousPosition=newPosition;
    }
}
