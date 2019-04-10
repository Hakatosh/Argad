using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class ApplicationManager : MonoBehaviour
	{

		private static ApplicationManager instance { get; set; }
		[SerializeField] private GameDatas m_gameDatas;

		private void Awake ()
		{
			if (ApplicationManager.instance != null)
			{
				GameObject.Destroy(this.gameObject);
				return;
			}

			ApplicationManager.instance = this;
			GameObject.DontDestroyOnLoad(this.gameObject);
		}

		public static GameDatas datas
		{
			get { return (ApplicationManager.instance.m_gameDatas); }
		}

		// Start is called before the first frame update
		void Start ()
		{

		}

		// Update is called once per frame
		void Update ()
		{

		}

		public static System.Action onRessourcesChange;
		public static void AddCoins (int value)
		{
			instance.m_gameDatas.golds += value;
			if (onRessourcesChange != null)
				onRessourcesChange.Invoke();
		}
	}
}
