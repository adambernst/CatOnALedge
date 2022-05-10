using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PreviewCam : MonoBehaviour
{

    public GameObject mainCam1;
    public GameObject mainCam2;
    public GameObject mainCam3;
    public GameObject previewCam;
    public AudioFX audioFX;

    // Start is called before the first frame update
    void Start()
    {
        audioFX = GetComponent<AudioFX>();
        StartCoroutine(Preview());
    }

    IEnumerator Preview() {
        audioFX.PlayWhoosh();
        mainCam1.SetActive(false);
        mainCam2.SetActive(false);
        mainCam3.SetActive(false);
        previewCam.SetActive(true);
        yield return new WaitForSeconds (5);
        mainCam1.SetActive(true);
        mainCam2.SetActive(true);
        mainCam3.SetActive(true);
        previewCam.SetActive(false);
    }
}
