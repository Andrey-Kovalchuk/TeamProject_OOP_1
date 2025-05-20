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
    private int totalPayments;
    private int concessionaryRides;
    private double totalRevenue;
    private const int Password = 9113;
    public PaymentValidator(string id, bool status, int totalPayments, int concessionaryRides, double totalRevenue)
    {
        this.id = id;
        this.status = status;
        this.totalPayments = totalPayments;
        this.concessionaryRides = concessionaryRides;
        this.totalRevenue = totalRevenue;
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


    public bool CheckValidateCart(int code)
    {
        return code == Password; 
    }


    public bool ValidateTicket(ElectronicTicket ticket)
    {
        return ticket != null && ticket.Balance >= 0;
    }

    public void AddPayment()
    {
        TotalPayments++;
        TotalRevenue += 15.0;
    }

    public void RegisterConcessionaryRide()
    {
        ConcessionaryRides++;
    }
}