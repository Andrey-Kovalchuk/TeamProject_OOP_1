// File:    ElectronicTicket.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 19:36:26
// Purpose: Definition of Class ElectronicTicket

using System;

public class ElectronicTicket
{
    private string id;
    private string type;
    private double balance;

    // Конструктор
    public ElectronicTicket(string id, string type, double balance)
    {
        this.id = id;
        this.type = type;
        this.balance = balance;
    }

    // Геттер и сеттер для id
    public string Id
    {
        get { return id; }
        set { id = value; }
    }

    // Геттер и сеттер для type
    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    // Геттер и сеттер для balance
    public double Balance
    {
        get { return balance; }
        set { balance = value; }
    }
}