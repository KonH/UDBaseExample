using System.Collections.Generic;
using UnityEngine;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.AnalyticsSystem;
using Zenject;

public class SceneTracker : MonoBehaviour {
	IEvent _events;
	IAnalytics _analytics;

	[Inject]
	public void Init(IEvent events, IAnalytics analytics) {
		_events = events;
		_analytics = analytics;
	}

	void Start() {
		_events.Subscribe<Scene_Loaded>(this, OnSceneLoaded);
	}

	void OnDestroy() {
		_events.Unsubscribe<Scene_Loaded>(OnSceneLoaded);
	}

	void OnSceneLoaded(Scene_Loaded e) {
		_analytics.UpdateSessionData("custom_data", (arg) => {
			if ( arg == null ) {
				return 0;
			}
			return (int)arg + 1;
		});
		_analytics.Event("load_scene", new Dictionary<string, object> {
			{ "scene_name", e.SceneInfo.Name }
		});
	}
}
