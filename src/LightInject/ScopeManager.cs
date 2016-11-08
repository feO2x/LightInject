using System;

namespace LightInject
{
    /// <summary>
    /// A base class for implementing <see cref="IScopeManager"/>.
    /// </summary>
    public abstract class ScopeManager : IScopeManager
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ScopeManager"/> class.        
        /// </summary>
        /// <param name="serviceFactory">The <see cref="IServiceFactory"/> to be associated with this <see cref="ScopeManager"/>.</param>
        protected ScopeManager(IServiceFactory serviceFactory)
        {
            ServiceFactory = serviceFactory;
        }
        
        /// <summary>
        /// Gets or sets the current <see cref="Scope"/>.
        /// </summary>
        public abstract Scope CurrentScope { get; set; }

        /// <summary>
        /// Gets the <see cref="IServiceFactory"/> that is associated with this <see cref="IScopeManager"/>.
        /// </summary>
        public IServiceFactory ServiceFactory { get; }

        /// <summary>
        /// Starts a new <see cref="Scope"/>.
        /// </summary>
        /// <returns>A new <see cref="Scope"/>.</returns>
        public Scope BeginScope()
        {
            var currentScope = CurrentScope;
            var scope = new Scope(this, currentScope);
            if (currentScope != null)
            {
                currentScope.ChildScope = scope;
            }

            CurrentScope = scope;
            return scope;
        }

        /// <summary>
        /// Ends the given <paramref name="scope"/>.
        /// </summary>
        /// <param name="scope">The scope to be ended.</param>
        public void EndScope(Scope scope)
        {
            if (scope.ChildScope != null)
            {
                throw new InvalidOperationException("Attempt to end a scope before all child scopes are completed.");
            }

            if (!ReferenceEquals(CurrentScope, scope))
            {
                throw new InvalidOperationException("Attempt to end a scope that is currently not the current scope.");
            }

            var currentScope = scope.ParentScope;
            if (currentScope != null)
            {
                currentScope.ChildScope = null;
            }

            CurrentScope = currentScope;
        }
    }
}