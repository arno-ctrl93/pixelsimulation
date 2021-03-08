using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] public GameObject CameraOne;

    [SerializeField] public GameObject CameraTwo;

    private AudioListener cameraOneAudioLis;

    private AudioListener cameraTwoAudioLis;
    // Start is called before the first frame update
    void Start()
    {
        cameraOneAudioLis = CameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = CameraTwo.GetComponent<AudioListener>();

        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
        

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            cameraChangeCounter();

    }

    void cameraChangeCounter()
    {
        int cameraPositionCounter = PlayerPrefs.GetInt("CameraPosition");
        cameraPositionCounter++;
        cameraPositionChange(cameraPositionCounter);
    }

    void cameraPositionChange(int camPosition)
    {
        if (camPosition > 1)
        {
            camPosition = 0;
        }
        
        PlayerPrefs.SetInt("CameraPosition", camPosition);
        if (camPosition == 0)
        {
            CameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;
            
            cameraTwoAudioLis.enabled = true;
            CameraTwo.SetActive(false);
            
        }

        if (camPosition == 1)
        {
            CameraTwo.SetActive(true);
            cameraTwoAudioLis.enabled = true;

            cameraOneAudioLis.enabled = false;
            CameraOne.SetActive(false);
        }
        
    }
}
