using UnityEngine;
using System.Collections;

public class ObjRespawner : MonoBehaviour 
{

    [SerializeField]
    private GameObject[] _spawnpoints;

    public void Respawn(GameObject obj) 
    {
        int i = Mathf.RoundToInt(Random.Range(0f, _spawnpoints.Length -1));
        GameObject spawnpoint = _spawnpoints[i];

        // So that it doesnt respawn on it's current pos
        if (obj.transform.position == spawnpoint.transform.position) 
        {
            i = Mathf.RoundToInt(Random.Range(0f, _spawnpoints.Length -1));
            spawnpoint = _spawnpoints[i];
        }

        // We don't actually respawn it, we move the object.
        obj.transform.position = spawnpoint.transform.position;
    }

}
