﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
    public class Matricula
    {
        public int EnrollmentID { get; set; }
        public string periodo { get; set; }
        public decimal promedio { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
    }
}
