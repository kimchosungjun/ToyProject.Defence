using UnityEngine;

[CreateAssetMenu(fileName ="StageData",menuName ="ScriptableObject/StageData")]
public class ScriptableStage : ScriptableObject
{
    public int startHp;
    public int startMoney;
    public float stageTime;
}
