﻿namespace ValidationAttributes.Attributes
{
    public class MyRangeAttribute : MyValidationAttribute
    {
        private readonly int min;
        private readonly int max;
        public MyRangeAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public override bool isValid(object obj)
        {
            int currentValue = (int)obj;

            return currentValue >= min && currentValue <= max;
        }
    }
}
