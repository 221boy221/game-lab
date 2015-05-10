using UnityEngine;
using System.Collections;

public class PlayerData : MonoBehaviour 
{

    private int _score = 0;
    private IngameUI _ingameUI;

    void Start() {
        _ingameUI = GameObject.FindGameObjectWithTag("IngameUI").GetComponent<IngameUI>();
    }

    public void Increase(int amount) 
    {
        _score += amount;
        _ingameUI.UpdateUI();
    }


    // Getters & Setters

    public int score 
    {
        get 
        {
            return _score;
        }
    }

}
