using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalReaction : MonoBehaviour
{
    public GameObject bubble;
    static Queue<int> selected = new Queue<int>();
    List<string> chemical = new List<string>() {
        "Sodium", "Lithium", "Sulfuric Acid", "Hydrochloric Acid", //0 1 2 3
        "Sodium Lithium", "Sulfuric Hydrochloric Acid", //4 5
        "Sodium Sulfate", "Sodium Chloride",        //6 7
        "Lithium Sulfate", "Lithium Chloride",      //8 9
    };
    public int[,] outcomeArr = {
        { 0, 4, 6, 7   }, //00 01 02 03
        { 4, 1, 8, 9  },  //10 11 12 13
        { 6, 8, 2, 5  },  //20 21 22 23
        { 7, 9, 5, 3  },  //30 31 32 33
    };

    // Start is called before the first frame update
    void Start()
    {

    }

    public void AddChemical(string name)
    {
        int index = chemical.IndexOf(name);
        selected.Enqueue(index);
        if (selected.Count >= 2)
        {
            string result = chemical[outcomeArr[selected.Dequeue(), selected.Dequeue()]];
            Debug.Log(result);
            bubble.SetActive(true);
            //CallOtherFunction(result);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
