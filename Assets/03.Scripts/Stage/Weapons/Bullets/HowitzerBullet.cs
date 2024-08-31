using Stage;
/// <summary> 적중시 1회만 피해를 주는 곡사투사체 공격 </summary>
public class HowitzerBullet : Bullet
{
    /******* INTERFACE IMPLEMENT *******/
    protected override void SetMoveType()
    {
        BulletMoveType = gameObject.AddComponent<HowitzerMove>();
    }

    protected override void SetStrategies()
    {
        OnAttackEnter = gameObject.AddComponent<DestroyOnEnter>();
    }

    public override void Initiate()
    {
        DestroyOnEnter doe_config = OnAttackEnter as DestroyOnEnter;
        doe_config.Attack = this;
        doe_config.Damage = Damage;
        doe_config.Pierce = Pierce;

        HowitzerMove sbm_config = BulletMoveType as HowitzerMove;
        sbm_config.Force = Speed;
        sbm_config.weaponPosition = AttackInfo.Weapon.transform.position;
    }
}