using UnityEngine;
using UnityEditor;
using System.Collections;

namespace UDBase.Editor {
	public static class SchemesMenuItems {
		[MenuItem("UDBase/Schemes/Default")]
		static void SwitchToScheme_Default() {
			SchemesTool.SwitchScheme("Default");
		}		[MenuItem("UDBase/Schemes/ConfigSaveScheme")]
		static void SwitchToScheme_ConfigSaveScheme() {
			SchemesTool.SwitchScheme("ConfigSaveScheme");
		}
	}
}
