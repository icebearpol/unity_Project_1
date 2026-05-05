using UnityEngine;

public class MoveObject : Anomaly
{
    Vector3 originalPos;

    void Start()
    {
        originalPos = transform.position;
    }

    public override void Activate()
    {
        base.Activate();
        transform.position += new Vector3(0.5f, 0, 0);
    }

    public override void Deactivate()
    {
        base.Deactivate();
        transform.position = originalPos;
    }
}