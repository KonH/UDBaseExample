#if Scheme_TestScheme
using UDBase.Common;
using UDBase.Controllers.LogSystem;
using UDBase.Controllers.ConfigSystem;
using UDBase.Controllers.SaveSystem;
using UDBase.Controllers.SceneSystem;
using UDBase.Controllers.EventSystem;
using UDBase.Controllers.ContentSystem;
using UDBase.Controllers.UTime;
using UDBase.Controllers.UserSystem;
using UDBase.Controllers.LeaderboardSystem;
using UDBase.Controllers.AudioSystem;
using UDBase.Controllers.SoundSystem;
using UDBase.Controllers.MusicSystem;

public class ProjectScheme : Scheme {

	public ProjectScheme() {
		//AddController<Log>      (new UnityLog(), new VisualLog());
	}
}
#endif
