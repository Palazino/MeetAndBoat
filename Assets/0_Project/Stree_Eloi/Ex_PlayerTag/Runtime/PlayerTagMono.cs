using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTagMono : MonoBehaviour
{
    static PlayerTagMono m_playerInScene;
    static Action m_onNewPlayer;
    public static PlayerTagMono GetPlayer() { return m_playerInScene; }
    public static bool IsPlayerInScene() { return m_playerInScene != null; }
    public static Vector3 GetPlayerPosition() {
        return m_playerInScene.transform.position; }
    public static Quaternion GetPlayerRotation() {
        return m_playerInScene.transform.rotation; 
    }

    public static void StartListeningToNewPlayer(Action listener)
    {
        m_onNewPlayer += listener;
    }
    public static void StopListeningToNewPlayer(Action listener)
    {
        m_onNewPlayer -= listener;
    }

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

