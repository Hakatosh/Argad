using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

namespace Game.UI
{
	public class HealthDisplay : MonoBehaviour
	{
		[SerializeField] AEntities m_entity;
		[SerializeField] GameObject m_life;
		[SerializeField] Image m_lifeImage;

		private Sequence m_sequence;

		private void Awake ()
		{
			m_entity.OnDamageTaken += DisplayLife;
		}

		// Start is called before the first frame update
		void Start ()
		{
			DisplayLife();
		}

		private void OnDestroy ()
		{
			if (m_sequence.IsActive())
				m_sequence.Kill();
			m_entity.OnDamageTaken -= DisplayLife;
		}

		// Update is called once per frame
		void Update ()
		{
		}

		private void DisplayLife ()
		{
			m_sequence = DOTween.Sequence();
			m_sequence.Append(m_life.transform.DOScale(1.5f, 0.25f));
			m_sequence.Append(m_life.transform.DOScale(0.5f, 0.25f));
			m_sequence.Append(m_life.transform.DOScale(1f, 0.25f));

			m_lifeImage.transform.DOScaleX(m_entity.health / m_entity.maxHealth, 0.5f);
		}
	}
}
