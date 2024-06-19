public interface IHealthHandler
{
    int Health { get; }
    void TakeDamage(int damage);
}