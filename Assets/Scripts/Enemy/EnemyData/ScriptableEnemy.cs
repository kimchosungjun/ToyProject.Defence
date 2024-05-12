using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData",menuName ="ScriptableObject/EnemyData", order = int.MaxValue)]
public class ScriptableEnemy : ScriptableObject
{
    [Range(0f,20f)]public float moveSpeed; // 이동속도
    public int healthPoint; // 체력
    public int damagePoint; // 공격력
    public int rewardMoney; // 처치 시 얻는 돈
}
