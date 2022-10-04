using UnityEngine;
using UnityEngine.UI;

// Defines the signature of the event handler that PiggyBankEvent class will use to broadcast changes in the balance
public delegate void BalanceEventHandler(float theValue);

public class PiggyBankEvent : MonoBehaviour
{
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
    
    BalanceLogger balanceLogger = new BalanceLogger();
    BalanceWatcher balanceWatcher = new BalanceWatcher();
    
    // Start is called before the first frame update
    void Start()
    {
        balanceChanged += balanceLogger.balanceLog;
        balanceChanged += balanceWatcher.balanceWatch;
        depositPromptText.text = "How much to deposit? Your savings goal is " + savingsGoal;
    }

    public void MainCheckOnSubmit()
    {
        string userInputValue;
        do {
            depositPromptText.text = "How much to deposit? Your saved " + theBalance;
            userInputValue = userInputText.text;
            if (!userInputValue.Equals("exit")) {
                float newVal = float.Parse(userInputValue);
                theBalance += newVal;
            }
        } while (!userInputValue.Equals("exit"));
    }

    private void OnDestroy()
    {
        balanceChanged -= balanceLogger.balanceLog;
        balanceChanged -= balanceWatcher.balanceWatch;
    }

}

// functions MUST match the signature of the event handler delegate at the top!
class BalanceLogger
{
    public void balanceLog(float amount)
    {
        Debug.Log("The balance amaount is " + amount);
    }
}

class BalanceWatcher
{
    public void balanceWatch(float amount)
    {
        if (amount > 500.0f) {
            Debug.Log("Savings goal reached! you have " + amount + " saved up.");
        }
    }
}
