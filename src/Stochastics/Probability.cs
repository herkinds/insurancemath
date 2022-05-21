﻿using System;

namespace Herkinds.InsuranceMath.Stochastics
{
    /// <summary>
    /// A facade for <see cref="decimal"/>. Probabilities are numbers between 0 and 1, both including.
    /// </summary>
    public readonly struct Probability : IEquatable<Probability>
    {
        private readonly decimal value;

        private Probability(decimal value)
        {
            this.value = value;
        }

        /// <summary>
        /// Gets a probability of 100%.
        /// </summary>
        public static Probability One => new Probability(1);

        /// <summary>
        /// Gets a probability of 0%.
        /// </summary>
        public static Probability Zero => new Probability(0);

        /// <summary>
        /// Implicit cast to <see cref="decimal"/>.
        /// </summary>
        /// <param name="probability">A probability.</param>
        public static implicit operator decimal(Probability probability)
            => probability.value;

        /// <summary>
        /// Returns a value that indicates wheter two specified <see cref="Probability"/> values are equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">the second value to compare.</param>
        /// <returns>true if left and right are equal; otherwise, false.</returns>
        public static bool operator ==(Probability left, Probability right)
        {
            return left.value == right.value;
        }

        /// <summary>
        /// Returns a value that indicates wheter two specified <see cref="Probability"/> values are not equal.
        /// </summary>
        /// <param name="left">The first value to compare.</param>
        /// <param name="right">the second value to compare.</param>
        /// <returns>true if left and right are not equal; otherwise, false.</returns>
        public static bool operator !=(Probability left, Probability right)
        {
            return !(left == right);
        }

        /// <summary>
        /// Parses a specified <see cref="decimal"/> to a <see cref="Probability"/>.
        /// </summary>
        /// <param name="value">The <see cref="decimal"/> value to parse.</param>
        /// <returns>A probability.</returns>
        public static Probability Parse(decimal value)
        {
            if (value > 1)
            {
                throw new ArgumentException($"The {nameof(value)} of {value} should be smaller than 1.");
            }

            if (value < 0)
            {
                throw new ArgumentException($"The {nameof(value)} of {value} should be greater than 0.");
            }

            return new Probability(value);
        }

        /// <summary>
        /// Converts this instance to a <see cref="decimal"/>.
        /// </summary>
        /// <returns>The <see cref="decimal"/> value of the probability.</returns>
        public decimal ToDecimal()
            => this.value;

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            if (obj is Probability probability)
            {
                this.Equals(probability);
            }

            return false;
        }

        /// <summary>
        /// Indicates wheter this instance and the specified <see cref="Probability"/> are equal.
        /// </summary>
        /// <param name="other">The <see cref="Probability"/> to compare with the current instance.</param>
        /// <returns>true if this instance and the other instance are equal; otherwise, false.</returns>
        public bool Equals(Probability other)
        {
            return this.value.Equals(other.value);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return this.value.GetHashCode();
        }
    }
}
