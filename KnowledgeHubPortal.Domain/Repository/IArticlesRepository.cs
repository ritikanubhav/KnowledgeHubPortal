using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;

namespace KnowledgeHubPortal.Domain.Repository
{
	public interface IArticlesRepository
	{
		void Submit(Article article);
		void Approve(List<int> ids);
		void Reject(List<int> ids);
		List<Article> GetArticlesForBrowse(int Cid=0);
		List<Article> GetArticlesForReview(int Cid=0);
	}
}
