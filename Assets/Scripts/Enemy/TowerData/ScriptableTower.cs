using UnityEngine;

[CreateAssetMenu(fileName ="TowerData",menuName = "ScriptableObject/TowerData", order =0)]
public class ScriptableTower : ScriptableObject
{
    public GameObject towerObject; // 타워 프리팹
    public int damagePoint; // 적에게 입히는 데미지
    public ArrowType arrowType; // 화살의 종류
    public float decreaseValue; // 이동속도 감소정도
    public float debuffTime; // 디버프 시간
    public float attackCoolTime; // 다음 공격을 하기 위한 시간 

    public int buildMoney; // 짓는데 필요한 돈
    public int sellMoney; // 타워를 판 값
    public int upgradeMoney; // 업그레이드하는데 필요한 돈

    public int curUpgradeLevel = 0;
    public int canUpgradeLevel = 1;
    public float decreaseValueUpgrade = 0.2f;
    public float attackCoolTimeUpgrade = 0.5f;
    public int upgradeDamage = 1;
}
