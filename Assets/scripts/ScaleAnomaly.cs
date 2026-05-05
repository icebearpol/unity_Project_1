using UnityEngine;

public class ScaleAnomaly : Anomaly
{
    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public override void Activate()
    {
        base.Activate();
        transform.localScale *= 1.5f;
    }

    public override void Deactivate()
    {
        base.Deactivate();
        transform.localScale = originalScale;
    }
}