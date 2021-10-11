using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCamera : MonoBehaviour
{
    [SerializeField] private GameObject cameraOne;
    [SerializeField] private GameObject cameraTwo;

    AudioListener AudioListenerOne;
    AudioListener AudioListenerTwo;

    // Start is called before the first frame update
    void Start()
    {
        AudioListenerOne = cameraOne.GetComponent<AudioListener>();
        AudioListenerTwo = cameraTwo.GetComponent<AudioListener>();

        cameraPositionChange(PlayerPrefs.GetInt("CameraPosition"));
    }

    // Update is called once per frame
    void Update()
    {
        switchCamera();
    }

    public void cameraPositionM()
    {
        cameraChangeCounter();
    }
    void switchCamera()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            cameraChangeCounter();
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

        if(camPosition == 0)
        {
            cameraOne.SetActive(true);
            AudioListenerOne.enabled = true;

            AudioListenerTwo.enabled = false;
            cameraTwo.SetActive(false);
        }

        if (camPosition == 1)
        {
            cameraTwo.SetActive(true);
            AudioListenerTwo.enabled = true;

            AudioListenerOne.enabled = false;
            cameraOne.SetActive(false);
        }
    }
}
