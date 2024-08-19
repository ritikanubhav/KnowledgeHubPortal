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
		[MinLength(6)]
		[MaxLength(100)]
        public string Title { get; set; }
		[Required(ErrorMessage = "Please enter description")]
		[MaxLength (500)]
		public string Description { get; set; }
		[Required(ErrorMessage = "Please enter url")]
		[Url(ErrorMessage ="Not a Valid URl")]
		public string ArticleUrl {  get; set; }
        public int CategoryId {  get; set; }
		public Category? Category { get; set; }
		public bool IsApproved { get; set; }
		public string? SubmittedBy {  get; set; }
		public DateTime DateSubmitted { get; set; }

	}
}
