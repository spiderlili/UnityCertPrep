using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class EmployeeFullTime : EmployeeAbstractClass
{
    [SerializeField] private float salary;
    
    public override void CalculateMonthlySalary()
    {
        Debug.Log("FT Employee Monthly Salary: ");
    }
}
