using UnityEngine;

public class EntryPoint : MonoBehaviour
{
    [SerializeField] private Multimeter _multimeterPrefab;
    [SerializeField] private LeftPanel _widgetPrefab;

    private void Start()
    {
        var multimeter = Instantiate(_multimeterPrefab);
        multimeter.Init();
        
        var widget = Instantiate(_widgetPrefab);
        widget.Init(multimeter);
    }
}