using UnityEngine;

[CreateAssetMenu(fileName ="EnemyData",menuName ="ScriptableObject/EnemyData", order = int.MaxValue)]
public class ScriptableEnemy : ScriptableObject
{
    [Range(0f,20f)]public float moveSpeed; // �̵��ӵ�
    public int healthPoint; // ü��
    public int damagePoint; // ���ݷ�
    public int rewardMoney; // óġ �� ��� ��
}
