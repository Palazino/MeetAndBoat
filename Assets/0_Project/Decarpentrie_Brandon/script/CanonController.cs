using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace yodan
{
    public class CanonController : MonoBehaviour
    {
        [SerializeField] float m_rotation = 90f;
        [SerializeField] float m_inclinationSpeed = 45f;

        [SerializeField] Transform m_wathToMove;

        public float m_wantedVerticalAngle = 0;

        public void SetCanonDownUp(float valueDegree)
        {
            float angle = valueDegree * m_inclinationSpeed * Time.deltaTime;
            m_wantedVerticalAngle += angle;
        }

        public void SetRotation(float value)
        {
            float angle = value * m_rotation * Time.deltaTime;
            m_wathToMove.Rotate(0, angle, 0);
        }

        public void Update()
        {
            if (m_wantedVerticalAngle > 0) {
                float angleToMove = m_inclinationSpeed * Time.deltaTime;
                m_wathToMove.Rotate(m_inclinationSpeed, 0, 0);
                //m_wantedVerticalAngle-= angleToMove
            }
        }

        void OnEnable()
        {
            var listenInput = FindAnyObjectByType<ListenInput>();
            if (listenInput != null)
            {
                listenInput.m_onAxisYChanged.AddListener(SetCanonDownUp);
                listenInput.m_onAxisXChanged.AddListener(SetRotation);
            }
        }
        private void OnDisable()
        {
            var listenInput = FindObjectOfType<ListenInput>();
            if (listenInput != null)
            {
                listenInput.m_onAxisYChanged.RemoveListener(SetCanonDownUp);
                listenInput.m_onAxisXChanged.RemoveListener(SetRotation);
            }
        }
    }
}
