using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoSomethingMono : MonoBehaviour
{

    public Transform m_player;

    public void SetPlayerToTarget(Transform player) { 
      m_player = player;
    }

}
