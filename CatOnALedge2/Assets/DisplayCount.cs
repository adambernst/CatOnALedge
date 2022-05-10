using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCount : MonoBehaviour
{
    
    public GameObject returnedText;
    
    // Start is called before the first frame update
    void Start()
    {
        Text textBox = returnedText.GetComponent<Text>();
        textBox.text = "Kittens Returned: " + GameHandler.control.kittenCount;
    }

}
