using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerPrefs 
{
    public static int ScreenSize { get; set; }
    public static ComplexNumber complexNumber { get; set; }
    public static int iteration { get; set; }
    public static bool isMandelbor { get; set; }
    public static drawingMode drawingMode { get; set; }
    public static  ComplexNumber.function function { get; set; }
}
