using System;
using TMPro;
using UnityEngine;

public class Multimeter : MonoBehaviour, IMultimeter
{
    [SerializeField] private CursorController _cursor;
    [SerializeField] private TMP_Text _display;
    
    private string _displayValue;

    //TODO: По ТЗ хардкод
    private float _power = 400;
    private float _resistance = 1000;
    
    public event Action<Mode, string> ValueChanged;
    
    private void Awake()
    {
        _cursor.ModeChanged += SwitchMode;
    }

    private void OnDestroy()
    {
        _cursor.ModeChanged -= SwitchMode;
    }

    public void Init()
    {
        SwitchMode(Mode.NONE);
    }

    private void SwitchMode(Mode mode)
    {
        float value;
        
        switch (mode)
        {
            case Mode.NONE:
                _displayValue = "0";
                break;
            case Mode.VOLTAGE_AC:
                value  = 0.01f;
                _displayValue = value.ToString("F2");
                break;
            case Mode.VOLTAGE_DC:
                value = Mathf.Sqrt(_power * _resistance);
                _displayValue = value.ToString("F2");
                break;
            case Mode.RESISTANCE:
                _displayValue = $"{_resistance}";
                break;
            case Mode.AMPERAGE:
                value = Mathf.Sqrt(_power / _resistance);
                _displayValue = value.ToString("F2");
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        _display.text = _displayValue;
        ValueChanged?.Invoke(mode, _displayValue);
    }
}