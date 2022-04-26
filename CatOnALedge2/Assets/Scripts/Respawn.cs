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
    
    //private List<Transform> respawnPoints;
    private Transform[] allPoints = new Transform[3];
    
    public HeartSystem heartSystem;
    
    
    void Start()
    {
        allPoints[0] = startRespawn;
        allPoints[1] = checkpoint1;
        allPoints[2] = checkpoint2;
    }
    
    void OnTriggerEnter(Collider other)
    {
        player.transform.position = (allPoints[checkIndex]).transform.position;
        
        heartSystem.TakeDamage(1);
        Debug.Log("done with damage");
        
        // if (other.gameObject.tag == "Player") {
        //     other.gameObject.HeartSystem.TakeDamage(1);
        // 
        //             Debug.Log("done with damage!");
        // }
    }
}
