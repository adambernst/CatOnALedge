using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class PickUpObject : MonoBehaviour
{
    public GameObject mouth; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    private GameObject kitten; // the gameobject onwhich you collided with
    private KittenManager kitScript;
    bool hasItem; // a bool to see if you have an item in your hand
    
    public string message = "Press E to pick up the kitten and Q to put it down";
    bool displayMessage = false;
    bool overBed = false;
        
    // Start is called before the first frame update
    void Start()
    {
        canpickup = false;    //setting both to false
        hasItem = false;
    }
 
    // Update is called once per frame
    void Update()
    {
        if(canpickup) // if you enter thecollider of the objecct
        {
            if (Input.GetKey("e") && !hasItem)  // can be e or any key
            {
                displayMessage = false;
                kitten.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                kitten.transform.position = mouth.transform.position; // sets the position of the object to your hand position
                kitten.transform.parent = mouth.transform; //makes the object become a child of the parent so that it moves with the hands
                hasItem = true;
            }
        }
        if (Input.GetKey("q") && hasItem) // if you have an item and get the key to remove the object, again can be any key
        {
            kitten.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
            Vector3 modifier = new Vector3(0f, -1.9f, 0f);
            kitten.transform.position = kitten.transform.position + modifier;
            kitten.transform.parent = null; // make the object not be a child of the hands
            hasItem = false;
            if (overBed){
                //KittenManager kitScript = kitten.GetComponent<KittenManager>();
                kitScript.isHome = true;
                Destroy(kitten);
            }
        }
    }
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    //private void OnCollisionEnter(Collision other)
    {
        Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "kitten" && !hasItem) //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            //KittenManager manager = other.gameObject.GetComponent<KittenManager>();
            //if (!manager.isHome)
            if (!hasItem)
            {
                canpickup = true;  //set the pick up bool to true
                kitten = other.gameObject; //set the gameobject you collided with to one you can reference
                kitScript = kitten.transform.parent.gameObject.GetComponent<KittenManager>();
                displayMessage = true;    
            }
        }
    }
    
    private void OnCollisionEnter(Collision other)
    {
        //Debug.Log("weiner " + other.gameObject.tag);
        if(other.gameObject.tag == "kittenBed"){
            overBed = true;
        }
    }
    private void OnCollisionExit(Collision other)
    {
        //Debug.Log("off weiner " + other.gameObject.tag);
        if(other.gameObject.tag == "kittenBed"){
            overBed = false;
        }
    }
    
    private void OnTriggerExit(Collider other)
    //private void OnCollisionExit(Collision other)
    {
        canpickup = false; //when you leave the collider set the canpickup bool to false
        displayMessage = false;
    }
    
    void OnGUI()
    {
        if (displayMessage && !hasItem) {
            GUI.Label(new Rect(Screen.width / 2, Screen.height / 2, 200f, 200f), message);
        }
    }
}