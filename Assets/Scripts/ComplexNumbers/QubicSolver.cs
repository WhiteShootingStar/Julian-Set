using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QubicSolver : IComplexNumberSolver
{
    public ComplexNumber ComplexNumber { get; set; }

    public ComplexNumber solveComplexNumber()
    {
        float realPart =ComplexNumber.realPart* (Mathf.Pow(ComplexNumber.realPart, 2) -3*ComplexNumber.imaginaryPart*ComplexNumber.imaginaryPart);
        float imaginaryPart = (3* Mathf.Pow(ComplexNumber.realPart, 2) - Mathf.Pow(ComplexNumber.imaginaryPart, 2))*ComplexNumber.imaginaryPart;
        return new ComplexNumber { realPart = realPart, imaginaryPart = imaginaryPart };
    }
}
