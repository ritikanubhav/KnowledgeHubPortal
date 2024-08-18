using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace KnowledgeHubPortal.Data
{
	public class ArticleRepo : IArticleRepo
	{
		private KHPDbContext db = new KHPDbContext();
		public void Add(Article article)
		{
			db.Articles.Add(article);
			db.SaveChanges();
		}

		public List<Article> GetAll()
		{
			return db.Articles.Include(article => article.Category).ToList();
		}

		public Article GetById(int id)
		{
			return (Article)db.Articles.Find(id);
		}

        public List<Article> GetArticlesByCategory(int id)
        {
			List<Article> articles = (from article in db.Articles.Include(article => article.Category)
									  where article.CategoryId == id
						   select article).ToList();
            return articles;
        }
		public List<Article> GetNotApprovedArticles()
		{
			List<Article> articles= articles = (from article in db.Articles.Include(article => article.Category)
												where article.isApproved == false
												select article).ToList();
			return articles;
		}

		public void DeleteArticleById(int Id)
		{
			//get article by id
			Article article = db.Articles.Find(Id);
			if (article != null)
			{
				db.Remove(article);
				db.SaveChanges();
			}
		}

		public void ApproveArticleById(int id)
		{
			Article article= db.Articles.Find(id);
			if(article !=null)
			{
				article.isApproved = true;
				db.Update(article);
				db.SaveChanges();
			}
			
		}
	}
}
