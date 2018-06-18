using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.UserSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Utils;
using Zenject;

public class LeaderboardControls : MonoBehaviour, ILogContext {

	public InputField UserField;
	public InputField VersionField;
	public InputField ParamField;
	public InputField ScoreField;
	public Button SendButton;
	public Button RefreshButton;
	public LeaderboardContent Content;
	public GameObject LoadingItem;

	public int Limit = 100;
	public List<string> NameTemplates = new List<string>();

	bool Loading {
		set {
			SendButton.interactable = !value;
			RefreshButton.interactable = !value;
			LoadingItem.SetActive(value);
		}
	}

	IUser _user;
	ILeaderboard _leaderboard;
	ULogger _log;

	[Inject]
	public void Init(IUser user, ILeaderboard leaderboard, ILog log) {
		_user = user;
		_leaderboard = leaderboard;
		_log = log.CreateLogger(this);
	}

	void Awake() {
		SendButton.onClick.AddListener(StartSend);
		RefreshButton.onClick.AddListener(StartRefresh);
		UserField.onValueChanged.AddListener(OnUserChanged);
		VersionField.onValueChanged.AddListener(OnVersionChanged);
		ScoreField.onValueChanged.AddListener(OnScoreChanged);
	}

	void Start() {
		InitUser();
		InitVersion();
		InitRandomScore();
		StartRefresh();
	}

	void OnUserChanged(string newValue) {
		_user.Name = newValue;
	}

	void OnVersionChanged(string newValue) {
		_leaderboard.Version = newValue;
	}

	void OnScoreChanged(string newValue) {
		var safeValue = "";
		for ( int i = 0; i < newValue.Length; i++ ) {
			var c = newValue[i];
			if ( char.IsDigit(c) ) {
				safeValue += c;
			}
		}
		if ( safeValue != newValue ) {
			ScoreField.text = safeValue;
		}
	}

	void InitUser() {
		if ( string.IsNullOrEmpty(_user.Name) ) {
			_user.Id = GenerateUserId();
			_user.Name = GenerateUserName();
			_user.AddExternalId("test", GenerateUserId());
		}
		UserField.text = _user.Name;
		_log.MessageFormat("User.Id: '{0}'", _user.Id);
		_log.MessageFormat("User.ExternalId[\"test\"]: '{0}'", _user.FindExternalId("test"));
	}

	string GenerateUserName() {
		if ( NameTemplates.Count > 0 ) {
			var template = RandomUtils.GetItem(NameTemplates);
			return string.Format("{0}_{1}", template, Random.Range(0, 255));
		}
		return "";
	}

	string GenerateUserId() {
		return Random.Range(1, int.MaxValue).ToString();
	}

	void InitVersion() {
		VersionField.text = _leaderboard.Version;
	}

	void InitRandomScore() {
		ScoreField.text = (Random.Range(1, 100) * 10).ToString();
	}

	void StartSend() {
		int score = 0;
		if ( int.TryParse(ScoreField.text, out score) ) {
			Loading = true;
			_leaderboard.PostScore(ParamField.text, UserField.text, score, EndSend);
		}
	}

	void EndSend(bool result) {
		Loading = false;
		if ( result ) {
			InitRandomScore();
			StartRefresh();
		}
	}

	void StartRefresh() {
		Loading = true;
		_leaderboard.Version = VersionField.text;
		_leaderboard.GetScores(Limit, ParamField.text, EndRefresh);
	}

	void EndRefresh(List<LeaderboardItem> items) {
		Loading = false;
		Content.Clear();
		if ( items != null ) {
			for ( int i = 0; i < items.Count; i++ ) {
				var item = items[i];
				Content.Add(
					i + 1,
					item.UserName,
					item.Score);
			}
		}
	}
}
