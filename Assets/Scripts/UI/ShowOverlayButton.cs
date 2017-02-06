using UDBase.UI.Common;
using UDBase.Controllers.ContentSystem;

public class ShowOverlayButton : ActionButton {
    public UIElement DirectWindow;
	public ContentId ContentWindow;

	public override bool IsInteractable() {
        return true;
    }

	public override bool IsVisible() {
        return true;
	}

    public override void OnClick() {
		if( DirectWindow ) {
			UIManager.Current.ShowOverlay(DirectWindow);
		} else if( ContentWindow ) {
        	UIManager.Current.ShowOverlay(ContentWindow);
		}
    }
}
