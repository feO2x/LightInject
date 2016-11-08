using System;
using System.Collections.Generic;

namespace LightInject
{
    /// <summary>
    /// Represents a set of configurable options when creating a new instance of the container.
    /// </summary>
    public class ContainerOptions
    {
        private static readonly Lazy<ContainerOptions> DefaultOptions =
            new Lazy<ContainerOptions>(CreateDefaultContainerOptions);

        /// <summary>
        /// Initializes a new instance of the <see cref="ContainerOptions"/> class.
        /// </summary>
        public ContainerOptions()
        {
            EnableVariance = true;
            EnablePropertyInjection = true;
            LogFactory = t => message => { };
        }

        /// <summary>
        /// Gets the default <see cref="ContainerOptions"/> used across all <see cref="ServiceContainer"/> instances.
        /// </summary>
        public static ContainerOptions Default => DefaultOptions.Value;

        /// <summary>
        /// Gets or sets a value indicating whether variance is applied when resolving an <see cref="IEnumerable{T}"/>.
        /// </summary>
        /// <remarks>
        /// The default value is true.
        /// </remarks>
        public bool EnableVariance { get; set; }

        /// <summary>
        /// Gets or sets the log factory that crates the delegate used for logging.
        /// </summary>
        public Func<Type, Action<LogEntry>> LogFactory { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether property injection is enabled.
        /// </summary>
        /// <remarks>
        /// The default value is true.
        /// </remarks>
        public bool EnablePropertyInjection { get; set; }

        private static ContainerOptions CreateDefaultContainerOptions()
        {
            return new ContainerOptions();
        }
    }
}