using System.Collections;
using System.Collections.Generic;
using System; //IComparable namespace for inheritence
using UnityEngine;

//implement the generic IComparable interface - generic type needs to be this class
public class BadGuy : IComparable<BadGuy> {
    //used for a list of badguys
    public string name;
    public int power;

    public BadGuy(string newName, int newPower) {
        name = newName;
        power = newPower;
    }

    //complete implementation of the IComparable interface: return an int and takes generic type as a param
    //if the object it's being called from > the object taken as a param: function returns positive
    //if the object it's being called from < the object taken as a param: function returns negative
    //if the object it's being called from = the object taken as a param: function returns 0
    //what defines 1 object being > another is defined by the programmer - could base this result on anything
    //interface only requires CompareTo method implementation

    public int CompareTo(BadGuy other) {
        //check the badguy passed to the function exists
        if (other == null) { //this badguy is greater
            return 1;
        }

        //otherwise: return the difference between the powers of the 2 badguys
        //will return positive if the bad guy method its being called from is greater
        return power - other.power;
    }
}
