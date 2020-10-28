using UnityEngine;
using UnityEngine.InputSystem;

public class OnExample : MonoBehaviour
{
    [SerializeField] private InputAction _fireAction;

    private void Start()
    {
        _fireAction.performed += _ => Debug.Log("Fire");
    }
    
    private void OnEnable()
    {
        _fireAction.Enable();
    }

    private void OnDisable()
    {
        _fireAction.Disable();
    }

    private void OnDestroy()
    {
        _fireAction.Dispose();
    }
}