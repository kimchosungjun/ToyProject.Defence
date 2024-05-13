using UnityEngine;

[CreateAssetMenu(fileName ="TowerData",menuName = "ScriptableObject/TowerData", order =0)]
public class ScriptableTower : ScriptableObject
{
    public GameObject towerObject; // Ÿ�� ������
    public int damagePoint; // ������ ������ ������
    public ArrowType arrowType; // ȭ���� ����
    public float decreaseValue; // �̵��ӵ� ��������
    public float debuffTime; // ����� �ð�
    public float attackCoolTime; // ���� ������ �ϱ� ���� �ð� 

    public int buildMoney; // ���µ� �ʿ��� ��
    public int sellMoney; // Ÿ���� �� ��
    public int upgradeMoney; // ���׷��̵��ϴµ� �ʿ��� ��

    public int curUpgradeLevel = 0;
    public int canUpgradeLevel = 1;
    public float decreaseValueUpgrade = 0.2f;
    public float attackCoolTimeUpgrade = 0.5f;
    public int upgradeDamage = 1;
}
