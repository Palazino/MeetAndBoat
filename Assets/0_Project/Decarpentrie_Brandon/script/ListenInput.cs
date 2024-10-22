using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class ListenInput : MonoBehaviour
{

    public InputActionReference m_whatToListenForYAxis;
    public InputActionReference m_whatToListenForXAxis;
    public UnityEvent<float> m_onAxisYChanged;
    public UnityEvent<float> m_onAxisXChanged;
    public float m_currentValueX;
    public float m_currentValueY;


    void NotifyYchanged(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value != m_currentValueY)
        {
            m_currentValueY = value;
            m_onAxisYChanged.Invoke(m_currentValueY);
        }
    }
    void NotifyXchanged(InputAction.CallbackContext context)
    {
        float value = context.ReadValue<float>();
        if (value != m_currentValueX)
        {
            m_currentValueX = value;
            m_onAxisYChanged.Invoke(m_currentValueX);
        }
    }
    private void OnEnable()
    {
        m_whatToListenForXAxis.action.Enable();
        m_whatToListenForXAxis.action.performed += NotifyXchanged;
        m_whatToListenForXAxis.action.canceled += NotifyXchanged;

        m_whatToListenForYAxis.action.Enable();
        m_whatToListenForYAxis.action.performed += NotifyYchanged;
        m_whatToListenForYAxis.action.canceled += NotifyYchanged;
    }

    private void OnDisable()
    {
        m_whatToListenForXAxis.action.performed -= NotifyXchanged;
        m_whatToListenForXAxis.action.canceled -= NotifyXchanged;

        m_whatToListenForYAxis.action.performed -= NotifyYchanged;
        m_whatToListenForYAxis.action.canceled -= NotifyYchanged;
    }
}
