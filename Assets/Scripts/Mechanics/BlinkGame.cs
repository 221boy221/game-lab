using UnityEngine;
using System.Collections;

public class BlinkGame : MonoBehaviour 
{
	[SerializeField] private GameObject _eyesOpen;
	[SerializeField] private GameObject _eyesShut;
	private float _waitTime;
	[SerializeField]private bool _playerWin;
	[SerializeField]private bool _pcWin;
	
	void Awake () 
	{
		_waitTime = Random.Range (15,90);
		StartCoroutine (Blink());
	}

	IEnumerator Blink () 
	{
		yield return new WaitForSeconds (_waitTime);
		_eyesOpen.SetActive(false);
		if(_pcWin == false)
		{
			_playerWin = true;
		}
	}

	void Update ()
	{
		if(_playerWin == true)
		{
			Debug.Log("Player Wins");
		}
		else if (_pcWin == true)
		{
			Debug.Log("PC Wins");
		}
	}

	public void Button ()
	{
		if(_playerWin == false)
		{
			_pcWin = true;
		}
	}
}
