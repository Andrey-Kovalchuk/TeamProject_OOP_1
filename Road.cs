// File:    Road.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 19:26:35
// Purpose: Definition of Class Road

using System;

public class Road
{
    private string name;
    private List<Stop> stops;
    private TransportVehicle transportVehicle;

    /// <summary>
    /// Індексатор для доступу до зупинок за індексом.
    /// </summary>
    /// <param name="index">Індекс зупинки.</param>
    /// <returns>Зупинка за вказаним індексом.</returns>
    public Stop this[int index] 
    {
        get
        { return stops[index]; }
        set
        { stops[index] = value; }
    }
    /// <summary>
    /// Конструктор для створення нового екземпляра класу Road.
    /// </summary>
    /// <param name="name">Назва маршруту.</param>
    /// <param name="stops">Список зупинок на маршруті.</param>
    /// <param name="transportVehicle">Транспортний засіб, що обслуговує маршрут.</param>
    public Road(string name, List<Stop> stops, TransportVehicle transportVehicle)
    {
        this.name = name;
        this.stops = stops;
        this.transportVehicle = transportVehicle;
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
    public TransportVehicle TransportVehicle
    {
        get { return transportVehicle; }
        set { transportVehicle = value; }
    }
    /// <summary>
    /// Метод для додавання нової зупинки до маршруту.
    /// </summary>
    /// <param name="stop">Зупинка, яку потрібно додати.</param>
    public void AddStop (Stop stop)
    {
        stops.Add(stop); 
    }
}