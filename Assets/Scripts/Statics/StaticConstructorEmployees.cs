using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Employee
{
    //instance members
    public int employeeID;
    public string firstName, lastName;
    public int salary;

    //static member
    public static string company;
    public Employee() //called +1 each time a new employee is created
    {
        Debug.Log("Instance Members Initialized");
    }
    //use a static constructor for static member: make sure to initialize static data before creating instances of the object
    static Employee() //called only once for all employees created
    {
        company = "KittenGames";
        Debug.Log("Static Members Initialized"); //called first
    }
}

public class StaticConstructorEmployees : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Employee jasmine = new Employee();
        var employee2 = new Employee(); //universal data type that knows it's an Employee based on object type specified
        Employee kasey = new Employee();
    }
}
