using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PickUpObject : MonoBehaviour
{
    public GameObject mouth; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    GameObject kitten; // the gameobject onwhich you collided with
    bool hasItem; // a bool to see if you have an item in your hand
    
    public string message = "Press E to pick up the kitten and Q to put it down";
    bool displayMessage = false;
    
    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(canpickup == true) // if you enter thecollider of the objecct
        {
            if (Input.GetKey("e") && hasItem == false)  // can be e or any key
            {
                displayMessage = false;
                kitten.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                kitten.transform.position = mouth.transform.position; // sets the position of the object to your hand position
                kitten.transform.parent = mouth.transform; //makes the object become a child of the parent so that it moves with the hands
                hasItem = true;
            }
        }
        if (Input.GetKey("q") && hasItem == true) // if you have an item and get the key to remove the object, again can be any key
        {
            kitten.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
            Vector3 modifier = new Vector3(0f, -2.1f, 0f);
            kitten.transform.position = kitten.transform.position + modifier;
            kitten.transform.parent = null; // make the object not be a child of the hands
            hasItem = false;
        }
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    {
        if(other.gameObject.tag == "kitten") //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            kitten = other.gameObject; //set the gameobject you collided with to one you can reference
            displayMessage = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
        displayMessage = false;
    }
    
    void OnGUI()
    {
        if (displayMessage) {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
        }
    }
}