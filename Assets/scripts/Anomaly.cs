using UnityEngine;

public class Anomaly : MonoBehaviour
{
    public bool isCorrect = true;
    public bool isActive = false; 

    public virtual void Activate()
    {
        isActive = true;
    }

    public virtual void Deactivate()
    {
        isActive = false;
    }
}