using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomerDatabase : MonoBehaviour
{
    public Customer[] customers;
    [SerializeField] Customer customer1;

    // Start is called before the first frame update
    void Start()
    {
        customer1 = new Customer("Kat", "Wong", 22, 1, "Student");
        Customer customer2 = new Customer("Casey", "Tan", 32, 1, "Teacher");
        Customer customer3 = new Customer("Jay", "Smith", 22, 1, "Marketer");
    }
}
