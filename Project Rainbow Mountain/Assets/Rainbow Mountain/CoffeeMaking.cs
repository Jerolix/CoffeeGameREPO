using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaking : MonoBehaviour
{
    List<int> currentMix = new List<int>(); // This list shows what is currently in the mix.

    bool sizeSelected = false;
    bool typeSelected = false;
    int sugar = 0;
    int coffee = 0;

    //Cappuccinno recipe variations. These will be checked against currentMix.
    List<int> capSmall1 = new List<int>() { 0, 1, 2 }; // First potion recipe, Mana Potion.
    List<int> capSmall2 = new List<int>() { 0, 0, 2 }; // Second potion recipe, Health Potion.
    List<int> capMedium1 = new List<int>() { 1, 1, 1 }; // Third potion recipe, Rage Potion.
    List<int> capMedium2 = new List<int>() { 1, 1, 2 }; // First potion recipe, Mana Potion.
    List<int> capLarge1 = new List<int>() { 2, 0, 2 }; // Second potion recipe, Health Potion.
    List<int> capLarge2 = new List<int>() { 2, 1, 1 }; // Third potion recipe, Rage Potion.

    private void Update()
    {
        MixStation();
    }

    void CoffeeMix()
    {
        if (coffee == 0)
        {
            currentMix.Add(6);
        }
        else if(coffee == 1)
        {
            currentMix.Add(7);
        }
        else if (coffee == 2)
        {
            currentMix.Add(8);
        }
        else if (coffee == 3)
        {
            currentMix.Add(9);
        }
        else if (coffee >= 4)
        {
            currentMix.Add(10);
        }
    }

    void SugarMix()
    {
        if (sugar == 0)
        {
            currentMix.Add(11);
        }
        else if (sugar == 1)
        {
            currentMix.Add(12);
        }
        else if (sugar == 2)
        {
            currentMix.Add(13);
        }
        else if (sugar == 3)
        {
            currentMix.Add(14);
        }
        else if (sugar >= 4)
        {
            currentMix.Add(15);
        }
    }

    private void MixStation()
    {
        if (sizeSelected == false) //Checks if size has been selected.
        {
            if (Input.GetKeyDown(KeyCode.Q)) //Select Small Cup.
            {
                currentMix.Add(0);
                sizeSelected = true;
                Debug.Log("Small Cup Selected (Q)");
            }

            if (Input.GetKeyDown(KeyCode.W)) //Select Medium Cup.
            {
                currentMix.Add(1);
                sizeSelected = true;
                Debug.Log("Medium Cup Selected (W)");
            }

            if (Input.GetKeyDown(KeyCode.E)) //Select Large Cup.
            {
                currentMix.Add(2);
                sizeSelected = true;
                Debug.Log("Large Cup Selected (E)");
            }
        }

        if (sizeSelected == true && typeSelected == false) //Checks if size has been selected AND drink type not yet selected.
        {
            if (Input.GetKeyDown(KeyCode.J)) //Select Cappuccinno Type.
            {
                currentMix.Add(3);
                typeSelected = true;
                Debug.Log("Cappuccino Selected (J)");
            }

            if (Input.GetKeyDown(KeyCode.K)) //Select Latte Type.
            {
                currentMix.Add(4);
                typeSelected = true;
                Debug.Log("Latte Selected (K)");
            }

            if (Input.GetKeyDown(KeyCode.L)) //Select Mocha Type.
            {
                currentMix.Add(5);
                typeSelected = true;
                Debug.Log("Mocha Selected (L)");
            }
        }

        if (sizeSelected == true && typeSelected == true) //Checks if size, drink type have been selected.
        {
            if (Input.GetKeyDown(KeyCode.S))
            {
                sugar++;
                Debug.Log("Sugar: " + sugar);
            }
        }

        if (sizeSelected == true && typeSelected == true) //Checks if size, drink type have been selected.
        {
            if (Input.GetKeyDown(KeyCode.C))
            {
                coffee++;
                Debug.Log("Shots of Coffee: " + coffee);
            }
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            CoffeeMix(); SugarMix();
            currentMix.Sort();

            string debug = "Order: ";

            foreach(int value in currentMix)
            {
                debug += value + ", ";
            }

            Debug.Log(debug);
        }
    }
}
