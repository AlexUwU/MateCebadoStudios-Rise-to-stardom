using UnityEngine;

public class HeadbangerAttackBehaviour : IAttackBehaviour
{
    public void Attack(Enemy enemy,Transform target)
    {
        enemy.Move((target.position-enemy.transform.position).normalized);
    }
}
