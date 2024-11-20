using UnityEngine;
[CreateAssetMenu(fileName = "New WeaponInstrument", menuName = "Inventory/Weapon")]
public class WeaponInstrument : ScriptableObject, IItem
{
    public string instrumentName;
    public GameObject bulletNotePrefab;
    public FireMode fireMode;
    public InstrumentAbilityBase instrumentAbiltity;
    public GameObject droppedWeaponPrefab;
    public AudioClip[] sounds;

    public string ItemName => instrumentName;

    public void Use(Transform firePoint, Vector3 targetPosition, float damage, float bulletSpeed)
    {
        GameObject bulletNote = GameObject.Instantiate(bulletNotePrefab, firePoint.position, Quaternion.identity);
        Vector3 direction = (targetPosition - firePoint.position).normalized;
        bulletNote.GetComponent<Rigidbody>().velocity = direction * bulletSpeed;

        BaseProjectile bulletNoteComponent = bulletNote.GetComponent<BaseProjectile>();
        bulletNoteComponent.damage = damage;

        Sound(firePoint);
    }
    public void Use() { }

    public void Sound(Transform transform)
    {
        SoundFXManager.Instance.PlayRandomSoundFXClip(sounds, transform, 1f);
    }

    public void Drop(Vector3 dropPosition)
    {
        GameObject.Instantiate(droppedWeaponPrefab, dropPosition, Quaternion.identity);
    }
}
