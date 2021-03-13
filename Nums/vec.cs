using System;
using System.Collections.Generic;
using System.Text;

namespace Nums {
    /// <summary>
    /// A vector made of floats
    /// </summary>
    public interface vec {
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        float length { get; }
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        float sqlength { get; }
        /// <summary>
        /// The sum of the vectors components.
        /// </summary>
        float sum { get; }
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        void normalize();
        /// <summary>
        /// Gets one of the vectors components by its index 
        /// </summary>
        float this[int i] { get; set; }
    }
    /// <summary>
    /// A vector made of doubles
    /// </summary>
    public interface dvec {
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        double length { get; }
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        double sqlength { get; }
        /// <summary>
        /// The sum of the vectors components.
        /// </summary>
        double sum { get; }
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        void normalize();
        /// <summary>
        /// Gets one of the vectors components by its index 
        /// </summary>
        double this[int i] { get; set; }
    }
    /// <summary>
    /// A vector made of ints
    /// </summary>
    public interface ivec {
        /// <summary>
        /// The magnitude of the vector
        /// </summary>
        int length { get; }
        /// <summary>
        /// The squared magnitude of the vector. sqlength is faster than length since a square-root operation is not needed.
        /// </summary>
        int sqlength { get; }
        /// <summary>
        /// The sum of the vectors components.
        /// </summary>
        int sum { get; }
        /// <summary>
        /// Normalizes this vector.
        /// </summary>
        void normalize();
        /// <summary>
        /// Gets one of the vectors components by its index 
        /// </summary>
        int this[int i] { get; set; }
    }
}
