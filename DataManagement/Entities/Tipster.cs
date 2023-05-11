namespace DataManagement.Entities 
{ 
    public class Tipster : User
    {
        public Sport Specialty { get; private set; }
        public decimal SuccessRate { get; private set; }
        public bool Suspended { get; private set; }
        public int UserId { get; private set; }

        public Tipster(string username, string email, string password, UserRole userRole,
            Sport specialty, decimal successRate = 0, bool suspended = false) : base(username, email, password, userRole)
        {
            SuccessRate = successRate;
            Specialty = specialty;
            Suspended = suspended;
        }
    }
}
