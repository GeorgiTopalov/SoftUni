﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CarRacing.Models.Cars
{
    public class TunedCar : Car
    {
        public TunedCar(string make, string model, string vIN, int horsePower) 
            : base(make, model, vIN, horsePower, 65, 7.5)
        {
        }

        public override void Drive()
        {
            base.Drive();
            int valueToLower = this.HorsePower;
            this.HorsePower = (int)(0.97 * valueToLower);
        }
    }
}
