using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace VANH.DefenseBasic
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float m_atkRate;
        private Animator m_anim;
        private float m_curAtkRate;
        private bool m_isAttacked;

        private void Awake()
        {
            m_anim = GetComponent<Animator>();
            m_curAtkRate = m_atkRate;
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0) && !m_isAttacked)
            {
                if (m_anim)
                {
                    m_anim.SetBool(Const.ATTACK_ANIM, true);
                    m_isAttacked = true;
                }
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
            if (m_anim)
            {
                m_anim.SetBool(Const.ATTACK_ANIM, false);
            }
        }
    }
}
