﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PractitionerMobile
{
    public class Patient
    {
        public string Name
        {
            get;
            set;
        }

        public Patient(string name)
        {
            this.Name = name;
        }
    }
}