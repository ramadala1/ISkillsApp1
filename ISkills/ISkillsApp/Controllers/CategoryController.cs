using ISkillsDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace ISkillsApp.Controllers
{
	
	public class CategoryController : ApiController
	{
		private ISkillsEntities entities = null;
		[HttpGet]
		public HttpResponseMessage GetCategories()
		{
			try
			{
				var categories = entities.Categories.ToList();
				if(categories.Count() > 0)
				{
					return Request.CreateResponse(HttpStatusCode.OK, categories);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There are no Categories in the table");
				}
			}
			catch(Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		[HttpPost]
		public HttpResponseMessage InsertCategory(Category category)
		{
			try
			{
				entities.Categories.Add(category);
				entities.SaveChanges();
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch(Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		[HttpPut]
		public HttpResponseMessage UpdateCategory(int id,Category category)
		{
			try
			{
				Category entity = entities.Categories.Find(id);
				if(entity != null)
				{
					entity.CategoryID = category.CategoryID;
					entity.CategoryName = category.CategoryName;
					entities.SaveChanges();
					return Request.CreateResponse(HttpStatusCode.OK);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There is no item with id=" + id );
				}
			}
			catch(Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		[HttpDelete]
		public HttpResponseMessage DeleteCategory(int id)
		{
			try
			{
				Category entity = entities.Categories.Find(id);
				if(entity != null)
				{
					entities.Categories.Remove(entity);
					entities.SaveChanges();
					return Request.CreateResponse(HttpStatusCode.OK);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "item with id=" + id + "not found");
				}
			}
			catch(Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
	}
}
