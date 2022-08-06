using System;
using System.Collections.Generic;

public partial class DictEquipEquip
{

	public Dictionary<int,List<Model>> qulityDictCaches;
	public Dictionary<int,List<Model>> fromDictCaches;
	public Dictionary<string,List<Model>> suit_equip_caches;

	public List<string> topEquipTypes = new List<string> ();
	public List<string> topMagicTypes = new List<string> ();


	public List<Model> defaultVal = new List<Model>();
	public List<Model> GetModelsByQulity(int qulity){
		if (qulityDictCaches == null || fromDictCaches == null) {
			InitDictIndexCaches ();
		}
		if (qulityDictCaches.ContainsKey (qulity)) {
			return qulityDictCaches [qulity];
		} else {
			return defaultVal;
		}
	}

	public List<Model> GetModelsByFrom (DictEquipEquipFromEnum equip_val)
	{
		if (qulityDictCaches == null || fromDictCaches == null) {
			InitDictIndexCaches ();
		}
		if (fromDictCaches.ContainsKey ((int)equip_val)) {
			return fromDictCaches [(int)equip_val];
		} else {
			return defaultVal;
		}
	}

	public List<Model> GetSuitEquips(string suit_equip_type){
		if (qulityDictCaches == null || fromDictCaches == null) {
			InitDictIndexCaches ();
		}
		if (suit_equip_caches.ContainsKey (suit_equip_type)) {
			return suit_equip_caches [suit_equip_type];
		} else {
			return defaultVal;
		}
	}

	public void InitDictIndexCaches(){

		qulityDictCaches = new Dictionary<int, List<Model>> ();
		fromDictCaches = new Dictionary<int, List<Model>> ();
		suit_equip_caches = new Dictionary<string, List<Model>> ();
		foreach (var d in Dict) {
			if (!qulityDictCaches.ContainsKey (d.Value.qulity)) {
				qulityDictCaches.Add (d.Value.qulity, new List<Model> ());
			}
			qulityDictCaches [d.Value.qulity].Add (d.Value);

			if (!fromDictCaches.ContainsKey (d.Value.from)) {
				fromDictCaches.Add (d.Value.from, new List<Model> ());
			}
			fromDictCaches [d.Value.from].Add (d.Value);

			if (!string.IsNullOrEmpty (d.Value.suit_equip_type)) {
				if (!suit_equip_caches.ContainsKey (d.Value.suit_equip_type)) {
					suit_equip_caches.Add (d.Value.suit_equip_type, new List<Model> ());
				}
				suit_equip_caches [d.Value.suit_equip_type].Add (d.Value);
			}
		}

		for (int i = 0; i < DictEquipEquipTypeEnumString.vlas.Length; i++) {
			var item = DictEquipEquipTypeEnumString.vlas [i];
			if (item == DictEquipEquipTypeEnumString.magic_key
				|| item == DictEquipEquipTypeEnumString.magic_key_left
				|| item == DictEquipEquipTypeEnumString.magic_key_right) {
				topMagicTypes.Add (item);
			} else {
				topEquipTypes.Add (item);
			}
		}
	}

	public List<string> GetNormalEquipsType(){
		if (qulityDictCaches == null || fromDictCaches == null) {
			InitDictIndexCaches ();
		}
		return topEquipTypes;
	}

	public List<string> GetMagicEquipsType(){
		if (qulityDictCaches == null || fromDictCaches == null) {
			InitDictIndexCaches ();
		}
		return topMagicTypes;
	}
}