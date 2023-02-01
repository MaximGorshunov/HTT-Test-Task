namespace Services.Exeptions
{
    public class BuisnessExeption : Exception
    {
        public BuisnessExeption() : base()
        {
        }

        public BuisnessExeption(string message) : base(message)
        {
        }

        public BuisnessExeption(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
