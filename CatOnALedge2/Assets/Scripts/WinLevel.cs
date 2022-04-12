using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinLevel : MonoBehaviour
{
    public void OnCollisionEnter(Collision cat) {
        if (cat.gameObject.tag == "Player"){
            SceneManager.LoadScene("WinScene");
        }
    }
}
