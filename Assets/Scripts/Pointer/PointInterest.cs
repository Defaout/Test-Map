using System.Collections.Generic;
using UnityEngine;

public class PointInterest : MonoBehaviour
{
    [SerializeField] private List<Point> _pointList;
    [SerializeField] private MoveIdeoLocator _locator;
    public void SetPoint(int index)
    {
        _locator.AssignPoint(_pointList[index]);
    }
    public List<Point> Points=> _pointList;
}
