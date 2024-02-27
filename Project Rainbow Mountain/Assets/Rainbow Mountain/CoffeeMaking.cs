using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoffeeMaking : MonoBehaviour
{
    Drink currentMix = new Drink(); // This list shows what is currently in the mix.

    bool sizeSelected = false;
    bool typeSelected = false;
    int sugar = 0;
    int coffee = 0;
    [SerializeField] private List<Drink> recipes = new List<Drink>();

    private void Update()
    {
        MixStation();
    }

    void CoffeeMix()
    {
        if (coffee <= 4)
        {
            currentMix.shots = coffee;
        }
        else currentMix.shots = 4;
    }

    void SugarMix()
    {
        if (sugar <= 4)
        {
            currentMix.sugar = sugar;
        }
        else currentMix.sugar = 4;
    }

    private string CompareDrink()
    {
        string result = "invalid";

        for (int i = 0; i <= recipes.Count-1; i++)
        {
            if (recipes[i].size == currentMix.size && recipes[i].type == currentMix.type && recipes[i].shots == currentMix.shots && recipes[i].sugar == currentMix.sugar)
            {
                result = recipes[i].name;
            }
        }

        return result;
    }

    private void MixStation()
    {
        if (sizeSelected == false) //Checks if size has been selected.
        {
            if (Input.GetKeyDown(KeyCode.Q)) //Select Small Cup.
            {
                currentMix.size = size.Small;
                sizeSelected = true;
                Debug.Log("Small Cup Selected (Q)");
            }

            if (Input.GetKeyDown(KeyCode.W)) //Select Medium Cup.
            {
                currentMix.size = size.Medium;
                sizeSelected = true;
                Debug.Log("Medium Cup Selected (W)");
            }

            if (Input.GetKeyDown(KeyCode.E)) //Select Large Cup.
            {
                currentMix.size = size.Large;
                sizeSelected = true;
                Debug.Log("Large Cup Selected (E)");
            }
        }

        if (sizeSelected == true && typeSelected == false) //Checks if size has been selected AND drink type not yet selected.
        {
            if (Input.GetKeyDown(KeyCode.J)) //Select Cappuccinno Type.
            {
                currentMix.type = type.Cappuccino;
                typeSelected = true;
                Debug.Log("Cappuccino Selected (J)");
            }

            if (Input.GetKeyDown(KeyCode.K)) //Select Latte Type.
            {
                currentMix.type = type.Latte;
                typeSelected = true;
                Debug.Log("Latte Selected (K)");
            }

            if (Input.GetKeyDown(KeyCode.L)) //Select Mocha Type.
            {
                currentMix.type = type.Mocha;
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

            string debug = "Order: ";

            debug += CompareDrink();

            Debug.Log(debug);
        }
    }
}
[Serializable]
public class Drink
{
    public string name;
    public size size;
    public type type;
    [Range(0, 4)]
    public int shots;
    [Range(0, 4)]
    public int sugar;
}
public enum size
{
    Small,
    Medium,
    Large
}

public enum type
{
    Cappuccino,
    Latte,
    Mocha
}