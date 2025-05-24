using System;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private Transform _cursor;
    [SerializeField] private float[] _anglesX;
    
    [SerializeField] private MeshRenderer _meshCursor;
    [SerializeField] private MeshRenderer _MeshArrow;
    [SerializeField] private Material[] _materials;

    private bool _isCursorLocked = true;

    private int _currentModeIndex;
    
    public event Action<int> ModeChanged;

    private void Update()
    {
        if (_isCursorLocked) return;
        
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        
        switch (scroll)
        {
            case > 0f:
                _currentModeIndex = (_currentModeIndex + 1) % _anglesX.Length;
                SelectMode();
                break;
            case < 0f:
                _currentModeIndex = (_currentModeIndex - 1 + _anglesX.Length) % _anglesX.Length;
                SelectMode();
                break;
        }
    }

    private void SelectMode()
    {
        _cursor.localRotation = Quaternion.Euler(_anglesX[_currentModeIndex], -90f, -90f);
        ModeChanged?.Invoke(_currentModeIndex);
    }
    
    private void ReplaceMaterial(bool selected)
    {
        _meshCursor.material = selected? _materials[1] : _materials[0];
        _MeshArrow.material = selected? _materials[3] : _materials[2];
    }
    
    private void OnMouseEnter()
    {
        _isCursorLocked = false;
        ReplaceMaterial(true);
    }

    private void OnMouseExit()
    {
        _isCursorLocked = true;
        ReplaceMaterial(false);
    }
}
