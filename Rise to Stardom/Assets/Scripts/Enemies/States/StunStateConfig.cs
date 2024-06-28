using UnityEngine;

[CreateAssetMenu(menuName = "EnemyStates/StunStateConfig")]
public class StunStateConfig : StateConfig
{
    [SerializeField]private float duration;
    public float Duration { get { return duration; } }
    public override IEnemyState CreateState()
    {
        return new StunState(duration);
    }
}
