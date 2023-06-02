namespace Domain.Entities
{ 
    public class Tipster : User
    { 
        public decimal SuccessRate { get; private set; }
        public bool Suspended { get; private set; }

        public Tipster(string username, string email, string password, UserRole userRole,
            decimal successRate = 0, bool suspended = false) : base(username, email, password, userRole)
        {
            SuccessRate = successRate;
            Suspended = suspended;
        } 
    }
}
