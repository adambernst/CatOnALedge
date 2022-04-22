using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingLedge : MonoBehaviour
{
    public double timeLimit = 1.0;
    public bool timerActive = false;
    public bool falling = false;
    
    public float initialDrop = -0.2f;
    public float gravConst = 3f;
        
    void Update(){
        if(timerActive && timeLimit > 0){
            timeLimit -= Time.deltaTime;
        }
        if (timeLimit <= 0){
            falling = true;
        }
        
        if(falling){
            float yDrop = initialDrop - (gravConst * Time.deltaTime);
            Vector3 drop = new Vector3(0, yDrop, 0);
            transform.position = transform.position + drop;
        }
        
        if (transform.position.y < 0){
            Destroy(this.gameObject);
        }
    } 
    
    public void OnCollisionEnter(Collision cat){
        if (cat.gameObject.tag == "Player"){
            timerActive = true;
        }
    }
}
