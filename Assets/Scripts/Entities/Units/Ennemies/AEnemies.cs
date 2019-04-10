using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AEnemies : AUnits
	{
		[SerializeField] private int m_value = 50;

		// Start is called before the first frame update
		void Start ()
		{

		}

		// Update is called once per frame
		public override void TakeDamage (float damages)
		{
			health -= damages;
			if (health <= 0)
			{
				Destroy(gameObject);
				ApplicationManager.AddCoins(m_value);
			}
			if (OnDamageTaken != null)
				OnDamageTaken.Invoke();
		}

		protected override void OnTriggerEnter (Collider other)
		{
			if (m_enemy == null)
			{
				AUnits enemy = other.GetComponent<AUnits>();

				if (enemy != null)
				{
					m_enemy = enemy;
				}
			}
		}

		protected override void OnTriggerExit (Collider other)
		{
			if (m_enemy != null)
			{
				AUnits enemy = other.GetComponent<AUnits>();

				if (enemy == m_enemy)
				{
					m_enemy = null;
				}
			}
		}
	}
}
