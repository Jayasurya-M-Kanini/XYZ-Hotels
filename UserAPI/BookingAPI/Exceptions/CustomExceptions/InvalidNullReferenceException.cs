namespace BookingAPI.Exceptions.CustomExceptions
{
    public class InvalidNullReferenceException:Exception
    {
        String message;

        public InvalidNullReferenceException()
        {
            message = "Null Reference Exception is thrown";
        }

        public InvalidNullReferenceException(string message)
        {
            this.message = message;
        }

        public override string Message
        {
            get { return message; }
        }
    }
}
