using System.Collections.Generic;
using UnityEngine;

public class InfoPointSelection : MonoBehaviour
{
    [SerializeField] private GameObject _pointSelection;
    [SerializeField] private GameObject _runButton;
    [SerializeField] private PointInterest _pointInterest;
    [SerializeField] private List<GameObject> _pointsUI;
    [SerializeField] private GameObject _spawnPositionPoint;
    [SerializeField] private GameObject _pointUI;
    private void OnEnable()
    {
        PointUI.GoPoint += SetPoint;
        MoveIdeoLocator.InPosition += OffRunButton;
    }
    private void OnDisable()
    {
        PointUI.GoPoint -= SetPoint;
        MoveIdeoLocator.InPosition -= OffRunButton;
    }
    public void OpenPointSelection()
    {
        if (_pointsUI.Count< _pointInterest.Points.Count)
        {
            AddPointInUI();
        }
        _pointSelection.SetActive(true);
    }
    private void OffRunButton()
    {
        _runButton.SetActive(false);
    }
    private void SetPoint(int index)
    {
        _pointInterest.SetPoint(index);
        _pointSelection.SetActive(false);
        _runButton.SetActive(true);
    }
    private void AddPointInUI()
    {
        for(int indexPoint = 0; indexPoint < _pointInterest.Points.Count; indexPoint++)
        {
            if (indexPoint >= _pointsUI.Count)
            {
               GameObject newPointUI= Instantiate(_pointUI, _spawnPositionPoint.transform);
                newPointUI.SetActive(true);
                _pointsUI.Add(newPointUI);
                newPointUI.GetComponent<PointUI>().SetPoint(_pointInterest.Points[indexPoint], indexPoint);
                
            }
            else
            {
                _pointsUI[indexPoint].GetComponent<PointUI>().SetPoint(_pointInterest.Points[indexPoint], indexPoint);
            }
        }

    }
}
