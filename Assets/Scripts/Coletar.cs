using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletar : MonoBehaviour
{

    public bool deletar = false;
    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && deletar)
        {
            
            transform.position = new Vector3 (200,100,200);

        }
        Debug.Log(deletar);
    }

    public void OnTriggerStay(Collider other)
    {
        deletar = true;
        Debug.Log("colidiu");
    }

    public void OnTriggerExit(Collider other)
    {
        deletar=false;
    }

}
