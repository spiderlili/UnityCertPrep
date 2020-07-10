using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EmployeeAbstractClass : MonoBehaviour
{
    [SerializeField] protected string companyName; //static string if all employees work for the same company
    [SerializeField] protected string employeeFirstName;
    [SerializeField] protected string employeeLastName;

    public abstract void CalculateMonthlySalary(); //force implementation of function in child classes
}
