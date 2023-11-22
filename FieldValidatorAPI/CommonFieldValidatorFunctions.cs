using System.Text.RegularExpressions;

namespace FieldValidatorAPI
{
    public delegate bool RequiredValidDel(string fieldVal);
    public delegate bool StringLengthValidDel(string fieldVal, int min, int max);
    public delegate bool DateValidDel(string fieldVal, out DateTime validDateTime);
    public delegate bool PatternMatchDel(string fieldVal, string pattern);
    public delegate bool CompareFieldValidDel(string fieldVal, string fieldValCompare);
    public class CommonFieldValidatorFunctions
    {
        private static RequiredValidDel? _requiredValidDel = null;
        private static StringLengthValidDel? _stringLengthValidDel = null;
        private static DateValidDel? _dateValidDel = null;
        private static CompareFieldValidDel? _compareFieldValidDel= null;
        private static PatternMatchDel? _patternMatchDel = null;


        
        
        public static RequiredValidDel requiredValidDel
        {
            get
            {
                if (_requiredValidDel is null)
                {
                    _requiredValidDel = new RequiredValidDel(RequiredFieldValid);
                }
                return RequiredFieldValid;

            }
        }





        public static StringLengthValidDel stringLengthValidDel
        {
            get
            {
                if (_stringLengthValidDel is null)
                {
                    _stringLengthValidDel = new StringLengthValidDel(StringFieldLengthValid);
                }
                return StringFieldLengthValid;

            }
        }




        public static DateValidDel dateValidDel
        {
            get
            {
                if (_dateValidDel is null)
                {
                    _dateValidDel = new DateValidDel(DateFieldValid);
                }
                return DateFieldValid;

            }
        }



        public static PatternMatchDel patternMatchDel
        {
            get
            {
                if (_patternMatchDel is null)
                {
                    _patternMatchDel = new PatternMatchDel(FieldPatternValid);
                }
                return FieldPatternValid;

            }
        }



        public static CompareFieldValidDel compareFieldValidDel
        {
            get
            {
                if (_compareFieldValidDel is null)
                {
                    _compareFieldValidDel = new CompareFieldValidDel(FieldComparisonValid);
                }
                return FieldComparisonValid;

            }
        }


        private static bool RequiredFieldValid(string fieldVal)
        {
            if (!string.IsNullOrEmpty(fieldVal))
            {
                return true;
            }
            else
            {
                return false;
            }
        }






        private static bool StringFieldLengthValid(string fieldVal, int min, int max)
        {
            if (fieldVal.Length >= min && fieldVal.Length <= max)
            {
                return true;
            }
            return false;
        }




        private static bool DateFieldValid(string dateTime, out DateTime validDateTime)
        {
            if (DateTime.TryParse(dateTime, out validDateTime))
            {
                return true;
            }
            return false;
        }



        private static bool FieldPatternValid(string fieldVal, string regularExpressionPattern)
        {
            Regex regex = new Regex(regularExpressionPattern);
            if (regex.IsMatch(fieldVal))
            {
                return true;
            }
            return false;
        }




        private static bool FieldComparisonValid(string field1, string field2)
        {
            if (field1.Equals(field2))
            {
                return true;
            }
            return false;
        }
    }
}
