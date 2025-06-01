using System;
using UnityEngine;

public class CursorController : MonoBehaviour
{
    [SerializeField] private MeshRenderer _meshCursor;
    [SerializeField] private MeshRenderer _MeshArrow;
    [SerializeField] private Material[] _materials;
    [SerializeField] private StageStorage _stageStorage;

    private int _length;
    private bool _isCursorLocked = true;
    private int _currentModeIndex;
    
    public event Action<Mode> ModeChanged;

    private void Awake()
    {
        _length = _stageStorage.GetStageCount();
    }

    private void Update()
    {
        if (_isCursorLocked) return;
        
        var scroll = Input.GetAxis("Mouse ScrollWheel");
        
        switch (scroll)
        {
            case > 0f:
                _currentModeIndex = (_currentModeIndex + 1) % _length;
                SelectMode();
                break;
            case < 0f:
                _currentModeIndex = (_currentModeIndex - 1 + _length) % _length;
                SelectMode();
                break;
        }
    }

    private void SelectMode()
    {
        var stage = _stageStorage.GetStageByIndex(_currentModeIndex);
        
        transform.localRotation = Quaternion.Euler(stage.Rotation);
        ModeChanged?.Invoke(stage.Mode);
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