using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour
{
    public Animator animator;
    public string triggername = "Shoot";


    [ContextMenu("Shoot")]
    public void Shoot() { 
    
        animator.SetTrigger(triggername);
    }
    //void Update()
    //{
    //    if (Input.GetKeyDown(KeyCode.UpArrow))
    //    {
    //        animator.SetTrigger(triggername);
    //    }

    //}
}
