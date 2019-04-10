using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Datas", menuName = "Inventory/PlayerDatas", order = 1)]
public class GameDatas : ScriptableObject
{
	public int golds = 0;
	public int crystals = 0;
}
