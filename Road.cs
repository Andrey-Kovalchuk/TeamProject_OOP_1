// File:    Road.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 19:26:35
// Purpose: Definition of Class Road

using System;
using System.Runtime.ConstrainedExecution;

public class Road
{
    private string name;
    private List<Stop> stops;
    private TransportVehicle transportVehicle;


    public Stop this[int index] 
    {
        get
        { return stops[index]; }
        set
        { stops[index] = value; }
    }
    // Конструктор
    public Road(string name, List<Stop> stops, TransportVehicle transportVehicle)
    {
        this.name = name;
        this.stops = stops;
        this.transportVehicle = transportVehicle;
    }
    public void AddStop (Stop stop)
    {
        stops.Add(stop); 
    }
    // Геттер и сеттер для name
    public string Name
    {
        get { return name; }
        set { name = value; }
    }

    // Геттер и сеттер для stops
    public List<Stop> Stops
    {
        get { return stops; }
        set { stops = value; }
    }
}