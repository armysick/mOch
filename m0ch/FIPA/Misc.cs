using System;
using m0ch.Utils;
using System.Runtime.Hosting;
using System.Collections.Generic;
namespace m0ch.FIPA
{
    /// <summary>
    /// This is a special object that is useful for specifying parameter/value pairs.
    /// </summary>
    public class Property
    {

        private readonly string _name;
        private readonly string _term;

        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.Property"/> class.
        /// </summary>
        /// <param name="name">string and <b>String</b> since name can't be null</param>
        /// <param name="term">string and <b>String</b> since term can't be null</param>
        public Property(string name, string term)
        {
            this._name = name;
            this._term = term;
        }

        /// <summary>
        /// Method to retrieve name parameter;
        /// </summary>
        /// <returns>The name.</returns>
        public string GetName()
        {
            return this._name;
        }

        /// <summary>
        /// Method to retrieve term parameter;
        /// </summary>
        /// <returns>The term.</returns>
        public string GetTerm()
        {
            return this._term;
        }

    }

    /// <summary>
    /// This type of object represents a set of constraints to limit the 
    /// function of searching within a directory.
    /// </summary>
    public class SearchConstraints
    {

        /// <summary>
        /// The maximum depth of propagation of the search to federated directories. This value should not be negative.
        /// </summary>
        private readonly int _maxDepth;

        /// <summary>
        /// The maximum number of results to return for the search. This value should not be negative.
        /// </summary>
        private readonly int _maxResults;


        /// <summary>
        /// Initializes a new instance of the <see cref="T:m0ch.FIPA.SearchConstraints"/> class.
        /// </summary>
        /// <param name="maxDepth">Should not be negative.</param>
        /// <param name="maxResults">Should not be negative.</param>
        public SearchConstraints(int maxDepth = 0, int maxResults = 0)
        {
            if (maxDepth < 0 || maxResults < 0)
                throw new MiscException("Arguments shouldn't be null.");

            this._maxDepth = maxDepth;
            this._maxResults = maxResults;
        }

        /// <summary>
        /// Gets the max depth.
        /// </summary>
        /// <returns>The max depth.</returns>
        public int GetMaxDepth()
        {
            return this._maxDepth;
        }

        /// <summary>
        /// Gets the max results.
        /// </summary>
        /// <returns>The max results.</returns>
        public int GetMaxResults()
        {
            return this._maxResults;
        }
    }
}
