using UnityEngine;

[CreateAssetMenu(fileName = "Objeto nuevo", menuName = "Inventario/Objeto")]
public class Objeto : ScriptableObject
{
    new public string name = "Objeto nuevo";
    public Sprite icono = null;
    public bool isConsumableItem = false;
    public bool isInstrumentItem = false;
}
