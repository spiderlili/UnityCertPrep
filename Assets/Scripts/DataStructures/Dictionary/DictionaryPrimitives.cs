using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DictionaryPrimitives : MonoBehaviour
{
    public Dictionary<string, int> people = new Dictionary<string, int>();
    public Dictionary<int, string> books = new Dictionary<int, string>();

    // Start is called before the first frame update
    void Start()
    {
        people.Add("Jon", 25);
        people.Add("Lay", 35);
        people.Add("Ray", 28);
        people.Add("Yen", 38);

        int YenAge = people["Yen"];
        Debug.Log("Yen's age: " + YenAge);
        //Debug.Log(people[4]); //Does NOT work - dictionary items can only be looked up through their key

        books.Add(0, "The Last Wish");
        books.Add(1, "The Wolven Storm");

        Debug.Log(books[1]); //works - int is a key for books dictionary, print out the name
        //print out all books in the dictionary
        /*
            foreach (KeyValuePair<int, string> book in books)
        {
            Debug.Log("book: " + book.Value); //returns book string
        }*/

        //if do not care about key, only care about value:
        foreach (string book in books.Values) 
        {
            Debug.Log("book: " + book); //returns book string
        }
    }
}
