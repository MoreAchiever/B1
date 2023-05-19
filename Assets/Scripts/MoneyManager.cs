using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class MoneyManager : MonoBehaviour
{

    public Text moneyText; // Reference to the UI Text component

    // Update is called once per frame
    void Update()
    {
        moneyText.text = "Money: " + GroupStates.CurrentMoney.ToString() + " €";  
      //  Debug.Log(GroupStates.CurrentMoney);
    }
}
