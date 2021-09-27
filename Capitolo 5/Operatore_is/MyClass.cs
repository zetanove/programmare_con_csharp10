using System.Linq;

namespace IsPatternMatching
{
    public class MyClass
    {
        private int[] invalidValues = { 1, 4, 7, 9 };

        public bool IsValid(int value)
        {
            switch (value)
            {
                case var validValue when (!invalidValues.Contains(value)):
                    return true;

                case var invalidValue when (invalidValues.Contains(value)):
                    return false;

                default:
                    return false;

            }
        }
    }

}
