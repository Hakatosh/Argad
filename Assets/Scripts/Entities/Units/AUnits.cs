using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Game
{
	public class AUnits : AEntities
	{
		[SerializeField] protected float m_damages = 10f;
		[SerializeField] protected float m_attackSpeed = 1f;

		protected AUnits m_enemy;
		protected float m_attackTimer = 0f;

		// Start is called before the first frame update
		void Start ()
		{

		}

		// Update is called once per frame
		protected virtual void Update ()
		{
			if (m_attackTimer < m_attackSpeed)
				m_attackTimer += Time.deltaTime;

			if (m_enemy != null)
			{
				if (m_attackTimer >= m_attackSpeed)
				{
					m_attackTimer = 0f;
					m_enemy.TakeDamage(m_damages);
				}
			}
		}

		public virtual void TakeDamage (float damages)
		{
			health -= damages;
			if (health <= 0)
			{
				Destroy(gameObject);
			}
			if (OnDamageTaken != null)
				OnDamageTaken.Invoke();
		}

		protected virtual void OnTriggerEnter (Collider other)
		{
			if (m_enemy == null)
			{
				AEnemies enemy = other.GetComponent<AEnemies>();

				if (enemy != null)
				{
					m_enemy = enemy;
				}
			}
		}

		protected virtual void OnTriggerExit (Collider other)
		{
			if (m_enemy != null)
			{
				AEnemies enemy = other.GetComponent<AEnemies>();

				if (enemy == m_enemy)
				{
					m_enemy = null;
				}
			}
		}

	}
}
