using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera cam;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Anomaly anomaly = hit.collider.GetComponent<Anomaly>();

                if (anomaly != null && anomaly.isActive)
                {
                    anomaly.Deactivate();
                    GameManager.Instance.Report(true);
                }
                else
                {
                    GameManager.Instance.Report(false);
                }
            }
        }
    }
}