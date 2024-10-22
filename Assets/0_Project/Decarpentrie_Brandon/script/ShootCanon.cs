using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootCanon : MonoBehaviour
{
    [SerializeField] GameObject projectilePrefab;
    [SerializeField] Transform shootPoint;
    [SerializeField] float shootForce = 10f;
    [SerializeField] float curveAmount = 2f;



    [SerializeField] float projectilSize = 0.05f;
    public void ShootProjectile()
    {
        
            GameObject projectile = Instantiate(projectilePrefab, shootPoint.position, shootPoint.rotation);

            Rigidbody rb = projectile.GetComponent<Rigidbody>();
            rb.velocity = shootPoint.forward * shootForce;
            Vector3 curveForce = Vector3.up * curveAmount;
            rb.AddForce(curveForce, ForceMode.Acceleration);

            
            rb.useGravity = true;
            projectile.transform.localScale = Vector3.one * projectilSize;
    }

}
