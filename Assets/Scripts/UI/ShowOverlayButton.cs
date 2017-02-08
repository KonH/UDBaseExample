using UDBase.UI.Common;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.LogSystem;

public class ShowOverlayButton : ActionButton {
    public UIOverlay DirectWindow;
	public ContentId ContentWindow;

	public override bool IsInteractable() {
        return true;
    }

	public override bool IsVisible() {
        return true;
	}

    public override void OnClick() {
		AddOverlay();
    }

	void AddOverlay() {
		if( DirectWindow ) {
			UIManager.Current.ShowOverlay(DirectWindow.gameObject, OnAnyOverlayClosed);
		} else if( ContentWindow ) {
        	UIManager.Current.ShowOverlay(ContentWindow, OnAnyOverlayClosed);
		}
	}

	void OnAnyOverlayClosed() {
		Log.Message("TestOverlay is closed.", LogTags.UI);
	}
}
