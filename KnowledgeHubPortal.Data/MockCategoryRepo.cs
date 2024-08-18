using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeHubPortal.Domain.Entities;
using KnowledgeHubPortal.Domain.Repository;

namespace KnowledgeHubPortal.Data
{
	public class MockCategoryRepo : ICategoryRepository
	{
		public void Create(Category category)
		{
			throw new NotImplementedException();
		}

		public void Delete(int id)
		{
			throw new NotImplementedException();
		}

		public List<Category> GetAll()
		{
			return new List<Category>()
			{
				new Category(){ CategoryId=111,CategoryDescription="test 1",CategoryName="test1"},
				new Category(){ CategoryId=112,CategoryDescription="test 2",CategoryName="test2"},
				new Category(){ CategoryId=113,CategoryDescription="test 3",CategoryName="test3"},
				new Category(){ CategoryId=114,CategoryDescription="test 4",CategoryName="test4"},
				new Category(){ CategoryId=115,CategoryDescription="test 5",CategoryName="test5"},
			};
		}

		public Category GetById(int id)
		{
			throw new NotImplementedException();
		}

		public void Update(Category category)
		{
			throw new NotImplementedException();
		}
	}
}
