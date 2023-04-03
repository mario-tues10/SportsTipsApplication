namespace Entites
{
    public class Tipster : User
    {
        public Sport Specialty { get; private set; }
        public decimal SuccessRate { get; private set; } = 0;
        public bool Suspended { get; private set; }
        public int UserId { get; private set; }

        public Tipster(string username, string email, string password,
            Sport specialty, decimal successRate = 0) : base(username, email, password)
        {
            SuccessRate = successRate;
            Specialty = specialty;
            Suspended = false;
        }
    }
}
