using System;

namespace LightInject
{
    /// <summary>
    /// Ensures that a new instance is created for each request in addition to tracking disposable instances.
    /// </summary>
    public class PerRequestLifeTime : ILifetime
    {
        /// <summary>
        /// Returns a service instance according to the specific lifetime characteristics.
        /// </summary>
        /// <param name="createInstance">The function delegate used to create a new service instance.</param>
        /// <param name="scope">The <see cref="Scope"/> of the current service request.</param>
        /// <returns>The requested services instance.</returns>
        public object GetInstance(Func<object> createInstance, Scope scope)
        {
            var instance = createInstance();
            var disposable = instance as IDisposable;
            if (disposable != null)
            {
                TrackInstance(scope, disposable);
            }

            return instance;
        }

        private static void TrackInstance(Scope scope, IDisposable disposable)
        {
            if (scope == null)
            {
                throw new InvalidOperationException("Attempt to create a disposable instance without a current scope.");
            }

            scope.TrackInstance(disposable);
        }
    }
}