using UnityEngine;
using System.Collections;

public class ObjRespawner : MonoBehaviour 
{

    [SerializeField]
    private GameObject[] _spawnpoints;
    private GameObject _obj;

    public void Respawn(GameObject obj) 
    {
        if (obj == null) 
        {
            _obj = GameObject.FindGameObjectWithTag("Object");
        } 
        else 
        {
            _obj = obj;
        }
        
        int i = Mathf.RoundToInt(Random.Range(0f, _spawnpoints.Length -1));
        GameObject spawnpoint = _spawnpoints[i];

        // So that it doesnt respawn on it's current pos
        if (_obj.transform.position == spawnpoint.transform.position) 
        {
            i = Mathf.RoundToInt(Random.Range(0f, _spawnpoints.Length -1));
            spawnpoint = _spawnpoints[i];
        }

        // We don't actually respawn it, we move the object.
        _obj.transform.position = spawnpoint.transform.position;
    }

}
