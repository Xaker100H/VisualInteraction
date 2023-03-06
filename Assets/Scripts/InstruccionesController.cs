using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstruccionesController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Instrucciones");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Instrucciones()
    {
        yield return new WaitForSeconds(5f);
        Destroy(this.gameObject);
    }
}
