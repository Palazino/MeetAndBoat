using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColisionDestruct : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
            Destroy(gameObject);
    }
}
