using UDBase.UI.Common;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LogSystem;

public class ShowDialogButton : ActionButton {
    public UIOverlay DirectWindow;
	public ContentId ContentWindow;

	public override bool IsInteractable() {
        return true;
    }

	public override bool IsVisible() {
        return true;
	}

    public override void OnClick() {
		AddDialog();
    }

	void AddDialog() {
		if( DirectWindow ) {
			UIManager.Current.ShowDialog(DirectWindow.gameObject, OnOkClicked, OnCancelClicked);
		} else if( ContentWindow ) {
        	UIManager.Current.ShowDialog(ContentWindow, OnOkClicked, OnCancelClicked);
		}
	}

	void OnOkClicked() {
		Log.Message("TestDialog is accepted.", LogTags.UI);
		AddDialog();
	}

	void OnCancelClicked() {
		Log.Message("TestDialog is closed.", LogTags.UI);
	}
}
