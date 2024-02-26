using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bomba : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Rotate(); 
    }
    private void Rotate(){
        transform.Rotate(new Vector3(0f,150,0f) * Time.deltaTime);
    }
}
