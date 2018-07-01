using System;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    public class Publication
    {
        #region Public properties
        /// <summary>
        /// Identifier
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// Identifier of the account wich publicate
        /// </summary>
        public int AccountId { get; set; }
        public virtual Account Account { get; set; }

        /// <summary>
        /// Date of publication
        /// </summary>
        public DateTime Date { get; set; }

        /// <summary>
        /// Message describing the publication
        /// </summary>
        /// <value>The message.</value>
        public string Message { get; set; }
        #endregion

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public Publication()
        {
            //Date = DateTime.Now;
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountId">Account identifier.</param>
        /// <param name="message">Message.</param>
        public Publication(int accountId, string message) : this()
        {
            this.AccountId = accountId;
            this.Message = message;
            this.Date = DateTime.Now;
        }
        #endregion
    }
}