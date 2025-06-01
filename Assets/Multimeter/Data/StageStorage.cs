using UnityEngine;

[CreateAssetMenu(fileName = "StageStorage", menuName = "Storage/Stage", order = 0)]
public class StageStorage : ScriptableObject
{
    [SerializeField] private Stage[] stages;
    
    public int GetStageCount() => stages.Length;
    
    public Stage GetStageByIndex(int index) => stages[index];
}