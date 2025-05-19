// File:    TransportVehicle.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 19:26:29
// Purpose: Definition of Class TransportVehicle

using Project_v2;
using System;

public class TransportVehicle
{

    private long id;
    private string type;
    private LicensePlate licensePlate; // Об’єкт LicensePlate (замість string licencePlate)
    private PassengerCounter passengerCounter; // Агрегація 1:1
    private PaymentValidator paymentValidator; // Агрегація 1:1
    private GPSMonitor gpsMonitor; // Агрегація 1:1
    private Road currentRoad; // Асоціація 1:1

    // Оновлений конструктор
    public TransportVehicle(
        long id,
        string type,
        string plate,
        PassengerCounter passengerCounter,
        PaymentValidator paymentValidator,
        GPSMonitor gpsMonitor,
        Road currentRoad)
    {
        this.id = id;
        this.type = type;
        this.licensePlate = new LicensePlate(plate);
        this.passengerCounter = passengerCounter;
        this.paymentValidator = paymentValidator;
        this.gpsMonitor = gpsMonitor;
        this.currentRoad = currentRoad;
    }

    public long Id
    {
        get { return id; }
        set { id = value; }
    }

    public string Type
    {
        get { return type; }
        set { type = value; }
    }

    public LicensePlate LicensePlate
    {
        get { return licensePlate; }
        set { licensePlate = value; }
    }

    public PassengerCounter PassengerCounter
    {
        get { return passengerCounter; }
        set { passengerCounter = value; }
    }

    public PaymentValidator PaymentValidator
    {
        get { return paymentValidator; }
        set { paymentValidator = value; }
    }

    public GPSMonitor GPSMonitor
    {
        get { return gpsMonitor; }
        set { gpsMonitor = value; }
    }

    public Road CurrentRoad
    {
        get { return currentRoad; }
        set { currentRoad = value; }
    }

    public void OpenTheDoor()
    {
        Service.StartWork();
    }
}