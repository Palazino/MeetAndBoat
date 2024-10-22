using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CanonAxisMono : MonoBehaviour
{

    public float m_angleAdjustment = 90f;
    public float m_angle = 20;
    public float m_minAngle = -5;
    public float m_maxAngle = 90;
    public Vector3 m_rotationAxis = Vector3.up;
    public Transform m_whatToRotate;
    public bool m_inversValue = true;

    


    private void OnValidate()
    {
        RefreshPosition();
    }


    void Update()
    {
        RefreshPosition();
    }

    public void SetAngleWithAngle(float angle)
    {
        m_angle = angle;
    }

    public void SetPercentAngle01(float percent)
    {
        m_angle = Mathf.Lerp(m_minAngle, m_maxAngle, percent);
    }
    public void SetPercentAngle11(float percent)
    {
        float adjustPercent = (percent + 1f) / 2f;
        SetPercentAngle01(adjustPercent);
    }

    private float NormalizedPercent(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }

    private void RefreshPosition()
    {
        m_angle = Mathf.Clamp(m_angle, m_minAngle, m_maxAngle);
        float applyAngle = m_angle = m_inversValue ? -m_angle : m_angle;
        m_whatToRotate.localRotation = Quaternion.Euler(m_rotationAxis*( m_angleAdjustment + applyAngle));
    }
}