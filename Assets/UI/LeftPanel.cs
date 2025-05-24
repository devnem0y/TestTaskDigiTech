using System;
using TMPro;
using UnityEngine;

public class LeftPanel : MonoBehaviour
{
    [SerializeField] private TMP_Text _lblVoltageAc;
    [SerializeField] private TMP_Text _lblVoltageAd;
    [SerializeField] private TMP_Text _lblResistance;
    [SerializeField] private TMP_Text _lblAmpere;
    
    public void Init(IMultimeter model)
    {
        model.ValueChanged += (mode, value) =>
        {
            _lblVoltageAc.text = "0";
            _lblResistance.text = "0";
            _lblVoltageAd.text = "0";
            _lblAmpere.text = "0";
            
            switch (mode)
            {
                case Mode.VOLTAGE_AC: _lblVoltageAc.text = $"{value}"; break;
                case Mode.VOLTAGE_DC: _lblVoltageAd.text = $"{value}"; break;
                case Mode.RESISTANCE: _lblResistance.text = $"{value}"; break;
                case Mode.AMPERAGE: _lblAmpere.text = $"{value}"; break;
                case Mode.NONE: break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        };
    }
}