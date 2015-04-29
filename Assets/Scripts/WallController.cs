using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour
{
    GameObject wallsetOne;
    GameObject wallsetTwo;

    int selectedWall = 1;

    // Use this for initialization
    void Start()
    {
        wallsetOne = GameObject.FindGameObjectWithTag("WallsetOne");
        wallsetTwo = GameObject.FindGameObjectWithTag("WallsetTwo");
        wallsetTwo.transform.position += new Vector3(0, -10, 0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            swapWalls();
            
        }
    }

    void swapWalls()
    {
        if(selectedWall == 1)
        {
            wallsetOne.transform.position += new Vector3(0, -10, 0);
            wallsetTwo.transform.position += new Vector3(0, 10, 0);
            selectedWall = 2;
        }
        else
        {
            wallsetOne.transform.position += new Vector3(0, 10, 0);
            wallsetTwo.transform.position += new Vector3(0, -10, 0);
            selectedWall = 1;
        }
        
    }
}
