// File:    ServiceCard.cs
// Author:  ivasc
// Created: 18 травня 2025 р. 19:36:39
// Purpose: Definition of Class ServiceCard

using System;

public class ServiceCard
{
   private string id;

    public ServiceCard(string id)
    {
        this.id = id;
    }

    public System.Collections.Generic.List<PaymentValidator> validator;
   
   /// <summary>
   /// Property for collection of PaymentValidator
   /// </summary>
   /// <pdGenerated>Default opposite class collection property</pdGenerated>
   public System.Collections.Generic.List<PaymentValidator> Validator
   {
      get
      {
         if (validator == null)
            validator = new System.Collections.Generic.List<PaymentValidator>();
         return validator;
      }
      set
      {
         RemoveAllValidator();
         if (value != null)
         {
            foreach (PaymentValidator oPaymentValidator in value)
               AddValidator(oPaymentValidator);
         }
      }
   }
   
   /// <summary>
   /// Add a new PaymentValidator in the collection
   /// </summary>
   /// <pdGenerated>Default Add</pdGenerated>
   public void AddValidator(PaymentValidator newPaymentValidator)
   {
      if (newPaymentValidator == null)
         return;
      if (this.validator == null)
         this.validator = new System.Collections.Generic.List<PaymentValidator>();
      if (!this.validator.Contains(newPaymentValidator))
         this.validator.Add(newPaymentValidator);
   }
   
   /// <summary>
   /// Remove an existing PaymentValidator from the collection
   /// </summary>
   /// <pdGenerated>Default Remove</pdGenerated>
   public void RemoveValidator(PaymentValidator oldPaymentValidator)
   {
      if (oldPaymentValidator == null)
         return;
      if (this.validator != null)
         if (this.validator.Contains(oldPaymentValidator))
            this.validator.Remove(oldPaymentValidator);
   }
   
   /// <summary>
   /// Remove all instances of PaymentValidator from the collection
   /// </summary>
   /// <pdGenerated>Default removeAll</pdGenerated>
   public void RemoveAllValidator()
   {
      if (validator != null)
         validator.Clear();
   }

}