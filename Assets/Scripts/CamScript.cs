using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamScript : MonoBehaviour
{
    private Camera camera;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") < 0)
        {
            camera.orthographicSize = Mathf.Min(camera.orthographicSize += 2.5f, 80f);
          //  camera.fieldOfView= Mathf.Min(camera.fieldOfView += 2.5f, 120f);
        }
        else if (Input.GetAxis("Mouse ScrollWheel") > 0)
        {

            camera.orthographicSize =Mathf.Max(camera.orthographicSize -= 2.5f,1f) ;
           // camera.fieldOfView = Mathf.Max(camera.fieldOfView -= 2.5f, 40f);
        }
    }
}
