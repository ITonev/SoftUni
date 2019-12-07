using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportTasksDTO
    {
        public string Name { get; set; }

        public string OpenDate { get; set; }

        public string DueDate { get; set; }

        public string LabelType { get; set; }

        public string ExecutionType { get; set; }
    }
}
