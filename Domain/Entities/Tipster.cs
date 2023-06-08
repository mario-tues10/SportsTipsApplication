namespace Domain.Entities
{ 
    public class Tipster : User
    {
        private decimal successRate;
        public decimal SuccessRate
        {
            get { 
                return successRate;
            }
            set
            {
                successRate = value;
            }
        }
        public bool suspended { get; private set; }
        public bool Suspended
        {
            get
            {
                return suspended;
            }
            set
            {
                suspended = value;
            }
        }
        public Tipster(string username, string email, string password, UserRole userRole,
            decimal successRate = 0, bool suspended = false) : base(username, email, password, userRole)
        {
            this.successRate = successRate;
            this.suspended = suspended;
        }

    }
}
