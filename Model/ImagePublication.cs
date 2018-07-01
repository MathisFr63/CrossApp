using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Model
{
    public class ImagePublication : Publication
    {
        public string ImageSource { get; set; }

        #region Constructors
        /// <summary>
        /// Default constructor
        /// </summary>
        public ImagePublication()
        {
        }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="accountId">Account identifier.</param>
        /// <param name="message">Message describing the application.</param>
        /// <param name="imageSource">Source of the image.</param>
        public ImagePublication(int accountId, string message, string imageSource) : base(accountId, message)
        {
            ImageSource = imageSource;
        }
        #endregion
    }
}
