using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using OpenCvSharp;

public class faceDetector : MonoBehaviour
{
    public static WebCamTexture _webCamTexture;
    CascadeClassifier cascade;
    OpenCvSharp.Rect myFace;
    public float faceX;

    public static bool inicializado=false;

    void Start()
    {
            WebCamDevice[] devices = WebCamTexture.devices;
            faceDetector._webCamTexture = new WebCamTexture(devices[0].name);
            faceDetector._webCamTexture.Play();
            cascade = new CascadeClassifier(Application.streamingAssetsPath + @"/haarcascade_frontalface_default.xml");
            faceDetector.inicializado=true;

    }

    void Awake()
    {
        
        Debug.Log("awake con inicializado siendo "+faceDetector.inicializado);
        if (faceDetector.inicializado) {
            // ya existe otro anterior
            // yo no soy necesario
            // me eliminio
            Destroy(this.gameObject);
        } else {
            // soy el primero
            DontDestroyOnLoad(gameObject);
        }
        
    }


    void Update()
    {
        if (faceDetector.inicializado){
        faceDetector._webCamTexture.Play(); }
        //GetComponent<Renderer>().material.mainTexture = _webCamTexture;
        Mat frame = OpenCvSharp.Unity.TextureToMat(faceDetector._webCamTexture);
        findNewFaces(frame);
        display(frame);
    }
    void findNewFaces(Mat frame)
    {
        var faces = cascade.DetectMultiScale(frame, 3, 3, HaarDetectionType.ScaleImage);

        if (faces.Length >= 1)
        {
            //Debug.Log(faces[0].Location);
            myFace = faces[0];
            faceX = faces[0].X;
        }
    }
    void display(Mat frame)
    {
        if (myFace != null)
        {
            frame.Rectangle(myFace, new Scalar(250, 0, 0), 2);

        }
        Texture newtexture = OpenCvSharp.Unity.MatToTexture(frame);
        GetComponent<Renderer>().material.mainTexture = newtexture;
    }
}
