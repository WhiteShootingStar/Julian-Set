using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Initializing : MonoBehaviour
{
    private float x;
    private float y;

    private int maxIterations;
    private ComplexNumber C;
    private ComplexNumber.function mode;
    private int rowCounter = 0;
    private Texture2D texture;
    private int rowMax;
    private ColorMap colorMap;
    private drawingMode drawingMode;

    private void Awake()
    {
        maxIterations = PlayerPrefs.iteration;
        drawingMode = PlayerPrefs.drawingMode;
        colorMap = new ColorMap(drawingMode);
        texture = new Texture2D(PlayerPrefs.ScreenSize, PlayerPrefs.ScreenSize);
        GetComponent<Renderer>().material.mainTexture = texture;
        rowMax = (int)Mathf.Sqrt(2 * texture.height);

    }
    // Start is called before the first frame update
    void Start()
    {
        C = PlayerPrefs.complexNumber;
        mode = PlayerPrefs.function;
        Camera.main.transform.position = new Vector3(0, 0, -10f);


    }

    // Update is called once per frame
    void Update()
    {
        if (rowCounter < texture.width)
        {
            processPixels(rowMax);
            rowCounter += rowMax;
            texture.Apply();
        }
        else
        {
            texture.Apply();
        }

    }

    void processPixels(int howMuch)
    {
        for (int i = rowCounter; i < rowCounter + howMuch; i++)
        {
            for (int k = 0; k < texture.width; k++)
            {
                ComplexNumber complexNumber = null;
                int iterations = 0;
                if (PlayerPrefs.isMandelbor == true)
                {
                    complexNumber = new ComplexNumber { realPart = 0f, imaginaryPart = 0f };
                    C = new ComplexNumber { realPart = (k - texture.width * 0.5f) * 4f / texture.width, imaginaryPart = (i - texture.height / 2f) * 4f / texture.width };
                }
                else
                {
                    complexNumber = new ComplexNumber { realPart = (k - texture.width * 0.5f) * 4f / texture.width, imaginaryPart = (i - texture.height / 2f) * 4f / texture.width };
                  //  PlayerPrefs.complexNumber = complexNumber;
                }
                while (!complexNumber.goesToInfinity(2) && iterations < maxIterations)
                {
                    complexNumber = complexNumber.solve(mode);
                    complexNumber.addComplexNumber(C);
                    iterations++;
                }
                texture.SetPixel(texture.width - k, texture.height - i, colorMap.getIterationColor(iterations));
            }
        }
    }


    public void Restart()
    {
        SceneManager.LoadSceneAsync(1);
    }
    public void GoBack()
    {
        SceneManager.LoadSceneAsync(0);
    }
}


