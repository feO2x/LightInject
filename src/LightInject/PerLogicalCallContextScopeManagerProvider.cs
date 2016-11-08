namespace LightInject
{
    /// <summary>
    /// A <see cref="IScopeManagerProvider"/> that creates an <see cref="IScopeManager"/>
    /// that is capable of managing scopes across async points.
    /// </summary>
    public class PerLogicalCallContextScopeManagerProvider : ScopeManagerProvider
    {
        /// <summary>
        /// Creates a new <see cref="IScopeManager"/> instance.
        /// </summary>
        /// <param name="serviceFactory">The <see cref="IServiceFactory"/> to be associated with the <see cref="IScopeManager"/>.</param> 
        /// <returns><see cref="IScopeManager"/>.</returns>
        protected override IScopeManager CreateScopeManager(IServiceFactory serviceFactory)
        {
            return new PerLogicalCallContextScopeManager(serviceFactory);
        }
    }
}