using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.UTime;
using UDBase.Controllers.SaveSystem;

public class TimerExample : MonoBehaviour {

	public Text   TimeText     = null;
	public Text   TimerText    = null;
	public Button RewardButton = null;
	public int    RewardTime   = 30;

	DateTime _curLocalTime   = DateTime.MinValue;
	DateTime _curRemoteTime  = DateTime.MinValue;
	int      _lastTimeSecond = -1;
	bool     _canGetReward   = false;

	void Start () {
		RewardButton.onClick.AddListener(OnRewardButtonClick);
		UpdateButtonState(false);
	}

	void OnRewardButtonClick() {
		var rewardNode = Save.GetNode<RewardNode>();
		rewardNode.LastRewardTime = _curRemoteTime;
		Save.SaveNode(rewardNode);
		UpdateButtonState(false);
	}
	
	void UpdateButtonState(bool canGetReward) {
		RewardButton.interactable = canGetReward;
	}

	void UpdateTimes() {
		var isTrusted = UTime.IsTrusted();
		var isStable = UTime.IsStable();
		_curLocalTime  = UTime.GetUntrustedTime();
		_curRemoteTime = UTime.GetTrustedTime();
		if( _lastTimeSecond != _curLocalTime.Second ) {
			_lastTimeSecond = _curLocalTime.Second;
			TimeText.text = string.Format(
				"local: {0}\n remote: {1}\n (trusted: {2}, stable: {3})",
				_curLocalTime.ToString("G"),
				_curRemoteTime.ToString("G"),
				isTrusted, 
				isStable);
		}
		if( isTrusted ) {
			var rewardNode = Save.GetNode<RewardNode>();
			var lastTime = rewardNode.LastRewardTime;
			var interval = (_curRemoteTime - lastTime).TotalSeconds;
			if( interval > RewardTime ) {
				TimerText.text = "Ready";
				UpdateButtonState(true);
			} else {
				TimerText.text = string.Format("Wait: {0:0.0}", Math.Round(interval, 1));
				UpdateButtonState(false);
			}
		} else {
			TimerText.text = "Not Ready";
			UpdateButtonState(false);
		}
	}

	void Update () {
		_canGetReward = UTime.IsStable();
		UpdateButtonState(_canGetReward);
		UpdateTimes();
	}
}
