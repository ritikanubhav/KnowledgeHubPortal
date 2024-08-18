using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace KnowledgeHubPortal.Domain.Entities
{
	public class Article
	{
		[Required]
		public int ArticleId {  get; set; }
		[Required(ErrorMessage ="Please enter Title")]
        public string Title { get; set; }
		[Required(ErrorMessage = "Please enter description")]
		public string Description { get; set; }
		[Required(ErrorMessage = "Please enter url")]
		[Url(ErrorMessage ="Not a Valid URl")]
		public string URL { get; set; }
        public bool isApproved { get; set; } = false;
		[Required(ErrorMessage ="Category is Required")]
        public int CategoryId {  get; set; }
		[ForeignKey("CategoryId")]
		public Category? Category { get; set; }
		
    }
}
