using System.Collections;
using System.Collections.Generic;
using System.Net.Cache;
using UnityEngine;

[System.Serializable]
public class Customer 
{
    public string firstname, lastName;
    public int age;
    public enum customerGender { Male = 0, Female = 1, Other = 2};
    public customerGender gender;
    public string occupation;

    public Customer(string firstName, string lastName, int age, int gender, string occupation)
    {
        
        this.firstname = firstName;
        this.lastName = lastName;
        this.age = age;
        this.gender = (customerGender)gender; //cast int to enum
        this.occupation = occupation;
    }
}

