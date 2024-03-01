using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CoffeeMaking : MonoBehaviour
{
    Drink currentMix = new Drink(); // This list shows what is currently in the mix.
    [SerializeField] private List<Drink> orders = new List<Drink>();

    bool sizeSelected = false;
    bool typeSelected = false;
    int sugar = 0;
    int coffee = 0;
    int ordersRemaining = 20;
    [SerializeField] private float timeBetweenOrders = 20.0f;
    [SerializeField] private List<Drink> recipes = new List<Drink>();

    public ScoreManager scoreManager;

    private void Start()
    {
        StartCoroutine(RunOrder());
    }

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

    private string CompareOrder()
    {
        string result = "invalid";

        for (int i = 0; i <= orders.Count - 1; i++)
        {
            if (Compare(orders[i], currentMix))
            {
                result = orders[i].name;
                orders.Remove(orders[i]);
                scoreManager.IncreaseScore(1);
                return result;
            }
        }
        return result;
    }

    private bool Compare(Drink a, Drink b)
    {
        bool result = false;

        if (a.size == b.size && a.type == b.type && a.shots == b.shots && a.sugar == b.sugar)
        {
            result = true;
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

            debug += CompareOrder();

            Debug.Log(debug);
            currentMix = new Drink();
            coffee = 0;
            sugar = 0;
            sizeSelected = false;
            typeSelected = false;
        }
    }

    IEnumerator RunOrder()
    {
        while(true)
        {
            Order();
            yield return new WaitForSeconds(timeBetweenOrders);
        }
    }

    private void Order()
    {
        if (ordersRemaining > 0)
        {
            if (orders.Count < 4)
            {
                orders.Add(recipes[UnityEngine.Random.Range(0, recipes.Count)]);
            }

            else if (orders.Count == 4)
            {
                scoreManager.DecreaseScore(1);
            }
            ordersRemaining--;
        }
    }
}

#region blah
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
#endregion