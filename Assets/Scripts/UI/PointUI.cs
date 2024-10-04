using System;
using TMPro;
using UnityEngine;

public class PointUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _name;
    [SerializeField] private int _index;

    public static event Action<int> GoPoint;
    public void SetPoint(Point point,int index)
    {
        _name.text = point.Name;
        _index = index;
    }
    public void GoToPoint()
    {
        GoPoint?.Invoke(_index);
    }
}
