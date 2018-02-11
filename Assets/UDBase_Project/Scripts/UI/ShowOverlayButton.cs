using UDBase.UI.Common;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LogSystem;
using Zenject;
using UDBase.UI;

public class ShowOverlayButton : ActionButton {
    public UIOverlay DirectWindow;
	public ContentId ContentWindow;

	ILog _log;

	public override bool IsInteractable() {
        return true;
    }

	public override bool IsVisible() {
        return true;
	}

    public override void OnClick() {
		AddOverlay();
    }

	[Inject]
	public void Init(ILog log) {
		_log = log;
	}

	void AddOverlay() {
		if( DirectWindow ) {
			UIManager.Current.ShowOverlay(DirectWindow.gameObject, OnAnyOverlayClosed);
		} else if( ContentWindow ) {
        	UIManager.Current.ShowOverlay(ContentWindow, OnAnyOverlayClosed);
		}
	}

	void OnAnyOverlayClosed() {
		_log.Message(UI.Context, "TestOverlay is closed.");
	}
}
