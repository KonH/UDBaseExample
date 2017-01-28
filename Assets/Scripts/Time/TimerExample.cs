using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.UTime;

public class TimerExample : MonoBehaviour {

	public Text   TimeText     = null;
	public Text   TimerText    = null;
	public Button RewardButton = null;

	DateTime _curTime      = DateTime.MinValue;
	int      _lastSecond   = -1;
	bool     _canGetReward = false;

	void Start () {
		RewardButton.onClick.AddListener(OnRewardButtonClick);
		UpdateButtonState(false);
	}

	void OnRewardButtonClick() {
		// TODO
	}
	
	void UpdateButtonState(bool canGetReward) {
		RewardButton.interactable = canGetReward;
	}

	void UpdateTimes() {
		_curTime = UTime.CurrentTime();
		if( _lastSecond != _curTime.Second ) {
			_lastSecond = _curTime.Second;
			TimeText.text = _curTime.ToString("G");
		}
		if( UTime.IsStableTime() ) {
			// TODO
			TimerText.text = "Ready";
		} else {
			TimerText.text = "Not Ready";
		}
	}

	void Update () {
		_canGetReward = UTime.IsStableTime();
		UpdateButtonState(_canGetReward);
		UpdateTimes();
	}
}
