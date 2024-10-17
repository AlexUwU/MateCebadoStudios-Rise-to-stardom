using UnityEngine;
using UnityEngine.SceneManagement;

public class PersonajeEstadisticas : MonoBehaviour
{
    public HUD hud;

    public Estadisticas vidaMaxima; 
    public float vidaActual {  get; private set; }
    public Estadisticas dmg;
    public Estadisticas velMov;
    public Estadisticas velAtq;
    public Estadisticas velProy;
    public Estadisticas tamProy;
    public float totalDamage = 0;

    private void Awake()
    {
        vidaActual = vidaMaxima.GetValor();
    }
    public void RecibirDmg(float dmgSufrido)
    {
        vidaActual -= dmgSufrido;
        Debug.Log(transform.name + "Recibio: " + dmgSufrido + " puntos de daño");
        totalDamage += dmgSufrido;
        Debug.Log(vidaActual);
        if (totalDamage <= vidaMaxima.GetValor())
        {
            hud.DisabledLives(hud.cantLives);
            hud.cantLives--;
        }
        if(vidaActual <= 0)
        {
            Muerte();
        }
    }

    public void Curar()
    {
        vidaActual += 20;
        hud.cantLives++;
        if (vidaActual > vidaMaxima.GetValor())
        {
            vidaActual = 100;
        }
    }

    public virtual void Muerte()
    {
        SceneManager.LoadScene(2);
        //Poner animación de muerte.
        Debug.Log(transform.name + " murio.");
        Destroy(gameObject);
    }
}
