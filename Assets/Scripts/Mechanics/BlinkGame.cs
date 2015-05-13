using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BlinkGame : MonoBehaviour 
{
	[SerializeField]private Animator _anim;
	[SerializeField]private GameObject _restartButton;
	[SerializeField]private Text _winOrLoseText;
	private TGCConnectionController _controller;
	private float _waitTime;
	private float _playRandomAnim;
	private bool _playerWin;
	private bool _pcWin;
	private bool _playingAnim;
	
	void Awake () 
	{
		_waitTime = Random.Range (15,90);
		StartCoroutine (Blink());
	}

	void Start ()
	{
		_controller = GameObject.Find("NeuroSkyTGCController").GetComponent<TGCConnectionController>();

		_controller.UpdateBlinkEvent += OnBlink;
	}

	void OnBlink (int value)
	{
		if(value > 50 && _playerWin == false)
		{
			_pcWin = true;
			WinOrLose();
		}
	}

	IEnumerator Blink () 
	{
		yield return new WaitForSeconds (_waitTime);

		if(_pcWin == false)
		{
			_playerWin = true;
			WinOrLose();
		}
	}

	void Update ()
	{
		_playRandomAnim = Random.Range (1,1000);

		if(_pcWin == false && _playerWin == false)
		{
			if(_playRandomAnim == 1)
			{
				_anim.SetTrigger ("Squint");
			}
			else if(_playRandomAnim == 2)
			{
				_anim.SetTrigger ("Frown");
			}
			else if(_playRandomAnim == 3)
			{
				_anim.SetTrigger ("Smile");
			}
		}
	}

	void WinOrLose ()
	{
		_restartButton.SetActive (true);

		if(_pcWin == true)
		{
			_anim.SetTrigger ("Smile");
			_winOrLoseText.text = "YOU LOSE!";
		}
		else if(_playerWin == true)
		{
			_anim.SetTrigger ("Blink");
			_winOrLoseText.text = "YOU WIN!";
		}
	}
}
