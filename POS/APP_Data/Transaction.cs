//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace POS.APP_Data
{
    using System;
    using System.Collections.Generic;
    
    public partial class Transaction
    {
        public Transaction()
        {
            this.AttachGiftSystemForTransactions = new HashSet<AttachGiftSystemForTransaction>();
            this.DeleteLogs = new HashSet<DeleteLog>();
            this.ExchangeRateForTransactions = new HashSet<ExchangeRateForTransaction>();
            this.GiftCardInTransactions = new HashSet<GiftCardInTransaction>();
            this.Transaction1 = new HashSet<Transaction>();
            this.TransactionDetails = new HashSet<TransactionDetail>();
            this.TransactionDetail_BK = new HashSet<TransactionDetail_BK>();
            this.UsePrePaidDebts = new HashSet<UsePrePaidDebt>();
            this.UsePrePaidDebts1 = new HashSet<UsePrePaidDebt>();
        }
    
        public string Id { get; set; }
        public System.DateTime DateTime { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public int UserId { get; set; }
        public int CounterId { get; set; }
        public string Type { get; set; }
        public Nullable<bool> IsPaid { get; set; }
        public Nullable<bool> IsComplete { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public bool Loc_IsCalculatePoint { get; set; }
        public Nullable<int> PaymentTypeId { get; set; }
        public Nullable<int> TaxAmount { get; set; }
        public Nullable<int> DiscountAmount { get; set; }
        public Nullable<decimal> TotalAmount { get; set; }
        public Nullable<decimal> RecieveAmount { get; set; }
        public string ParentId { get; set; }
        public Nullable<int> GiftCardId { get; set; }
        public Nullable<int> CustomerId { get; set; }
        public Nullable<int> ReceivedCurrencyId { get; set; }
        public Nullable<int> ShopId { get; set; }
        public Nullable<bool> IsExported { get; set; }
    
        public virtual ICollection<AttachGiftSystemForTransaction> AttachGiftSystemForTransactions { get; set; }
        public virtual Counter Counter { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual ICollection<DeleteLog> DeleteLogs { get; set; }
        public virtual ICollection<ExchangeRateForTransaction> ExchangeRateForTransactions { get; set; }
        public virtual GiftCard GiftCard { get; set; }
        public virtual ICollection<GiftCardInTransaction> GiftCardInTransactions { get; set; }
        public virtual PaymentType PaymentType { get; set; }
        public virtual ICollection<Transaction> Transaction1 { get; set; }
        public virtual Transaction Transaction2 { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<TransactionDetail> TransactionDetails { get; set; }
        public virtual ICollection<TransactionDetail_BK> TransactionDetail_BK { get; set; }
        public virtual ICollection<UsePrePaidDebt> UsePrePaidDebts { get; set; }
        public virtual ICollection<UsePrePaidDebt> UsePrePaidDebts1 { get; set; }
    }
}
