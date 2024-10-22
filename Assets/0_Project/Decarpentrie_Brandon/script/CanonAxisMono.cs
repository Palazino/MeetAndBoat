using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanonAxisVMono : MonoBehaviour
{

    public float m_angleAdjustment=90f;
    public float m_angleX = -5;
    public float m_angleY = 90;
    public float m_minAngleX=-180;
    public float m_maxAngleX=180;
    public float m_minAngleY=-180;
    public float m_maxAngleY=180;
    public Vector3 m_rotationAxis = Vector3.up;
    public Transform m_whatToRotate;
    public bool m_inversValueX=true;

    private void OnValidate()
    {
        RefreshPosition();
    }


    void Update()
    {

        RefreshPosition();
    }

    public void SetAngleX(float angle) {
        m_angleX=angle;
    }
    public void SetAngleY(float angle) {
        m_angleY=angle;
    }

    public void SetPercentAngleX(float percent)
    {
        m_angleX = Mathf.Lerp(m_minAngleX, m_maxAngleX, percent);
    }
    public void SetPercentAngle11(float percent)
    {
        float normalizedPercent = Mathf.Clamp01(percent);
        float targetAngle = Mathf.Lerp(m_minAngleY, m_maxAngleY, normalizedPercent);
        targetAngle = NormalizedPercent(targetAngle);
        m_angleY = targetAngle;
    }

    private float NormalizedPercent(float angle)
    {
        while (angle > 180f) angle -= 360f;
        while (angle < -180f) angle += 360f;
        return angle;
    }

    private void RefreshPosition()
    {
        m_angleX = Mathf.Clamp(m_angleX, m_minAngleX, m_maxAngleX);
        m_angleY = Mathf.Clamp(m_angleY, m_minAngleY, m_maxAngleY);
        float applyAngleX = m_angleX;
        float applyAngleY = m_angleY;
        if (m_inversValueX)
            applyAngleX *= -1;
        m_whatToRotate.rotation = Quaternion.Euler(applyAngleX + m_angleAdjustment, applyAngleY,0);
    }
}
