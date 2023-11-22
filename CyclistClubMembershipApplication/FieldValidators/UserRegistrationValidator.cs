using System.Threading.Channels;
using FieldValidatorAPI;
namespace CyclistClubMembershipApplication.FieldValidators
{
    public class UserRegistrationValidator:IFieldValidator
    {
        const int FirstNameMinLength = 5;
        const int FirstNameMaxLength = 20;

        const int LastNameMinLength = 5;
        const int LastNameMaxLength = 20;


        delegate bool EmailExistsDel(string emailAddress);
        FieldValidatorDel _fieldValidatorDel = null;

        RequiredValidDel _requiredValidDel = null;
        StringLengthValidDel? _stringLengthValidDel = null;
        DateValidDel? _dateValidDel = null;
        PatternMatchDel _patternMatchDel = null;
        CompareFieldValidDel? _compareFieldValidDel = null;
        EmailExistsDel? emailExistsDel = null;
        string[]? _fieldArray = null;




        private bool ValidField(int fieldIndex, string fieldValue, string[] fieldArray, out string fieldInvalidMessage)
        {
            fieldInvalidMessage = "";
            FieldConstants.UserRegistrationFields userRegistrationField = (FieldConstants.UserRegistrationFields) fieldIndex; 

            switch (userRegistrationField)
            {
                case FieldConstants.UserRegistrationFields.EmailAddress:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))? $"You must enter a valid value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationField)} {Environment.NewLine}": "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue,CommonRegularExpressionValidationPatterns.validEmailAddressRegexPattern))? $"You must enter a valid email {Environment.NewLine}" : "";
                break;


                case FieldConstants.UserRegistrationFields.PhoneNumber:
                fieldInvalidMessage = (!_requiredValidDel(fieldValue))? $"You must enter a valid value for field: {Enum.GetName(typeof(FieldConstants.UserRegistrationFields), userRegistrationField)} {Environment.NewLine}" : "";
                fieldInvalidMessage = (fieldInvalidMessage == "" && !_patternMatchDel(fieldValue, CommonRegularExpressionValidationPatterns.validPhoneNumberRegexPattern))? $"You must enter a valid phone number {Environment.NewLine}" : "";
                break;

                case FieldConstants.UserRegistrationFields.FirstName:
                
                default: 
                break;
            }
            return fieldInvalidMessage.Equals("");
        }


        public string[] FieldArray
        {
            get
            {
                if(_fieldArray is null)
                {
                    _fieldArray = new string[Enum.GetValues(typeof(FieldConstants.UserRegistrationFields)).Length];
                }
                return _fieldArray;
            }
        }


        
        
        public FieldValidatorDel ValidatorDel => _fieldValidatorDel;


        public void InitialiseValidatorDelegates()
        {
            _fieldValidatorDel = new FieldValidatorDel(ValidField);
            _requiredValidDel = CommonFieldValidatorFunctions.requiredValidDel;
            _stringLengthValidDel = CommonFieldValidatorFunctions.stringLengthValidDel;
            _dateValidDel = CommonFieldValidatorFunctions.dateValidDel;
            _patternMatchDel = CommonFieldValidatorFunctions.patternMatchDel;
            _compareFieldValidDel = CommonFieldValidatorFunctions.compareFieldValidDel;
        }

    }
}