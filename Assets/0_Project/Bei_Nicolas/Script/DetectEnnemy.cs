using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


// ATTENTION// 
// MAKE SURE THE ENNEMY HAS A TAG "Ennemy" !

public class DetectEnemy : MonoBehaviour
{
    [SerializeField] string enemyTag = "Enemy";
    public UnityEvent onCollision;

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag(enemyTag))
        {
            onCollision.Invoke();
        }
    }
}
