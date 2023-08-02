using EventBus.Game.GamePlay.Area;

public sealed class AttackController
{
    public void Attack(Character source, Character target)
    {
        target.TakeDamage(source.GetDamage());
    }
}