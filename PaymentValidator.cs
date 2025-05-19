// File:    PaymentValidator.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 20:36:05
// Purpose: Definition of Class PaymentValidator

using System;

public class PaymentValidator
{
    private string id;
    private bool status;

    // Конструктор
    public PaymentValidator(string id, bool status)
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
}