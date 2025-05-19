// File:    LicensePlate.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 20:19:43
// Purpose: Definition of Class LicensePlate

using System;

public class LicensePlate
{
    private string number;
    
    // Конструктор
    public LicensePlate(string number)
    {
        this.number = number;
    }

    // Геттер и сеттер для number
    public string Number
    {
        get { return number; }
        set { number = value; }
    }
}