using UnityEngine;
using System.Collections;
using System;

public class PlayerData : MonoBehaviour 
{

    private float _time = 60;
    private int _score = 0;
    private IngameUI _ingameUI;

    void Start() 
    {
        _ingameUI = GameObject.FindGameObjectWithTag("IngameUI").GetComponent<IngameUI>();
    }

    void FixedUpdate() 
    {
        _time -= Time.deltaTime;
        _time = (float)Math.Round(_time, 2);
        _ingameUI.UpdateUI();
    }

    public void Increase(int amount) 
    {
        _time += amount;
        _score += 1;
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

    public float time 
    {
        get 
        {
            return _time;
        }
    }

}
