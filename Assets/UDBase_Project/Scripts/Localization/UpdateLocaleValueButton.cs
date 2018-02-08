using UnityEngine;
using UnityEngine.UI;
using UDBase.Controllers.LocalizationSystem.UI;

[RequireComponent(typeof(Text))]
public class UpdateLocaleValueButton : MonoBehaviour {
	public LocaleText Text;

	int _value;

	void Awake() {
		UpdateValue();
		GetComponent<Button>().onClick.AddListener(UpdateValue);
	}

	void UpdateValue() {
		Text.UpdateArguments(_value.ToString());
		_value++;
	}
}
