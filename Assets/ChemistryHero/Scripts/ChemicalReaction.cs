using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChemicalReaction : MonoBehaviour
{
    static Queue<int> selected = new Queue<int>();
    List<string> chemical = new List<string>() {
        "Potassium", "Lithium", "Sulfuric acid", "Nitric acid", //0 1 2 3
        "Potassium Lithium", "Sulfuric Nitric acid", //4 5
        "Potassium Sulfate", "Potassium Nitrate",    //6 7
        "Lithium Sulfate", "Lithium Nitrate",        //8 9
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
            //CallOtherFunction(result);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
