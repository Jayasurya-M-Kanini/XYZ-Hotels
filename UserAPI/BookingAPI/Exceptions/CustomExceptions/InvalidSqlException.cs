namespace BookingAPI.Exceptions.CustomExceptions
{
    public class InvalidSqlException:Exception
    {
        String message;

        public InvalidSqlException()
        {
            message = "SQL Exception is thrown";
        }

        public InvalidSqlException(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
