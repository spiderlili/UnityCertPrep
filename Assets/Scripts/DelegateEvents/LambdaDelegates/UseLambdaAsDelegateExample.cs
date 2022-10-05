using UnityEngine.UI;
using UnityEngine;

public class UseLambdaAsDelegateExample : MonoBehaviour
{
    public delegate void myEventHandler(string value); // Define a delegate
    public Text PromptText;
    public Text userInputText;
    private string theVal;
    public event myEventHandler valueChanged;
    public string Val
    {
        set {
            this.theVal = value;
            this.valueChanged(theVal); // When the value changes: fire the event
        }
    }
    
    void Start()
    {
        PromptText.text = "Type in something: ";
        // Use a lambda expression to define an event handler. Note this is a statement lambda due to the use of {}
        valueChanged += (x) => {
            Debug.Log("The value changed to " + x);
        };

        Val = userInputText.ToString();
    }
}
