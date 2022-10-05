using UnityEngine.UI;
using UnityEngine;

public class UseLambdaAsDelegateExample : MonoBehaviour
{
    public delegate void myEventHandler(Text value); // Define a delegate
    public Text PromptText;
    public Text userInputText;
    private Text theVal;
    public event myEventHandler valueChanged;
    public Text Val
    {
        set {
            this.theVal = value;
            this.valueChanged(theVal); // When the value changes: fire the event
        }
    }
    
    void Start()
    {
        PromptText.text = "Type in something: ";
    }
    
    public void MainCheckOnSubmit()
    {
        string userInputValue = userInputText.text;
        // Use a lambda expression to define an event handler. Note this is a statement lambda due to the use of {}
        valueChanged += (x) => {
            Debug.Log("The value changed to " + x.text);
        };
        
        Val = userInputText;
    }
}
