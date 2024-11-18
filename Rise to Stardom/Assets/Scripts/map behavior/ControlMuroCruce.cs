using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMuroCruce : MonoBehaviour
{   
    [SerializeField] GameObject muroActivo;
    [SerializeField] GameObject muroPasivo;
    [SerializeField] GameObject triggerPasivo;

    [SerializeField] private bool jugDentro;

    private bool muroActivado;

    // Start is called before the first frame update
    void Start()
    {
        jugDentro = false;
        muroActivado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target){
        if(target.gameObject.tag == "Player" && !muroActivado){
            muroActivo.SetActive(true);
            Debug.Log("Muro activado");
            muroPasivo.SetActive(false);
            triggerPasivo.SetActive(false);
        }
    }

    public void jugadorFuera(){
        muroActivo.SetActive(false);
        Debug.Log("Muro apagado");
        triggerPasivo.SetActive(true);
        jugDentro = false;
        muroActivado = false;
    }

    public void jugadorDentro(){
        jugDentro = true;

    }
}
