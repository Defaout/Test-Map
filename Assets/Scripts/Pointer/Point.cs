using UnityEngine;

public class Point: MonoBehaviour
{
    [SerializeField] private string _namePoint;
    [SerializeField] private GameObject _pointObject;

    public string Name => _namePoint;
    public Vector3 GetLocaionPoint()
    {
        return _pointObject.transform.position;
    }
}
