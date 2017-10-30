using System;
namespace m0ch.FIPA
{
    /// <summary>
    /// This is a special object that is useful for specifying parameter/value pairs.
    /// </summary>
    public class Property
    {

        private string name;
        private string term;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.Property"/> class.
        /// </summary>
        /// <param name="name">string and <b>String</b> since name can't be null</param>
        /// <param name="term">string and <b>String</b> since term can't be null</param>
        public Property(string name, string term)
        {
            this.name = name;
            this.term = term;
        }

        /// <summary>
        /// Method to retrieve name parameter;
        /// </summary>
        /// <returns>The name.</returns>
        public string getName()
        {
            return this.name;
        }

        /// <summary>
        /// Method to retrieve term parameter;
        /// </summary>
        /// <returns>The term.</returns>
        public string getTerm()
        {
            return this.term;
        }

    }
}
