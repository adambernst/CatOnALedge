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
    private float shakeSpeed = 65f;

    private Vector3 startPosition;   

    void Start() {
        startPosition = transform.position; 
    }
        
    void Update(){
        if(timerActive && timeLimit > 0){
            timeLimit -= Time.deltaTime;
            float incX = Mathf.Sin(Time.time * shakeSpeed) * 0.4f;
            Vector3 posInc = new Vector3(incX, 0f, 0f);
            transform.position += posInc;
        }

        if (timeLimit <= 0){
            falling = true;
        }
        
        if(falling){
            float yDrop = initialDrop - (gravConst * Time.deltaTime);
            Vector3 drop = new Vector3(0, yDrop, 0);
            transform.position += drop;
        }
        
        if (transform.position.y < 0){
            Destroy(this.gameObject);
        }
    } 
    
    public void OnTriggerEnter(Collider cat){
        if (cat.gameObject.tag == "Player"){
            timerActive = true;
        }
    }
}
