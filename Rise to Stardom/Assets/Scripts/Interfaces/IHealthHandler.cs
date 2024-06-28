public interface IHealthHandler
{
    float Health { get; }
    void TakeDamage(float damage);
}