using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.Editor {
	public static class SchemesMenuItems {
		[MenuItem("UDBase/Schemes/Default")]
		static void SwitchToScheme_Default() {
			SchemesTool.SwitchScheme("Default");
		}		[MenuItem("UDBase/Schemes/ConfigSaveState")]
		static void SwitchToScheme_ConfigSaveState() {
			SchemesTool.SwitchScheme("ConfigSaveState");
		}
	}
}
