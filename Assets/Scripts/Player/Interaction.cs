using UnityEngine;
using System.Collections;

public class Interaction : MonoBehaviour 
{

    private GameObject col;

    void OnTriggerEnter(Collider other)
    {
        col = other.gameObject;
    }

    void OnTriggerExit(Collider other)
    {
        col = null;
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (col != null) // This way the RayCast will only run if a said object is in the collider
            {
                if (GrabAble())
                {
                    Debug.Log("True");
                    //Destroy(col.gameObject);
                    //objRespawner.Respawn(col.gameObject);
                    ObjBehaviour _objBehaviour = col.GetComponent<ObjBehaviour>();
                    _objBehaviour.OnInteraction();
                }
                Debug.Log("False");
            }
        }
    }

    // Is the player aiming at the so called Object?
    bool GrabAble() 
    {
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Ray ray = new Ray(transform.position, forward);
        RaycastHit hit;

        Physics.Raycast(ray, out hit, 10f);
        Debug.DrawRay(transform.position, forward);

        // Return bool
        return hit.collider.gameObject == col;
    }

}
