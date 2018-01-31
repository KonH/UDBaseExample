using System;
using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.UTime;
using UDBase.Controllers.SaveSystem;
using Zenject;

public class TimerExample : MonoBehaviour {

	public Text   TimeText     = null;
	public Text   TimerText    = null;
	public Button RewardButton = null;
	public int    RewardTime   = 30;

	DateTime _curTime        = DateTime.MinValue;
	int      _lastTimeSecond = -1;

	ITime _time;
	ISave _save;

	[Inject]
	public void Init(ITime time, ISave save) {
		_time = time;
		_save = save;
	}

	void Start () {
		RewardButton.onClick.AddListener(OnRewardButtonClick);
		UpdateButtonState(false);
	}

	void OnRewardButtonClick() {
		var rewardNode = _save.GetNode<RewardNode>();
		rewardNode.LastRewardTime = _curTime;
		_save.SaveNode(rewardNode);
		UpdateButtonState(false);
	}
	
	void UpdateButtonState(bool canGetReward) {
		RewardButton.interactable = canGetReward;
	}

	void UpdateTimes() {
		var isStable = _time.IsAvailable || _time.IsFailed;
		_curTime  = _time.CurrentTime;
		if( _lastTimeSecond != _curTime.Second ) {
			_lastTimeSecond = _curTime.Second;
			TimeText.text = $"Time: {_curTime.ToString("G")}\n Stable: {isStable}";
		}
		var rewardNode = _save.GetNode<RewardNode>();
		var lastTime = rewardNode.LastRewardTime;
		var interval = (_curTime - lastTime).TotalSeconds;
		if( interval > RewardTime ) {
			TimerText.text = "Ready";
			UpdateButtonState(true);
		} else {
			TimerText.text = string.Format("Wait: {0:0.0}", Math.Round(interval, 1));
			UpdateButtonState(false);
		}
	}

	void Update () {
		UpdateButtonState(_time.IsAvailable || _time.IsFailed);
		UpdateTimes();
	}
}
