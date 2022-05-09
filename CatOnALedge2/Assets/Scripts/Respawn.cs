using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    //[SerializeField] private Transform player;
    public GameObject player;
    public int checkIndex = 0;
    
    public GameObject lostLifeText;
    public HeartSystem heartSystem;
    public Transform[] allPoints;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            Debug.Log("Ground hit. player position = " + player.transform.position);
            heartSystem.TakeDamage(1);
            
            player.GetComponent<CharacterController>().enabled = false;
            player.transform.position = (allPoints[checkIndex]).transform.position;
            player.GetComponent<CharacterController>().enabled = true;
            Debug.Log("teleported. respawn position = " + (allPoints[checkIndex]).transform.position);
            Debug.Log("New player position = " + player.transform.position);
            lostLifeText.SetActive(true);
            StartCoroutine(DeactivateText());
        }    
    }
    
    IEnumerator DeactivateText() {
        yield return new WaitForSeconds(1.5f);
        lostLifeText.SetActive(false);
    }
}
