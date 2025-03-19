using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class AgentController : MonoBehaviour
{
    public NavMeshAgent agent;
    public Camera mainCamera;
    public InputAction clickAction;

    private void OnEnable() {
        clickAction.Enable();
        clickAction.performed += OnClickPerformed;
    }

    private void OnDisable() {
        clickAction.Disable();
        clickAction.performed -= OnClickPerformed;
    }
    private void OnClickPerformed(InputAction.CallbackContext context) {
        // Make raycast out of click
        Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit)) {
            // Assigns hit as destination
            agent.SetDestination(hit.point);
        }
    }

}
