using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootTrigger : MonoBehaviour
{
    public Animator animator;
    public string triggerName = "Shoot";
    public ParticleSystem particleSystem; // Référence au système de particules
    public float particleDuration = 1f; // Durée pendant laquelle les particules restent actives

    // Méthode pour activer le tir
    [ContextMenu("Shoot")]
    public void Shoot()
    {
        // Déclenche l'animation
        animator.SetTrigger(triggerName);

        // Active le système de particules
        if (particleSystem != null)
        {
            particleSystem.Play(); // Démarre le système de particules
            StartCoroutine(StopParticlesAfterDelay(particleDuration)); // Démarre la coroutine pour arrêter les particules
        }
        else
        {
            Debug.LogWarning("Aucun système de particules assigné !");
        }
    }

    // Coroutine pour arrêter les particules après un certain délai
    private IEnumerator StopParticlesAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay); // Attend le délai spécifié
        if (particleSystem != null)
        {
            particleSystem.Stop(); // Arrête le système de particules
        }
    }

    // Optionnel : Méthode pour réinitialiser les particules si nécessaire
    private void OnEnable()
    {
        if (particleSystem != null)
        {
            particleSystem.Stop(); // Arrête le système de particules au départ
        }
    }
}
