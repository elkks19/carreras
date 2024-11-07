using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotorCarreras : MonoBehaviour
{
    public GameObject contenedorCallesGO;
    public GameObject[] contenedorCallesArray;
    public float velocidad;
    public bool inicioJuego;
    public bool juegoTerminado;
    int contadorCalles = 0;
    int numeroSelectorCalles;
    public GameObject calleAnterior;
    public GameObject calleNueva;
    public float tamanoCalle;
    public Vector3 medidaLimitePantalla;
    public bool salioDePantalla;
    public GameObject mCamGo;
    public Camera mCamComp;

    public GameObject cocheGO;
    public GameObject audioFX;
    public AudioFX audioFXScript;
    public GameObject bgFinalGO;
   
    void Start()
    {
        InicioJuego();
    }

    void InicioJuego()
    {
        contenedorCallesGO = GameObject.Find("ContenedorCalles");
        mCamGo = GameObject.Find("MainCamera");
        mCamComp = mCamGo.GetComponent<Camera>();
        VelocidadMotorCarretera();
        MedirPantalla();
        BuscoCalles();
        
        bgFinalGO = GameObject.Find("PanelGameOver");
        bgFinalGO.SetActive(false);

        audioFX = GameObject.Find("AudioFX");
        audioFXScript = audioFX.GetComponent<AudioFX>();

        cocheGO = GameObject.FindObjectOfType<Coche>().gameObject;
    }
    public void JuegoTerminadoEstados() {
        bgFinalGO.SetActive(true);
        cocheGO.GetComponent<AudioSource>().Stop();
        audioFXScript.FXMusic();
    }
    void PosicionoCalles(){
        calleAnterior = GameObject.Find("calle"+(contadorCalles-1));
        calleNueva = GameObject.Find("calle"+contadorCalles);
        MidoCalle();
        calleNueva.transform.position = new Vector3(calleAnterior.transform.position.x,
        calleAnterior.transform.position.y + tamanoCalle, -0.5f);
        salioDePantalla = false;
    }

    void CrearCalles(){
        contadorCalles++;
        numeroSelectorCalles = Random.Range(0,contenedorCallesArray.Length);
        GameObject Calle = Instantiate(contenedorCallesArray[numeroSelectorCalles]);
        Calle.SetActive(true);
        Calle.name = "calle"+contadorCalles;
        Calle.transform.parent = gameObject.transform;
        PosicionoCalles();
    }


    void BuscoCalles(){
        contenedorCallesArray = GameObject.FindGameObjectsWithTag("calle");
        for(int i=0; i<contenedorCallesArray.Length; i++){
            contenedorCallesArray[i].gameObject.transform.parent = contenedorCallesGO.transform;

            contenedorCallesArray[i].gameObject.SetActive(false);
            contenedorCallesArray[i].gameObject.name = "calleOFF_"+i;
        }
        CrearCalles();
    }
    void MidoCalle(){
        for(int i=0; i< calleAnterior.transform.childCount; i++){
            if(calleAnterior.transform.GetChild(i).gameObject.GetComponent<pieza>() != null)
            {
                float tamanoPieza = calleAnterior.transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().bounds.size.y;
                tamanoCalle = tamanoCalle + tamanoPieza;
            }
    }
    }
    void VelocidadMotorCarretera()
    {
        velocidad = 10; 

    }
    void MedirPantalla(){
        medidaLimitePantalla = new Vector3(0,mCamComp.ScreenToWorldPoint(new Vector3(0,0,0)).y - 0.5f,0);
    }
    void Update()
    {
        if(inicioJuego==true && juegoTerminado==false){
             transform.Translate(Vector3.down * velocidad * Time.deltaTime);
        }
        if(calleAnterior.transform.position.y + tamanoCalle <medidaLimitePantalla.y && salioDePantalla == false) 
        {
            salioDePantalla = true;
            DestruyoCalle();
        }
    }
    void DestruyoCalle()
    {
        Destroy(calleAnterior);
        tamanoCalle = 0;
        calleAnterior = null;
        CrearCalles(); 
    
    }
}