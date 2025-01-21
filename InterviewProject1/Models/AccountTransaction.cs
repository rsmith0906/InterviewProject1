namespace InterviewProject1.Models
{
    /// <summary>
    /// Represents an account transaction.
    /// </summary>
    public class AccountTransaction
    {
        /// <summary>
        /// Gets or sets the unique identifier for the transaction.
        /// </summary>
        public Guid TransactionId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the account.
        /// </summary>
        public Guid AccountId { get; set; }

        /// <summary>
        /// Gets or sets the amount of the transaction.
        /// </summary>
        public double Amount { get; set; }

        /// <summary>
        /// Gets or sets the date of the transaction.
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Gets or sets the type of the transaction.
        /// </summary>
        public TransactionType TransactionType { get; set; }
    }
}
