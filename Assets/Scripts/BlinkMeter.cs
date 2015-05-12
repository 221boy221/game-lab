using UnityEngine;
using System.Collections;

public class BlinkMeter : MonoBehaviour 
{

    private TGCConnectionController _TGCcontroller;
    private ObjRespawner _objRespawner;

    void Start() 
    {
        _TGCcontroller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();
        _objRespawner = GameObject.FindGameObjectWithTag("ObjRespawner").GetComponent<ObjRespawner>();
        _TGCcontroller.UpdateBlinkEvent += OnBlink;
    }

    void OnBlink(int value) 
    {
        if (value > 50) 
        {
            _objRespawner.Respawn(null);
        }
    }

    // For devtesting
    void Update() {
        if (Input.GetKeyDown(KeyCode.P)) {
            Debug.Log("Blink");
            _objRespawner.Respawn(null);
        }
    }

}
