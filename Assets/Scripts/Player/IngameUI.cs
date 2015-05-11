using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour 
{

    [SerializeField] private Text _scoreTxt;
    [SerializeField] private Text _timeTxt;
    [SerializeField] GameObject _menu;
    private PlayerData _playerData;
    private Tools _tools;

    void Start() 
    {
        _playerData = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerData>();
        _tools = GetComponent<Tools>();
    }

    void Update() 
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            Screen.lockCursor = !Screen.lockCursor;

            if (Cursor.lockState == CursorLockMode.Locked) 
            {
                Cursor.lockState = CursorLockMode.None;
            } else {
                Cursor.lockState = CursorLockMode.Locked;
            }

            Cursor.visible = !Cursor.visible;
                
            _tools.ToggleActive(_menu);
        }
    }

    public void UpdateUI() 
    {
        _scoreTxt.text = "Score: " + _playerData.score;
        _timeTxt.text = "Time: " + _playerData.time;
    }

}
