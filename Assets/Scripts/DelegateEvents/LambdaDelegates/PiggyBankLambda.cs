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
        string userInputValue= userInputText.text;
        float newVal = float.Parse(userInputValue);

        balanceChanged += (y) => {
            if (theBalance > 500.0f) {
                Debug.Log("Savings goal reached! you have " + y + " saved up.");
            }
        };
        
        // Use a lambda expression to define an event handler. Note this is a statement lambda due to the use of {}
        balanceChanged += (x) => {
            theBalance += x;
            Debug.Log("How much to deposit? Your saved " + theBalance);
        };
    }
}

