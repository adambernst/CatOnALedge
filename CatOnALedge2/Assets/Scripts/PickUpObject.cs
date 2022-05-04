using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
 
public class PickUpObject : MonoBehaviour
{
    public GameObject mouth; //reference to your hands/the position where you want your object to go
    bool canpickup; //a bool to see if you can or cant pick up the item
    private GameObject kitten; // the gameobject onwhich you collided with
    //private KittenManager kitScript;
    bool hasItem; // a bool to see if you have an item in your hand
    
    public GameObject tutorialText;
    
    public GameObject returnedText;
    public int kittensReturned = 0;
    
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
                kitten.GetComponent<Rigidbody>().isKinematic = true;   //makes the rigidbody not be acted upon by forces
                Vector3 pickUpMod = new Vector3(0f, -0.7f, 0f);
                kitten.transform.position = mouth.transform.position + pickUpMod; // sets the position of the object to your hand position
                kitten.transform.parent = mouth.transform; //makes the object become a child of the parent so that it moves with the hands
                hasItem = true;
                
                string newText = "Bring Kittens to cat beds to rescue them";
                StartCoroutine(replaceText(newText, 4f));
            }
        }
        if (Input.GetKey("q") && hasItem) // if you have an item and get the key to remove the object, again can be any key
        {
            kitten.GetComponent<Rigidbody>().isKinematic = false; // make the rigidbody work again
            Vector3 modifier = new Vector3(0f, -1.2f, 0f);
            kitten.transform.position = kitten.transform.position + modifier;
            kitten.transform.parent = null; // make the object not be a child of the hands
            hasItem = false;
        }
    }
    
    private void OnTriggerEnter(Collider other) // to see when the player enters the collider
    //private void OnCollisionEnter(Collision other)
    {
        //Debug.Log(other.gameObject.tag);
        if(other.gameObject.tag == "kitten" && !hasItem) //on the object you want to pick up set the tag to be anything, in this case "object"
        {
            canpickup = true;  //set the pick up bool to true
            kitten = other.gameObject; //set the gameobject you collided with to one you can reference
            GameObject kitParent = kitten.transform.root.gameObject; //parent.gameObject;
            
            string newText = "Press E to pick up the Kitten and Q to put it down";
            StartCoroutine(replaceText(newText, 1.5f));    
        }
        
        if(other.gameObject.tag == "TutorialHelper")
        {
            TutorialHelper script = other.gameObject.GetComponent<TutorialHelper>();
            //Debug.Log(script.message);
            if (script.seen == false){
                script.seen = true;
                StartCoroutine(replaceText(script.message, script.duration));
            }
        }
    }
    
    public void rescueKitten(){
        Destroy(kitten);
        kittensReturned ++;
        Text textBox = returnedText.GetComponent<Text>();
        textBox.text = "Kittens Returned: " + kittensReturned;
    }
    
    private IEnumerator replaceText(string newText, float time){
        //StopCoroutine(DeactivateText(0f));
        Text textBox = tutorialText.GetComponent<Text>();
        textBox.text = newText;
        tutorialText.SetActive(true);
        yield return StartCoroutine(DeactivateText(time));
    }
    
    IEnumerator DeactivateText(float time) {
        yield return new WaitForSeconds(time);
        tutorialText.SetActive(false);
    }
    
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "kitten"){
            canpickup = false; //when you leave the collider set the canpickup bool to false
        }
        
    }
}