using UnityEngine;

[System.Serializable]
public class Stage
{
    [SerializeField] private string name;
    
    [SerializeField] private Vector3 rotation;
    public Vector3 Rotation => rotation;
    
    [SerializeField] private Mode mode;
    public Mode Mode => mode;
}