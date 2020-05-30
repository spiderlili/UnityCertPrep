using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class CreditUnion : Bank //inherit functinoalities from bank with additional unique things
{
    public int availableCashToLend;

    public void ApproveLending()
    {
        Debug.Log("Loan approved!"); 
    }
    
}
