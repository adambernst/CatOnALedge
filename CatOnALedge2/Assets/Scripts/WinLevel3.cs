using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel3 : MonoBehaviour
{
    public void OnTriggerEnter(Collider cat)
    {
        if (cat.gameObject.tag == "Player")
        {
            SceneManager.LoadScene("WinScene");
        }
    }
}
