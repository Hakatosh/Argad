using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Game.UI
{
	public class MainPanel : MonoBehaviour
	{
		[Header("Ressources")]
		[SerializeField] private TextMeshProUGUI m_goldText;
		[SerializeField] private TextMeshProUGUI m_crystalText;

		private void Awake ()
		{
			ApplicationManager.onRessourcesChange += UpdateRessourcesDisplay;
		}

		// Start is called before the first frame update
		void Start ()
		{

		}

		// Update is called once per frame
		void Update ()
		{
		}

		private void UpdateRessourcesDisplay ()
		{
			m_goldText.text = ApplicationManager.datas.golds.ToString();
			m_crystalText.text = ApplicationManager.datas.crystals.ToString();
		}
	}
}