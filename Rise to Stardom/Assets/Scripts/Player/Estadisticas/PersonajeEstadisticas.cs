using UnityEngine;

public class PersonajeEstadisticas : MonoBehaviour
{
    public Estadisticas vidaMaxima; 
    public int vidaActual {  get; private set; }
    public Estadisticas dmg;
    public Estadisticas velMov;
    public Estadisticas velAtq;
    public Estadisticas velProy;
    public Estadisticas tamProy;

    private void Awake()
    {
        vidaActual = vidaMaxima.GetValor();
    }
    public void RecibirDmg(int dmgSufrido)
    {
        vidaActual -= dmgSufrido;
        Debug.Log(transform.name + "Recibio: " + dmgSufrido + " puntos de daño");
        if(vidaActual <= 0)
        {
            Muerte();
        }
    }

    public virtual void Muerte()
    {
        //Poner animación de muerte.
        Debug.Log(transform.name + " murio.");
    }
}
