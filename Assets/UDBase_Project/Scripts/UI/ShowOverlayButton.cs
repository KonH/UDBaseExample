using UDBase.UI;
using UDBase.UI.Common;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LogSystem;
using Zenject;

public class ShowOverlayButton : ActionButton {
    public UIOverlay DirectWindow;
	public ContentId ContentWindow;

	ILog      _log;
	UIManager _manager;

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
	public void Init(ILog log, UIManager manager) {
		_log     = log;
		_manager = manager;
	}

	void AddOverlay() {
		if( DirectWindow ) {
			_manager.ShowOverlay(DirectWindow.gameObject, OnAnyOverlayClosed);
		} else if( ContentWindow ) {
        	_manager.ShowOverlay(ContentWindow, OnAnyOverlayClosed);
		}
	}

	void OnAnyOverlayClosed() {
		_log.Message(UI.Context, "TestOverlay is closed.");
	}
}
