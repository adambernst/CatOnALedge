using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class KittenText : MonoBehaviour
{
    public GameObject playerObject;
    public string message = "Press E to pick up the kitten and Q to put it down";
    public float displayTime = 3;
    private bool displayMessage = false;
    
    // Update is called once per frame
    void Update()
    {
        if (displayMessage) {
            displayTime -= Time.deltaTime;
            if (displayTime <= 0) {
                displayMessage = false;
            }
        }
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        //if (other.GameObject == playerObject) {
        displayMessage = true;
        displayTime = 3;
        //}
    }
    
    void OnGUI()
    {
        if (displayMessage) {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
        }
    }
}
