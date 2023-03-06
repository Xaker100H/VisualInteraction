using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            transform.Translate(Vector3.right * speed * Time.deltaTime, Space.World);
            //transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime, Space.World);
            //transform.eulerAngles = new Vector3(0, 180, 0);
        }
    }

    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "obstaculo")
        {
            print("Game Over");
            Destroy(this.gameObject);
        }

        if (col.gameObject.tag == "meta")
        {
            
            print("You Win!");
            Destroy(this.gameObject);
        }
    }
}
