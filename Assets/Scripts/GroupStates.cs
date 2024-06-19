using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GroupStates : MonoBehaviour
{
    private System.Random random = new System.Random();


    private int panel0 = 0; //0 if the very first scene , 1 for race restart

    public CanvasGroup[] canvasGroups;
    public int initialStateIndex = 0;



    public static int CurrentMoney = 0;
    private int car = 0; //1 is bad, 2 is average and 3 is super
    //kidney  if 1 switch to average, if 2 earn 15000
    private int nitro = 0; // max 3

    private int currentStateIndex;

    private void Start()
    {
        // Disable all Canvas groups except the initial state
        for (int i = 0; i < canvasGroups.Length; i++)
        {
            canvasGroups[i].gameObject.SetActive(i == initialStateIndex);
        }

        currentStateIndex = initialStateIndex;
    }

    private void SwitchState(int newStateIndex)
    {
        // Disable the current state
        canvasGroups[currentStateIndex].gameObject.SetActive(false);

        // Enable the new state
        canvasGroups[newStateIndex].gameObject.SetActive(true);

        currentStateIndex = newStateIndex;
    }

    // Example method to switch to a specific state
    public void SwitchToState1()
    {
        SwitchState(1); // Replace 0 with the index of the desired state
    }

    public void SwitchToState2()
    {
        SwitchState(2); // Replace 0 with the index of the desired state
    }

    public void SwitchToState30()
    {
        IncreaseMoney(3000);
        SwitchState(30); // Replace 0 with the index of the desired state
    }

    // Example method to switch to another specific state
    public void SwitchBackToRaceStarter()
    {
        if (panel0 == 0)
        {
            SwitchState(2); 
        }
        else
        {
            SwitchState(28);  
        }

    }
    
    public void SwitchToState6()
    {
        SwitchState(6); // Replace 1 with the index of the desired state
    }

    public void SwitchToAverageCar()
    {
        car = 2;
        SwitchState(12); // Replace 1 with the index of the desired state
    }

    public void SwitchToVacation()
    {
        if (CurrentMoney >= 30000)
        {
            SwitchState(29);
        }
        else if(CurrentMoney < 30000 && currentStateIndex == 2)
        {
            panel0 = 0;
            SwitchState(3);
        }
        else if(CurrentMoney < 30000 && currentStateIndex == 28)
        {
            panel0 = 1;
            SwitchState(3);
        }
    }

    public void SwitchToBadVSSuperCar()
    {
        int randomNumber = random.Next(0, 100); // Generate a random number between 0 and 99

        if (randomNumber < 70)
        {
            car = 1;
            SwitchState(4);//bad car
        }
        else
        {
            car = 3;
            // Event did not occur (30% chance)
            SwitchState(17);//Super car
        }
    }

    public void SwitchToKidney1st()
    {
        SwitchState(9);

    }

    public void SwitchToKidney2nd() //if 1 switch to averageCar, if 2 earn 15000
    {
        int randomNumber = random.Next(1, 3);
        if (randomNumber == 1)
        {
            SwitchToAverageCar();
        }
        else if (randomNumber == 2)
        {
            IncreaseMoney(15000);
            SwitchState(10);
        }
    }

    public void SwitchToKidneyDeath()
    {
        SwitchState(11);
    }

    public void SwitchToOldCarRacePosition()
    {
        int randomNumber = random.Next(0, 100);
        if (randomNumber < 70)
        {
            SwitchState(6); // enemy ahead
        }
        else if(randomNumber >= 70)
        {
            SwitchState(5);   //you are ahead
        }
    }

    public void SwitchToAverageCarRacePosition()
    {
        int randomNumber = random.Next(0, 100);
        if (randomNumber < 50)
        {
            SwitchState(13); // you are ahead
        }
        else if(randomNumber >= 50)
        {
            SwitchState(14);   //enemy ahead
        }
    }

    public void SwitchToSuperCarRacePosition()
    {
        int randomNumber = random.Next(0, 100);
        if (randomNumber < 70)
        {
            SwitchState(18); // you are ahead
        }
        else if(randomNumber >= 70)
        {
            SwitchState(19);   //enemy ahead
        }
    }


    public void SwitchToFordwardAction()
    {
        ForwardActionCompare();
    }

    public void SwitchToBackAction()//triggered when kept driving
    {
        BackwardActionCompare();
    }

    public void BackwardActionCompare()//CrossCar
    {
        int randomNumber = random.Next(1, 3); // 50% chance for getting a shortcut event
        if (randomNumber == 2)
        {
            SwitchState(26);
        }
        else if (car == 1)
        {
            SwitchState(8);
        }
        else if (car == 2)
        {
            SwitchState(16);
        }
        else if (car == 3)
        {
            SwitchState(21);
        }
    }

    public void SwitchToPolice()
    {
        int randomNumber = random.Next(1, 3);// 50% chance to get busted by police
        if (randomNumber == 2)
        {
            SwitchState(27);
        }
        else if(car == 1 && randomNumber == 1)
        {
            IncreaseMoney(5000);   ///bad cars earn more money for skills as super cars earn less
            SwitchState(5);
        }
        else if(car == 2 && randomNumber == 1)
        {   
            IncreaseMoney(2500);
            SwitchState(13);
        }
        else if(car == 3 && randomNumber == 1)
        {
            IncreaseMoney(1000);
            SwitchState(18);
        }
    }


    public void ForwardActionCompare()
    {
       int randomNumber = random.Next(1, 3);
        if (randomNumber == 2)
        {
            SwitchState(22);
        }
        else //win
        {

            if (car == 1)
            {
                IncreaseMoney(10000);
                SwitchState(7);
            }
            else if (car == 2)
            {   
                IncreaseMoney(7500);
                SwitchState(15);
            }
            else if (car == 3)
            {
                IncreaseMoney(5000);
                SwitchState(20);
            }
            
        }
    }

    public void BackToCar()//called after an action such as nitro to get back to the race
    {
        if (car==1)
        {
            SwitchToOldCarRacePosition();
        }

        else if (car==2)
        {
            SwitchToAverageCarRacePosition();
        }        
        
        else if (car==3)
        {
            SwitchToSuperCarRacePosition();
        }
    }

    public void BackToLosingPostion()
    {
        if (car==1)
        {
            SwitchState(6);
        }

        else if (car==2)
        {
            SwitchState(14);
        }        
            
            else if (car==3)
        {
            SwitchState(19);
        }
    }

    public void NitroTrigger()
    {
        nitro += 1;
        if (nitro <3)
        {
            SwitchState(24);
            IncreaseMoney(1000);
        }
        else
        {
        SwitchState(25);
        }
    }

    public void ShortcutFirstChoice()
    {
        IncreaseMoney(1000);
        //Tomorow Stop Sign
    }

    public void ShortcutSecondChoice()
    {
        int randomNumber = random.Next(0, 100);
        if (randomNumber < 70)
        {
            SwitchState(23);
        }
        else if (randomNumber >= 70)
        {
            IncreaseMoney(10000);
            if (car == 1)
            {
                SwitchState(7);
            }
            else if (car == 2)
            {
                SwitchState(15);
            }
            else if (car == 3)
            {
                SwitchState(20);
            }
        }
    }

    public void RaceFinished()
    {
        nitro = 0;
        SwitchState(28);
    }

    public void RaceAgain()
    {
            if (car == 1)
            {
                SwitchToOldCarRacePosition();
            }
            else if (car == 2)
            {
                SwitchToAverageCarRacePosition();
            }
            else if (car == 3)
            {
                SwitchToSuperCarRacePosition();
            } 
    }


    public void RestartGame()
    {
        car = 0;
        CurrentMoney = 0;
        SceneManager.LoadScene(0);

    }

    public void IncreaseMoney(int amount)
    {
        CurrentMoney += amount;
    }


    //for testing multiple functions



}
