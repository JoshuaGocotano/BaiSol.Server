﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseLibrary.DTO.Gantt
{
    public class ProjectActualWorkedDate
    {
        public required string ActualStartDate { get; set; }
        public required string ActualEndDate { get; set; }
        public required string ActualProjectDays { get; set; }

    }
}
