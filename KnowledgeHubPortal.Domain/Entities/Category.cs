using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Please Enter category")]
        [MinLength(3,ErrorMessage ="Minimum Characters must be Greater than 3")]
        [MaxLength(100)]
        public string CategoryName { get; set; }
        [StringLength(500)]
        [Required(ErrorMessage ="Please Enter Description")]
        public string CategoryDescription { get; set; }
        public List<Article> Articles { get; set; } =new List<Article>();
    }
}
