using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class IngameUI : MonoBehaviour 
{

    [SerializeField] private Text _scoreTxt;
    [SerializeField] private Text _timeTxt;
    private PlayerData _playerData;

    void Start() 
    {
        _playerData = GameObject.FindGameObjectWithTag("GameController").GetComponent<PlayerData>();
    }

    public void UpdateUI() 
    {
        _scoreTxt.text = "Score: " + _playerData.score;
        _timeTxt.text = "Time: " + _playerData.time;
    }

}
