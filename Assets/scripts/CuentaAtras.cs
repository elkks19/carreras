using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CuentaAtras : MonoBehaviour
{
    public GameObject motorCarrerasGO;
    public MotorCarreras motorCarrerasScript;
    public Sprite[] numeros; // Asigna los sprites: 3, 2, 1, "Go" en el Inspector

    public GameObject contadorNumerosGO;
    public SpriteRenderer contadorNumerosComp;

    public GameObject controladorCocheGO;
    public GameObject cocheGO;

    void InicioComponentes()
    {
        // Asignar los objetos necesarios desde la escena
        motorCarrerasGO = GameObject.Find("MotorCarreras");
        motorCarrerasScript = motorCarrerasGO.GetComponent<MotorCarreras>();

        contadorNumerosGO = GameObject.Find("CuentaNumeros");
        contadorNumerosComp = contadorNumerosGO.GetComponent<SpriteRenderer>();

        cocheGO = GameObject.Find("Coche");
        controladorCocheGO = GameObject.Find("ControladorCoche");

        InicioCuentaAtras(); // Iniciar cuenta atrás
    }

    void InicioCuentaAtras()
    {
        StartCoroutine(Contando()); // Llamada a la corrutina para iniciar la cuenta regresiva
    }

    IEnumerator Contando()
{
    // Sonido de inicio (si tienes algún sonido antes de la cuenta atrás)
    controladorCocheGO.GetComponent<AudioSource>().Play();
    yield return new WaitForSeconds(1); // Esperamos 1 segundo antes de mostrar el primer número

    // Mostrar 3
    contadorNumerosComp.sprite = numeros[0]; // Sprite para "3"
    this.gameObject.GetComponent<AudioSource>().Play(); // Sonido al mostrar "3"
    yield return new WaitForSeconds(1); // Espera 1 segundo

    // Mostrar 2
    contadorNumerosComp.sprite = numeros[1]; // Sprite para "2"
    this.gameObject.GetComponent<AudioSource>().Play(); // Sonido al mostrar "2"
    yield return new WaitForSeconds(1); // Espera 1 segundo

    // Mostrar 1
    contadorNumerosComp.sprite = numeros[2]; // Sprite para "1"
    this.gameObject.GetComponent<AudioSource>().Play(); // Sonido al mostrar "1"
    yield return new WaitForSeconds(1); // Espera 1 segundo

    // Mostrar "Go"
    contadorNumerosComp.sprite = numeros[3]; // Sprite para "Go"
    contadorNumerosGO.GetComponent<AudioSource>().Play(); // Sonido al mostrar "Go"
    yield return new WaitForSeconds(1); // Espera 1 segundo más

    // Ocultar el contador
    contadorNumerosGO.SetActive(false); 

    // Iniciar el juego (permitir que el coche avance)
    motorCarrerasScript.inicioJuego = true;

    // Sonido del coche comenzando
    cocheGO.GetComponent<AudioSource>().Play();
}


    // Start is called before the first frame update
    void Start()
    {
        InicioComponentes(); // Inicia los componentes y la cuenta atrás
    }

    // Update is called once per frame
    void Update()
    {
        // El coche solo se moverá si la cuenta atrás ha terminado (inicioJuego = true)
    }
}