using UnityEngine;
using System.Collections;

public class ObjBehaviour : MonoBehaviour 
{

    private ObjRespawner _objRespawner;
    private PlayerData _playerData;

    void Start() 
    {
        _objRespawner = GameObject.FindGameObjectWithTag("ObjRespawner").GetComponent<ObjRespawner>();
        _playerData = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerData>();
    }

    public void OnInteraction() 
    {
        _objRespawner.Respawn(gameObject);
        _playerData.Increase(5);
    }

}
