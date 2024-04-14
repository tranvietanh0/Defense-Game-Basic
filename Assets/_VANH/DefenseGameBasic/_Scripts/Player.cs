using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.DefenseBasic
{
    public class Player : MonoBehaviour, IComponentChecking
    {
        [SerializeField] private float m_atkRate;
        private Animator m_anim;
        private float m_curAtkRate;
        private bool m_isAttacked;
        private bool m_isDeath;
        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = m_atkRate;
        }

        public bool IsComponentsNull()
        {
            return m_anim == null;
        }
        private void Update()
        {
            if (IsComponentsNull())
            {
                return;
            }
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
                m_anim.SetBool(Const.ATTACK_ANIM, true);
                m_isAttacked = true;
            }

            if (m_isAttacked)
            {
                m_curAtkRate -= Time.deltaTime;
                if (m_curAtkRate <= 0)
                {
                    m_isAttacked = false;
                    m_curAtkRate = m_atkRate;
                }
            }

        }

        public void ResetAtkAnim()
        {
            if (IsComponentsNull())
            {
                return;
            }
            m_anim.SetBool(Const.ATTACK_ANIM, false);
            
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IsComponentsNull())
            {
                return;
            }
            
            if (col.CompareTag("EnemyWeapon") && !m_isDeath)
            {
                m_anim.SetTrigger(Const.DEAD_ANIM);
                m_isDeath = true;
                gameObject.layer = LayerMask.NameToLayer(Const.DEAD_LAYER);
            }
        }
    }
}
