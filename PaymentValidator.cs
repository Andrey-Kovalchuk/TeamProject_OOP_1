// File:    PaymentValidator.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 20:36:05
// Purpose: Definition of Class PaymentValidator

using System;

public class PaymentValidator
{
    private string id;
    private bool status;
    private int totalPayments;
    private int concessionaryRides;
    private double totalRevenue;
    private const int Password = 9113;// не є магічним числом оскільки є номером картки

    /// <summary>
    /// Конструктор для створення нового екземпляра класу PaymentValidator.
    /// </summary>
    /// <param name="id">Унікальний ідентифікатор валідатора.</param>
    /// <param name="status">Початковий статус валідатора.</param>
    /// <param name="totalPayments">Початкова кількість оплачених поїздок.</param>
    /// <param name="concessionaryRides">Початкова кількість пільгових поїздок.</param>
    /// <param name="totalRevenue">Початкова виручка.</param>
    public PaymentValidator(string id, bool status, int totalPayments, int concessionaryRides, double totalRevenue)
    {
        this.id = id;
        this.status = status;
    }

    // Геттер и сеттер для id
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    // Геттер и сеттер для status
    public bool Status
    {
        get { return status; }
        set { status = value; }
    }

    // Геттер и сеттер для totalPayments
    public int TotalPayments
    {
        get { return totalPayments; }
        set { totalPayments = value; }
    }

    // Геттер и сеттер для concessionaryRides
    public int ConcessionaryRides
    {
        get { return concessionaryRides; }
        set { concessionaryRides = value; }
    }

    // Геттер и сеттер для totalRevenue
    public double TotalRevenue
    {
        get { return totalRevenue; }
        set { totalRevenue = value; }
    }

    /// <summary>
    /// Метод для перевірки валідності службової картки за допомогою пароля.
    /// </summary>
    /// <param name="code">Введений код службової картки.</param>
    /// <returns>Повертає true, якщо код вірний, інакше false.</returns>
    public bool CheckValidateCart(int code)
    {
        return code == Password; 
    }

    /// <summary>
    /// Метод для валідації електронного квитка.
    /// </summary>
    /// <param name="ticket">Електронний квиток для перевірки.</param>
    /// <returns>Повертає true, якщо квиток валідний і має достатній баланс, інакше false.</returns>
    public bool ValidateTicket(ElectronicTicket ticket)
    {
        return ticket != null && ticket.Balance >= 0;
    }
    /// <summary>
    /// Метод для реєстрації оплати проїзду.
    /// </summary>
    public void AddPayment()
    {
        TotalPayments++;
        TotalRevenue += 15.0;
    }
    /// <summary>
    /// Метод для реєстрації пільгової поїздки.
    /// </summary>
    public void RegisterConcessionaryRide()
    {
        ConcessionaryRides++;
    }
}