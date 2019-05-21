using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComplexNumber
{
    public float realPart { get; set; }
    public float imaginaryPart { get; set; }

    public ComplexNumber addComplexNumber(ComplexNumber toAdd)
    {
        realPart += toAdd.realPart;
        imaginaryPart += toAdd.imaginaryPart;
        return this;
    }

    public ComplexNumber solve(function mode)
    {
        if (mode.Equals(function.Quadratic))
        {
            IComplexNumberSolver solver = new QuadraticSolver { ComplexNumber = this };
            return solver.solveComplexNumber();
        }
        else if (mode.Equals(function.Qubic))
        {
            IComplexNumberSolver solver = new QubicSolver { ComplexNumber = this };
            return solver.solveComplexNumber();
        }
        else return null;
    }

    public bool goesToInfinity(int limit)
    {
        return getAbsoluteValue() >= limit;
    }
    public float getAbsoluteValue()
    {
        return Mathf.Sqrt((realPart * realPart) + (imaginaryPart * imaginaryPart));
    }
    public override string ToString()
    {
        return realPart + " +i" + imaginaryPart;
    }



    /// <summary>
   /////////////////////ENUMERATION OF MODES
    /// </summary>


    public enum function
    {
        Quadratic, Qubic

    }


}
