using UnityEngine;
using UnityEngine.AI;

public class MoveIdeoLocator : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    [SerializeField] private NavMeshPath _path;
    [SerializeField] private LineRenderer  _lineRender ;
    [SerializeField] private Point _point;
    [SerializeField] private int _maxSpeed = 1;
    public delegate void Movment();
    public static Movment InPosition;
    
    public void AssignPoint(Point point)
    {
        _point = point;
        _path = new NavMeshPath();  
        _agent.CalculatePath(_point.GetLocaionPoint(), _path);
        _agent.SetPath(_path);
        _agent.destination=_point.GetLocaionPoint();
    }
    public void Run()
    {
        _agent.speed = _maxSpeed;
    }
    private void SetLine()
    {
        _lineRender.positionCount=_agent.path.corners.Length;
        _lineRender.SetPositions(_agent.path.corners);
    }
    private void RemoveLine()
    {
        _lineRender.SetPositions(null);
    }
    private void Update()
    {
        if(_point!= null)
        {
            SetLine();
            float distantion = Vector3.Distance(_point.GetLocaionPoint(), transform.position);
            if (distantion < 0.5)
            {
                _point = null;
                InPosition?.Invoke();
                StopRun();
            }
        }
    }
    public void StopRun()
    {
        _agent.speed = 0;
    }
}
