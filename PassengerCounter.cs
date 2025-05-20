// File:    PassengerCounter.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 19:35:45
// Purpose: Definition of Class PassengerCounter

using System;

public class PassengerCounter
{
    private string id;
    private int count;
    private int SumOfPassenger; 

    // Конструктор
    public PassengerCounter(string id, int count)
    {
        this.id = id;
        this.count = count;
    }

    // Геттер и сеттер для id
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    // Геттер и сеттер для count
    public int Count
    {
        get { return count; }
        set { count = value; }
    }
    public void AddToCounter ()
    {
        count++;
    }
    public void RemoveFromCounter()
    {
        if (Count > 0)
            Count--;
    }
}