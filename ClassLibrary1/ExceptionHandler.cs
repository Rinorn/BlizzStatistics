using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1
{
    public class ExceptionHandler
    {   
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public string StackTrace { get; set; }
        [Required]
        public DateTime Logdate { get; set; }
        
        [Required]
        public string ExceptionSource { get; set; }
    }
}
