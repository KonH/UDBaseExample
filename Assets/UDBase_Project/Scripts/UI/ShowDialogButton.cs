using UDBase.UI;
using UDBase.UI.Common;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LogSystem;
using Zenject;

public class ShowDialogButton : ActionButton {
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
		AddDialog();
    }

	[Inject]
	public void Init(ILog log, UIManager manager) {
		_log     = log;
		_manager = manager;
	}

	void AddDialog() {
		if( DirectWindow ) {
			_manager.ShowDialog(DirectWindow.gameObject, OnOkClicked, OnCancelClicked);
		} else if( ContentWindow ) {
        	_manager.ShowDialog(ContentWindow, OnOkClicked, OnCancelClicked);
		}
	}

	void OnOkClicked() {
		_log.Message(UI.Context, "TestDialog is accepted.");
		AddDialog();
	}

	void OnCancelClicked() {
		_log.Message(UI.Context, "TestDialog is closed.");
	}
}
