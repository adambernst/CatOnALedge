using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform startRespawn;
    [SerializeField] private Transform checkpoint1;
    [SerializeField] private Transform checkpoint2;
    public int checkIndex = 0;
    
    public GameObject lostLifeText;
    
    public HeartSystem heartSystem;
    
    //private List<Transform> respawnPoints;
    private Transform[] allPoints = new Transform[3];
    
    
    void Start()
    {
        allPoints[0] = startRespawn;
        allPoints[1] = checkpoint1;
        allPoints[2] = checkpoint2;
    }
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            heartSystem.TakeDamage(1);
            
            lostLifeText.SetActive(true);
            StartCoroutine(DeactivateText());
            
            Debug.Log(checkIndex);
            Transform newPos = allPoints[checkIndex].transform;
            player.transform.position = newPos.position;
        }
        
    }
    
    IEnumerator DeactivateText() {
        yield return new WaitForSeconds(1.5f);
        lostLifeText.SetActive(false);
    }
}
