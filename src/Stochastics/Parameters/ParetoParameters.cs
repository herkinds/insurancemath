namespace Herkinds.InsuranceMath.Stochastics.Parameters
{
    /// <summary>
    /// Parameters for the <see cref="Distributions.ParetoDistribution"/>. The Pareto parameters 
    /// are the shape and the scale.
    /// </summary>
    public class ParetoParameters
    {
        private ParetoParameters(decimal shape, decimal scale)
        {
            this.Shape = shape;
            this.Scale = scale;
        }

        /// <summary>
        /// Gets the shape. The shape parameter is also called the alpha.
        /// </summary>
        public decimal Shape { get; }

        /// <summary>
        /// Gets the scale. The scale parameter is also called the minimum value.
        /// </summary>
        public decimal Scale { get; }

        /// <summary>
        /// Creates Pareto distribution parameters.
        /// </summary>
        /// <param name="shape">The shape parameter.</param>
        /// <param name="scale">The scale parameter.</param>
        /// <returns>The Pareto distribution parameters.</returns>
        /// <exception cref="ArgumentException">If either shape or scale is not striclty positive.</exception>
        public static ParetoParameters Create(decimal shape, decimal scale)
        {
            if (shape <= 0)
            {
                throw new ArgumentException($"Parameter {nameof(shape)} cannot be smaller than or equal to zero.");
            }

            if (scale <= 0)
            {
                throw new ArgumentException($"Parameter {nameof(scale)} cannot be smaller than or equal to zero.");
            }

            return new ParetoParameters(shape, scale);
        }
    }
}
