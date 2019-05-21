using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    void Start()
    {
        Texture2D texture = new Texture2D(4096, 4096);
        GetComponent<Renderer>().material.mainTexture = texture;

        for (int y = 0; y < texture.height; y++)
        {
            for (int x = 0; x < texture.width; x++)
            {
                double c_re = (x - texture.width / 2.0) * 4.0 / texture.width;
                double c_im = (y - texture.height / 2.0) * 4.0 / texture.width;
                double x1 = 0, y1 = 0;
                int iteration = 0;
                while (x1 * x1 + y1 * y1 <= 4 && iteration < 1000)
                {
                    double x_new = x1 * x1 - y1 * y1 + c_re;
                    y1 = 2 * x1 * y1 + c_im;
                    x1 = x_new;
                    iteration++;
                }
                if (iteration < 100)
                {
                    texture.SetPixel(x, y, Color.white);
                }
                else
                {
                    texture.SetPixel(x, y, Color.black);
                }
            }
        }
        texture.Apply();
    }
}
