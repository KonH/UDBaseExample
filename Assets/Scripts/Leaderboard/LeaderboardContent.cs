using UnityEngine;
using System.Collections.Generic;

public class LeaderboardContent : MonoBehaviour {
	public ScoreItem ItemPrefab;

	List<ScoreItem> Items = new List<ScoreItem>();

	public void Clear() {
		for ( int i = 0; i < Items.Count; i++ ) {
			Items[i].SetState(false);
		}
	}

	ScoreItem GetItem() {
		for ( int i = 0; i < Items.Count; i++ ) {
			var item = Items[i];
			if ( !item.Active ) {
				return item;
			}
		}
		var newGo = Instantiate(ItemPrefab.gameObject, transform) as GameObject;
		var newItem = newGo.GetComponent<ScoreItem>();
		Items.Add(newItem);
		return newItem;
	}

	public void Add(int place, string name, int scores) {
		var item = GetItem();
		item.SetState(true);
		item.PlaceText.text = string.Format("{0}.", place);
		item.NameText.text = name;
		item.ScoresText.text = scores.ToString();
		item.transform.SetAsLastSibling();
	}
}
