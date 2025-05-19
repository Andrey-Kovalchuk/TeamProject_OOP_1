// File:    GPSMonitor.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 19:35:34
// Purpose: Definition of Class GPSMonitor

using System;

public class GPSMonitor
{
    private string id;
    private bool status;
    private string location; 
    // Конструктор
    public GPSMonitor(string id, bool status, string location)
    {
        this.id = id;
        this.status = status;
        this.location = location;
    }
     
    // Геттер и сеттер для id
    public string Id
    {
        get { return id; }
        set { id = value; }
    }
    public string Location
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