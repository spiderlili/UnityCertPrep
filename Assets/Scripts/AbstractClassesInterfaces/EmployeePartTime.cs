using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmployeePartTime : EmployeeAbstractClass
{
    [SerializeField] private float hoursWorked;
    [SerializeField] private float hourlyRate;

    public override void CalculateMonthlySalary()
    {
        Debug.Log("PT Employee Monthly Salary: ");
    }
}
