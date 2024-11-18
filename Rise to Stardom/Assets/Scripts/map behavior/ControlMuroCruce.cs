using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlMuroCruce : MonoBehaviour
{   
    [SerializeField] GameObject muroActivo;
    [SerializeField] GameObject muroPasivo;
    [SerializeField] GameObject triggerPasivo;


    private bool muroActivado;

    // Start is called before the first frame update
    void Start()
    {
        muroActivado = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider target){
        if(target.gameObject.tag == "Player" && !muroActivado){
            muroActivo.SetActive(true);
            muroPasivo.SetActive(false);
            triggerPasivo.SetActive(false);
        }
    }

    public void jugadorFuera(){
        muroActivo.SetActive(false);
        triggerPasivo.SetActive(true);
        muroActivado = false;
    }
}
