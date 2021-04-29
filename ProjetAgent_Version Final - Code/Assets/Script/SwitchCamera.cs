using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] public GameObject CameraOne;

    [SerializeField] public GameObject CameraTwo;

    [SerializeField] public GameObject Camera20x20;

    private AudioListener cameraOneAudioLis;

    private AudioListener cameraTwoAudioLis;

    private AudioListener camera20x20AudioLis;
    // Start is called before the first frame update
    void Start()
    {
        cameraOneAudioLis = CameraOne.GetComponent<AudioListener>();
        cameraTwoAudioLis = CameraTwo.GetComponent<AudioListener>();
        camera20x20AudioLis = Camera20x20.GetComponent<AudioListener>();

        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));

        camera20x20AudioLis.enabled = false;
        cameraOneAudioLis.enabled = true;
        cameraTwoAudioLis.enabled = false;
        Camera20x20.SetActive(false);
        CameraOne.SetActive(true);
        CameraTwo.SetActive(false);


    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            cameraChangeCounter();
        if (Input.GetKeyDown(KeyCode.O))
        {
            cameratest20x20();
        }
            

    }

    void cameratest20x20()
    {
        if (Camera20x20.activeSelf)
        {
            Camera20x20.SetActive(false);
            camera20x20AudioLis.enabled = false;
            
            CameraOne.SetActive(true);
            cameraOneAudioLis.enabled = true;

        }
        else
        {
            
            CameraOne.SetActive(false);
            cameraOneAudioLis.enabled = false;
            
            cameraTwoAudioLis.enabled = false;
            CameraTwo.SetActive(false);
            
            Camera20x20.SetActive(true);
            camera20x20AudioLis.enabled = true;
        }

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
            
            cameraTwoAudioLis.enabled = false;
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
