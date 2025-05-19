// File:    Stop.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 19:35:13
// Purpose: Definition of Class Stop

using System;

public class Stop
{
    private string name;
    private string location;

    // Конструктор
    public Stop(string name, string location)
    {
        this.name = name;
        this.location = location;
    }

    // Геттер и сеттер для name
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Геттер и сеттер для location
    public string Location
    {
        get { return location; }
        set { location = value; }
    }
}