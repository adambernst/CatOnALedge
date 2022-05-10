using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHandler : MonoBehaviour
{
    public static GameHandler control;
    public int kittenCount;
    
    private void Awake() {
        // if theres no control, make this the control
        if (control == null) {
            control = this;
            DontDestroyOnLoad(gameObject);
        } // if there is one already, delete this
        else if (control != this) {
            Destroy(gameObject);
        }
    }
}
