using System;
using System.Collections.Generic;
using System.Text;

namespace TeisterMask.DataProcessor.ExportDto
{
    public class ExportEmployeeDTO
    {
        public string Username { get; set; }

        public ICollection<ExportTasksDTO> Tasks { get; set; } = new HashSet<ExportTasksDTO>();
    }
}
