using UnityEngine.UI;
using UnityEngine;

public class PiggyBankLambda : MonoBehaviour
{
    public delegate void BalanceEventHandler(float value); // Define a delegate
    private float bankBalance;
    public event BalanceEventHandler balanceChanged;
    public Text depositPromptText;
    public float savingsGoal = 500f;
    public Text userInputText;
    
    public float theBalance
    {
        set {
            bankBalance = value;
            balanceChanged(value); // Event is triggered & broadcast to all listeners
        }
        get {
            return bankBalance;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        depositPromptText.text = "How much to deposit? Savings goal: " + savingsGoal;
    }

    public void MainCheckOnSubmit()
    {
        // Use a lambda expression to define an event handler. Note this is a statement lambda due to the use of {}
        balanceChanged += (amount) => {
            if (theBalance > 500.0f) {
                depositPromptText.text = "Savings goal reached! you have " + amount + " saved up.";
                Debug.Log("Savings goal reached! you have " + amount + " saved up.");
            } else {
                depositPromptText.text = "How much to deposit? Your saved " + amount;
                Debug.Log("How much to deposit? Your saved " + amount);
            }
        };
        
        string userInputValue = userInputText.text;
        float newVal = float.Parse(userInputValue);
        theBalance += newVal;
    }
}

