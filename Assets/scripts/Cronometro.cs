using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Cronometro : MonoBehaviour
{
    public GameObject motorCarrerasGO;
    public MotorCarreras motorCarrerasScript;

    
    public float tiempo;
    public float distancia;
    public Text txtTiempo;
    public Text txtDistancia;
    public Text txtDistanciaFinal;

    // Start is called before the first frame update
    void Start()
    {
        motorCarrerasGO = GameObject.Find("MotorCarreras");
        motorCarrerasScript = motorCarrerasGO.GetComponent<MotorCarreras>();
        txtTiempo.text = "0:50";
        txtDistancia.text = "0";
        tiempo = 50;
        
    }

    void CalculoTiempodistancia(){
        distancia += Time.deltaTime * motorCarrerasScript.velocidad;
        txtDistancia.text = ((int)distancia).ToString();

        tiempo -= Time.deltaTime;
        int minutos = (int)tiempo/60;
        int segundos = (int)tiempo%60;

        txtTiempo.text = minutos.ToString()+":"+segundos.ToString().PadLeft(2,'0');
    }
    // Update is called once per frame
    void Update()
    {
        if(motorCarrerasScript.inicioJuego == true && motorCarrerasScript.juegoTerminado == false){
            CalculoTiempodistancia();
        }
        if(tiempo <= 0 && motorCarrerasScript.juegoTerminado == false){
            txtDistanciaFinal.text = ((int)distancia).ToString() + "M";
            motorCarrerasScript.juegoTerminado = true;
            motorCarrerasScript.JuegoTerminadoEstados();
        }
    }
}