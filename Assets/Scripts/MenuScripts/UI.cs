using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UI : MonoBehaviour
{
    public Toggle mandelbrot;
    public Canvas subCanvas;
    public InputField iterInput, resolInput;
    public Dropdown colorMode, functionMode;
    public InputField reInput, imInput;
    // Start is called before the first frame update
    void Start()
    {
        subCanvas.gameObject.SetActive(false);

        PlayerPrefs.isMandelbor = mandelbrot.isOn;

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void changeMandelbrot()
    {
        PlayerPrefs.isMandelbor = mandelbrot.isOn;
        Debug.Log(PlayerPrefs.isMandelbor);
        subCanvas.gameObject.SetActive(!mandelbrot.isOn);
    }

    public void Quit()
    {
        Application.Quit();
    }
    public void start()
    {
        string pattern = "[0-9]+";
        string complexpattern = "[0-9]*[.[0-9]+]?"           /*"-?[0-9]+//.[0-9]+"*/; /*"-?//d + (?://.//d +)"*/
        if (Regex.IsMatch(iterInput.text, pattern) && Regex.IsMatch(resolInput.text, pattern))
        {
            PlayerPrefs.iteration = int.Parse(iterInput.text);
            PlayerPrefs.ScreenSize = int.Parse(resolInput.text);
            Debug.Log(PlayerPrefs.iteration);
            Debug.Log(PlayerPrefs.ScreenSize);
            PlayerPrefs.drawingMode = (drawingMode)colorMode.value;
            PlayerPrefs.function = (ComplexNumber.function)functionMode.value;
            Debug.Log(PlayerPrefs.drawingMode);
            Debug.Log(PlayerPrefs.function);


            if (PlayerPrefs.isMandelbor == false && Regex.IsMatch(reInput.text, complexpattern) && Regex.IsMatch(imInput.text, complexpattern))
            {
                ComplexNumber number = new ComplexNumber { realPart = float.Parse(reInput.text, CultureInfo.InvariantCulture), imaginaryPart = float.Parse(imInput.text, CultureInfo.InvariantCulture) };
                Debug.Log(number);
                PlayerPrefs.complexNumber = number;

            }


            }
            SceneManager.LoadSceneAsync(1);
        }

    }


