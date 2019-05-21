using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuadraticSolver : IComplexNumberSolver
{
    public ComplexNumber ComplexNumber { get; set; }

    public ComplexNumber solveComplexNumber()
    {
        float realPart = (Mathf.Pow(ComplexNumber.realPart, 2) - Mathf.Pow(ComplexNumber.imaginaryPart, 2));
        float imaginaryPart = 2 * ComplexNumber.realPart * ComplexNumber.imaginaryPart;
        return new ComplexNumber { realPart = realPart, imaginaryPart = imaginaryPart };
    }
}
