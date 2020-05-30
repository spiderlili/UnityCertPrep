using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Bank 
{
    public string branchName;
    public string location;
    public string cashInVault;

    public void CheckBalance()
    {
        Debug.Log("Check Balance: " + branchName);
    }

    public void Withdrawl()
    {
        Debug.Log("Withdrawling money from: " + branchName);
    }

    public void Deposit()
    {
        Debug.Log("Depositing money to: " + branchName);
    }
}
