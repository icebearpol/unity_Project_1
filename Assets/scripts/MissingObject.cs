using UnityEngine;

public class MissingObject : Anomaly
{
    Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    public override void Activate()
    {
        base.Activate();
        rend.enabled = false; 
    }

    public override void Deactivate()
    {
        base.Deactivate();
        rend.enabled = true; 
    }
}