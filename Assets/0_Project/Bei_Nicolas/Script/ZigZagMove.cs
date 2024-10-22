using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyZigZagMove : MonoBehaviour
{
    public Transform player; 
    public float moveSpeed = 2f; 
    public float zigzagFrequency = 2f; 
    public float zigzagMagnitude = 1f; 
    private float zigzagTimer = 0f;

   

    void Update()
    {
        if (player != null)
        {
            FOLLOWPLAYER();
        }
    }

    private void FOLLOWPLAYER()
    {
        // MOVE ZIGZAG
        Vector3 direction = (player.position - transform.position).normalized;
        zigzagTimer += Time.deltaTime * zigzagFrequency;
        float zigzagOffset = Mathf.Sin(zigzagTimer) * zigzagMagnitude;
        Vector3 zigzagDirection = new Vector3(direction.x, direction.y, direction.z + zigzagOffset).normalized;
        transform.position += zigzagDirection * moveSpeed * Time.deltaTime;
        transform.LookAt(player);
    }
}
