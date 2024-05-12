using UnityEngine;

[CreateAssetMenu(fileName ="TowerData",menuName = "ScriptableObject/TowerData", order =0)]
public class ScriptableTower : ScriptableObject
{
    public GameObject towerObject; // Ÿ�� ������
    public int damagePoint; // ������ ������ ������
    public ArrowType arrowType; // ȭ���� ����
    public int decreaseValue; // �̵��ӵ� ���ҽð�
    public float debuffTime; // ����� �ð�
    public float attackCoolTime; // ���� ������ �ϱ� ���� �ð� 

    public int buildMoney; // ���µ� �ʿ��� ��
    public int sellMoney; // Ÿ���� �� ��
    public int upgradeMoney; // ���׷��̵��ϴµ� �ʿ��� ��
}
