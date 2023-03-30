using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Atacar : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(TiempoAtaque());       
    }
  /*  void OnEnable()
    {
            El problema con OnEnable, es que ejecuta la sentencia nada más iniciar la escena. Puesto que el script en ese momento está activo.
        Con el Start, no se ejecuta puesto que antes de llegar lanzarlo, la State Machine lo ha desactivado.
    }*/

    IEnumerator TiempoAtaque()
    {
        print("Empieza a cargar el ataque");
        yield return new WaitForSeconds(2f);
        print("Lanzo Ataque!");
        GetComponent<StateMachine>().ChangeState("Retornar");
    }

}
