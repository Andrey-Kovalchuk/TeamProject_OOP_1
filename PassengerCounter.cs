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
    /// <summary>
    /// Конструктор для створення нового екземпляра класу PassengerCounter.
    /// </summary>
    /// <param name="id">Унікальний ідентифікатор лічильника.</param>
    /// <param name="count">Початкова кількість пасажирів.</param>
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
    /// <summary>
    /// Метод для збільшення лічильника пасажирів на одиницю.
    /// </summary>
    public void AddToCounter()
    {
        count++;
    }
    /// <summary>
    /// Метод для зменшення лічильника пасажирів на одиницю, якщо кількість більша за нуль.
    /// </summary>
    public void RemoveFromCounter()
    {
        if (Count > 0)
            Count--;
    }
}