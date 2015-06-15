using UnityEngine;
using System.Collections;

public class WallController : MonoBehaviour
{
    GameObject wallsetOne;
    GameObject wallsetTwo;

    Vector3 startPosition;

    int selectedWall = 1;
    bool swapping = false;

    TGCConnectionController controller;

    float timer;
    float spawnTime = 3;

    Light playerLight;

    // Use this for initialization
    void Start()
    {
        wallsetOne = GameObject.FindGameObjectWithTag("WallsetOne");
        wallsetTwo = GameObject.FindGameObjectWithTag("WallsetTwo");
        startPosition = wallsetOne.transform.position;
        //wallsetTwo.transform.position += new Vector3(0, -10, 0);

        controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

        controller.UpdatePoorSignalEvent += OnUpdatePoorSignal;
        controller.UpdateAttentionEvent += OnUpdateAttention;
        controller.UpdateMeditationEvent += OnUpdateMeditation;

        controller.UpdateDeltaEvent += OnUpdateDelta;

        playerLight = GameObject.FindGameObjectWithTag("PlayerLight").GetComponent<Light>();
    }

    void OnUpdatePoorSignal(int value)
    {

    }

    void OnUpdateAttention(int value)
    {
        if(playerLight.range > 3)
        {
            playerLight.range = value / 6.6f;
        }
        else
        {
            playerLight.range = 3.3f;
        }
    }

    void OnUpdateMeditation(int value)
    {
        if (timer > spawnTime)
        {
            if (value < 65)
            {
                swapWalls();
            }
            timer = 0;
        }
    }

    void OnUpdateDelta(float value)
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        Debug.Log(timer);

        if (wallsetOne.transform.position.y > 4.5 && selectedWall == 2)
        {
            wallsetOne.transform.position += new Vector3(0, -0.05f, 0);
        }
        else if(wallsetOne.transform.transform.position.y < 8 && selectedWall == 1)
        {
            wallsetOne.transform.position += new Vector3(0, 0.05f, 0);
        }


        if(wallsetTwo.transform.position.y > -3.5f && selectedWall == 1)
        {
            wallsetTwo.transform.position += new Vector3(0, -0.05f, 0);
        }
        else if(wallsetTwo.transform.position.y < 0 && selectedWall == 2)
        {
            wallsetTwo.transform.position += new Vector3(0, 0.05f, 0);
        }
        

        if(Input.GetKeyDown(KeyCode.Q))
        {
            if(selectedWall == 1)
            {
                selectedWall = 2;
            }
            else if(selectedWall == 2)
            {
                selectedWall = 1;
            }
        }
    }

    void swapWalls()
    {
        if (selectedWall == 1)
        {
            selectedWall = 2;
        }
        else if (selectedWall == 2)
        {
            selectedWall = 1;
        }
    }
}
