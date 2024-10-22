using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ATTENTION// 
// MAKE SURE THE ENNEMY HAS A TAG "Ennemy" !

public class Detectenemy : MonoBehaviour
{
    public string EnnemyTag = "Ennemy"; 

    void OnCollisionEnter(Collision collision)
    {
        
        if (collision.gameObject.CompareTag(EnnemyTag))
        {
            Destroy(gameObject); 
        }
    }
}
