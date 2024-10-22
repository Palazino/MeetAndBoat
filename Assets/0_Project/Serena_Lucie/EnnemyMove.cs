using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveMono: MonoBehaviour
{
    public Transform destination;
    public Transform whatToMove;
    public float speed = 2f;
    
 void Update()
    {
        if (destination != null)
        {
            Vector3 direction = (destination.position - whatToMove.position).normalized;
            whatToMove.position += direction * speed * Time.deltaTime;
        }
    }
}
