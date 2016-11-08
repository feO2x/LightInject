namespace LightInject
{
    /// <summary>
    /// Manages a set of <see cref="Scope"/> instances.
    /// </summary>
    public class PerLogicalCallContextScopeManager : ScopeManager
    {
        private readonly LogicalThreadStorage<Scope> currentScope = new LogicalThreadStorage<Scope>();

        /// <summary>
        /// Initializes a new instance of the <see cref="PerLogicalCallContextScopeManager"/> class.        
        /// </summary>
        /// <param name="serviceFactory">The <see cref="IServiceFactory"/> to be associated with this <see cref="ScopeManager"/>.</param>
        public PerLogicalCallContextScopeManager(IServiceFactory serviceFactory) 
            : base(serviceFactory)
        {            
        }

        /// <summary>
        /// Gets or sets the current <see cref="Scope"/>.
        /// </summary>
        public override Scope CurrentScope
        {
            get { return currentScope.Value; }
            set { currentScope.Value = value; }
        }               
    }
}