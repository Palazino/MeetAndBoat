using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "Shoot";
    public ParticleSystem particleSystem; // R�f�rence au syst�me de particules
    public float particleDuration = 1f; // Dur�e pendant laquelle les particules restent actives

    // M�thode pour activer le tir
    [ContextMenu("Shoot")]
    public void Shoot()
    {
        // D�clenche l'animation
        animator.SetTrigger(triggerName);

        // Active le syst�me de particules
        if (particleSystem != null)
        {
            particleSystem.Play(); // D�marre le syst�me de particules
            StartCoroutine(StopParticlesAfterDelay(particleDuration)); // D�marre la coroutine pour arr�ter les particules
        }
        else
        {
            Debug.LogWarning("Aucun syst�me de particules assign� !");
        }
    }

    // Coroutine pour arr�ter les particules apr�s un certain d�lai
    private IEnumerator StopParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Attend le d�lai sp�cifi�
        if (particleSystem != null)
        {
            particleSystem.Stop(); // Arr�te le syst�me de particules
        }
    }

    // Optionnel : M�thode pour r�initialiser les particules si n�cessaire
    private void OnEnable()
    {
        if (particleSystem != null)
        {
            particleSystem.Stop(); // Arr�te le syst�me de particules au d�part
        }
    }
}
