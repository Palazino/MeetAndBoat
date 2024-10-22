using UnityEngine;
using UnityEngine.Events;

public class NotifyNewPlayerMono : MonoBehaviour{

    public UnityEvent<Transform> m_onNewPlayer;
    public Transform m_player;
    void OnEnable() {
        PlayerTagMono.StartListeningToNewPlayer(OnNewPlayer);
        OnNewPlayer();
    }
    void OnDisable() {
        PlayerTagMono.StopListeningToNewPlayer(OnNewPlayer);
    }
    private void OnNewPlayer()
    {
        m_player = PlayerTagMono.GetPlayer().transform;
        m_onNewPlayer.Invoke(m_player);
    }
}

