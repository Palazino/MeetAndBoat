using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class ShootInput : MonoBehaviour
{
    public InputActionReference m_whatToListenForShoot; // Référence à l'InputAction
    public UnityEvent<bool> m_onShoot; // L'événement Unity qui sera déclenché

    private void OnEnable()
    {
        // On s'assure que l'InputAction soit activée
        m_whatToListenForShoot.action.Enable();
        // On s'abonne à l'événement performed (quand l'input est déclenché)
        m_whatToListenForShoot.action.performed += OnShootPerformed;
        // On s'abonne à l'événement canceled (quand l'input est relâché)
        m_whatToListenForShoot.action.canceled += OnShootCanceled;
    }

    private void OnDisable()
    {
        // On désactive les événements pour éviter des erreurs
        m_whatToListenForShoot.action.performed -= OnShootPerformed;
        m_whatToListenForShoot.action.canceled -= OnShootCanceled;
        m_whatToListenForShoot.action.Disable();
    }

    // Méthode appelée quand l'input est déclenché
    private void OnShootPerformed(InputAction.CallbackContext context)
    {
        m_onShoot.Invoke(true); // On invoque l'événement avec "true" pour signaler le tir
    }

    // Méthode appelée quand l'input est relâché
    private void OnShootCanceled(InputAction.CallbackContext context)
    {
        m_onShoot.Invoke(false); // On invoque l'événement avec "false" pour signaler l'arrêt du tir
    }
}
