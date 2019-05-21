using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public  interface IComplexNumberSolver
{
    ComplexNumber ComplexNumber { get; set; }
    ComplexNumber solveComplexNumber();
}
