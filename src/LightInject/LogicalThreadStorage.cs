using System.Threading;

namespace LightInject
{
    /// <summary>
    /// Provides storage per logical thread of execution.
    /// </summary>
    /// <typeparam name="T">The type of the value contained in this <see cref="LogicalThreadStorage{T}"/>.</typeparam>
    public class LogicalThreadStorage<T>
    {
        private readonly AsyncLocal<T> asyncLocal = new AsyncLocal<T>();

        private readonly object lockObject = new object();

        /// <summary>
        /// Gets or sets the value for the current logical thread of execution.
        /// </summary>
        /// <value>
        /// The value for the current logical thread of execution.
        /// </value>
        public T Value
        {
            get { return asyncLocal.Value; }
            set { asyncLocal.Value = value; }
        }
    }
}