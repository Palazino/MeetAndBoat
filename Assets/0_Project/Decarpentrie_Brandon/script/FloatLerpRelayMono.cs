using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloatLerpRelayMono : MonoBehaviour
{
    public float m_currentValue;
    public float m_wantedValue;
    public UnityEvent<float> m_onRelayed;
    public float m_lerpMultiplicator=2;
 
    void Update()
    {
        m_currentValue = Mathf.Lerp(m_currentValue, m_wantedValue, Time.deltaTime* m_lerpMultiplicator);
        m_onRelayed.Invoke(m_currentValue);
    }

    public void SetWantedValue(float wantedValue) { m_wantedValue = wantedValue; }
}
