using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTagMono : MonoBehaviour
{
    static PlayerTagMono m_playerInScene;
    public static Action m_onNewPlayer;
    public static PlayerTagMono GetPlayer() { return m_playerInScene; }
    private void OnEnable()
    {
        m_playerInScene = this;
        if(m_onNewPlayer != null)
            m_onNewPlayer.Invoke();
    }
    private void OnDisable()
    {
        if(m_playerInScene == this)
        m_playerInScene = null;
    }
}

