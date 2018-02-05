using UDBase.UI.Common;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LogSystem;
using Zenject;

public class ShowDialogButton : ActionButton {
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
		AddDialog();
    }

	[Inject]
	public void Init(ILog log) {
		_log = log; 
	}

	void AddDialog() {
		if( DirectWindow ) {
			UIManager.Current.ShowDialog(DirectWindow.gameObject, OnOkClicked, OnCancelClicked);
		} else if( ContentWindow ) {
        	UIManager.Current.ShowDialog(ContentWindow, OnOkClicked, OnCancelClicked);
		}
	}

	void OnOkClicked() {
		_log.Message(LogTags.UI, "TestDialog is accepted.");
		AddDialog();
	}

	void OnCancelClicked() {
		_log.Message(LogTags.UI, "TestDialog is closed.");
	}
}
