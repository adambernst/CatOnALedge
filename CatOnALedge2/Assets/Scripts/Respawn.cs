using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Transform startRespawn;
    [SerializeField] private Transform checkpoint1;
    public int checkIndex = 0;
    
    //private List<Transform> respawnPoints;
    public Transform[] allPoints = new Transform[2];
    
    void Start()
    {
        allPoints[0] = startRespawn;
        allPoints[1] = checkpoint1;
    }
    
    void OnTriggerEnter(Collider other)
    {
        player.transform.position = (allPoints[checkIndex]).transform.position;
    }
    
}
