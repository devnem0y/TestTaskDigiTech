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
            switch (mode)
            {
                case Mode.NONE:
                    _lblVoltageAc.text = "0";
                    _lblResistance.text = "0";
                    _lblVoltageAd.text = "0";
                    _lblAmpere.text = "0";
                    break;
                case Mode.VOLTAGE_AC:
                    _lblVoltageAc.text = $"{value}";
                    _lblResistance.text = "0";
                    _lblVoltageAd.text = "0";
                    _lblAmpere.text = "0";
                    break;
                case Mode.VOLTAGE_DC:
                    _lblVoltageAc.text = "0";
                    _lblResistance.text = "0";
                    _lblVoltageAd.text = $"{value}";
                    _lblAmpere.text = "0";
                    break;
                case Mode.RESISTANCE:
                    _lblVoltageAc.text = "0";
                    _lblResistance.text = $"{value}";
                    _lblVoltageAd.text = "0";
                    _lblAmpere.text = "0";
                    break;
                case Mode.AMPERAGE:
                    _lblVoltageAc.text = "0";
                    _lblResistance.text = "0";
                    _lblVoltageAd.text = "0";
                    _lblAmpere.text = $"{value}";
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(mode), mode, null);
            }
        };
    }
}