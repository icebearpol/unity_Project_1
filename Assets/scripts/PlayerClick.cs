using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerClick : MonoBehaviour
{
    public Camera playerCamera;

    void Update()
    {
        // Use NEW Input System properly
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Vector2 mousePosition = Mouse.current.position.ReadValue();
            Ray ray = playerCamera.ScreenPointToRay(mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f))
            {
                Anomaly anomaly = hit.collider.GetComponent<Anomaly>();

                if (anomaly != null)
                {
                    if (anomaly.isActive)
                    {
                        GameManager.Instance.Report(true);
                        anomaly.Deactivate();
                    }
                    else
                    {
                        GameManager.Instance.Report(false);
                    }
                }
                else
                {
                    GameManager.Instance.Report(false);
                }
            }
            else
            {
                GameManager.Instance.Report(false);
            }
        }
    }
}