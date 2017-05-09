using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using UDBase.Controllers.UserSystem;
using UDBase.Utils;

public class LeaderboardControls : MonoBehaviour {

	public InputField UserField;
	public InputField VersionField;
	public InputField ParamField;
	public InputField ScoreField;
	public Button SendButton;
	public Button RefreshButton;
	public LeaderboardContent Content;
	public GameObject LoadingItem;

	public List<string> NameTemplates = new List<string>();

	bool Loading {
		set {
			SendButton.interactable = !value;
			RefreshButton.interactable = !value;
			LoadingItem.SetActive(value);
		}
	}

	void Awake() {
		SendButton.onClick.AddListener(StartSend);
		RefreshButton.onClick.AddListener(StartRefresh);
		UserField.onValueChanged.AddListener(OnUserChanged);
		ScoreField.onValueChanged.AddListener(OnScoreChanged);
	}

	void Start() {
		InitUserName();
		InitRandomScore();
	}

	void OnUserChanged(string newValue) {
		User.Name = newValue;
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

	void InitUserName() {
		if ( string.IsNullOrEmpty(User.Name) ) {
			User.Name = GenerateUserName();
		}
		UserField.text = User.Name;
	}

	string GenerateUserName() {
		if ( NameTemplates.Count > 0 ) {
			var template = RandomUtils.GetItem(NameTemplates);
			return string.Format("{0}_{1}", template, Random.Range(0, 255));
		}
		return "";
	}

	void InitRandomScore() {
		ScoreField.text = (Random.Range(1, 100) * 10).ToString();
	}

	void StartSend() {
		Loading = true;
		EndSend();
	}

	void EndSend() {
		Loading = false;
		InitRandomScore();
	}

	void StartRefresh() {
		Loading = true;
		EndRefresh();
	}

	void EndRefresh() {
		Loading = false;
	}
}
