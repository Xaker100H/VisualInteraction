using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextoLvl2Controller : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("Level2");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Level2()
    {
        yield return new WaitForSeconds(3f);
        Destroy(this.gameObject);
    }
}
