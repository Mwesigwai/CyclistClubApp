namespace FieldValidatorAPI
{
    public class CommonRegularExpressionValidationPatterns
    {
        public const string validEmailAddressRegexPattern = @"^([a-zA-Z0-9_\-\.]+)@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.)|(([a-zA-Z0-9\-]+\.)+))([a-zA-Z]{2,4}|[0-9]{1,3})(\]?)$";
        public const string validPhoneNumberRegexPattern = @"^(?:\+256\s\d{3}\s\d{3}\s\d{3}|0[78]\d{2}\s\d{3}\s\d{3})$";
        public const string strongPasswordRegexPattern = @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$";
        
    }
}