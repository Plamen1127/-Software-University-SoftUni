using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P01_StudentSystem.Data.Models
{
    public class Resource
    {
        [Key]
        public int ResourceId { get; set; }

        [MaxLength(50)]
        public string Name { get; set; }

        public int Url { get; set; }

        public ResurceType ResurceType { get; set; }
        
        public int CourseId { get; set; }


        [ForeignKey(nameof(`))]
        public Course Course { get; set; }




    }

    public enum ResurceType
    {
        Video,
        Presentation,
        Document,
        Other
    }
}
