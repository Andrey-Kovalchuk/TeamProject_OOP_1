// File:    PaymentValidator.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 20:36:05
// Purpose: Definition of Class PaymentValidator

using System;
using System.Runtime.CompilerServices;

public class PaymentValidator
{
    private string id;
    private bool status;
    private int countMoney; 
    private const int code = 9113; // Код для службової картки
    // Конструктор
    public PaymentValidator(string id, bool status, int countMoney)
    {
        this.id = id;
        this.status = status;
        this.countMoney = countMoney;
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
    public int CountMoney
    {
        get { return countMoney; }
        set { countMoney = value; }
    }
    public void AddPaiment ()
    {
        countMoney += 15; 
    }
    public bool CheckValidateCart (int passwords) 
    {
        return (passwords == code);
    }
}