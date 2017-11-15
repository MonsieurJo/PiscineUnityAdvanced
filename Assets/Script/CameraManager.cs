using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour {

    public GameObject cameraTPS;
    public GameObject cameraShoulder;
    public GameObject cameraFPS;

    private int _cameraUsed = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown("c") && _cameraUsed <=3)
        {
            if (_cameraUsed == 3)
            {
                _cameraUsed = 1;
            }
            else
            {
                _cameraUsed++;
            }
        }
        switch (_cameraUsed)
        {
            case 1:
                cameraTPS.SetActive(true);
                cameraFPS.SetActive(false);
                break;
            case 2:
                cameraShoulder.SetActive(true);
                cameraTPS.SetActive(false);
                break;
            case 3:
                cameraFPS.SetActive(true);
                cameraShoulder.SetActive(false);
                break;
            default:
                Debug.Log("Erreur Camera");
                break;
        }
    }
}
