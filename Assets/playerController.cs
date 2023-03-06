using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class playerController : MonoBehaviour
{
    faceDetector faceDetector;
    //public float speed = 0.2f;
    float lastX = 0;
    // Start is called before the first frame update
    void Start()
    {
        faceDetector = (faceDetector)FindObjectOfType(typeof(faceDetector));
    }

    // Update is called once per frame
    void Update()
    {
        // float step = speed * Time.deltaTime;


        float norm = Mathf.Clamp(faceDetector.faceX, -1, 1);
        transform.position = new Vector3(-((faceDetector.faceX - 250f) / 150), transform.position.y, transform.position.z);
    }
    public void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "obstaculo")
        {
            //print("Game Over");
            SceneManager.LoadScene("Menu");
        }

        if (col.gameObject.tag == "meta")
        {

            //print("You Win!");
            SceneManager.LoadScene("SampleScene2");
        }
        if (col.gameObject.tag == "meta2")
        {

            //print("You Win!");
            SceneManager.LoadScene("SampleScene3");
        }
        if (col.gameObject.tag == "meta3")
        {

            //print("You Win!");
            SceneManager.LoadScene("MenuVictoria");
        }
    }
}
