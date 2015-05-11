using UnityEngine;
using System.Collections;

public class Tools : MonoBehaviour 
{

    public void LoadScene(string scene) 
    {
        Application.LoadLevel(scene);
    }

    public void ReloadScene() 
    {
        Application.LoadLevel(Application.loadedLevel);
    }

    public void QuitGame() 
    {
        Application.Quit();
    }

    public void ToggleActive(GameObject target) 
    {
        target.SetActive(!target.activeSelf);
    }
}
