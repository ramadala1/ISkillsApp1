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
	public class ProductController : ApiController
	{
		private ISkillsEntities entities = null;
		[HttpGet] // api/Product/GetProducts
		public HttpResponseMessage GetProducts()
		{
			try
			{
				var products = entities.Products.ToList();
				if (products.Count > 0)
				{
					return Request.CreateResponse(HttpStatusCode.OK, products);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "There are no Products in the table");
				}
			}
			catch(Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError,ex);
			}
			
		} 
		[HttpGet]
		public HttpResponseMessage GetProduct(int id)
		{
			try
			{
				Product product = entities.Products.FirstOrDefault(p => p.ProductID == id);
				if(product !=null)
				{
					return Request.CreateResponse(HttpStatusCode.OK, product);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with id=" +id+"Not found");
				}
			}
			catch(Exception ex)
			{
				return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		[HttpPost]
		public HttpResponseMessage Addproduct(Product product)
		{
			try
			{
				entities.Products.Add(product);
				entities.SaveChanges();
				return Request.CreateResponse(HttpStatusCode.OK);
			}
			catch(Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		[HttpPut]
		public HttpResponseMessage UpdateProduct(int id, Product product)
		{
			try
			{
				Product item = entities.Products.FirstOrDefault(p => p.ProductID == id);
				if(item != null)
				{
					item.ProductID = product.ProductID;
					item.Image = product.Image;
					item.Category = product.Category;
					item.CategoryID = product.CategoryID;
					item.Description = product.Description;
					item.Price = product.Price;
					item.ProductName = product.ProductName;
					entities.SaveChanges();
					return Request.CreateResponse(HttpStatusCode.OK);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Product with id=" + id + "not found");
				}	
			}
			catch(Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		//[HttpGet]
		public HttpResponseMessage GetProductsByCategoryID(int id)
		{
			try
			{
				var products = entities.Products.Select(x => x.CategoryID == id);
				if (products.Count() > 0)
				{
					return Request.CreateResponse(HttpStatusCode.OK, products);
				}
				else
				{
					return Request.CreateErrorResponse(HttpStatusCode.NotFound, "there are no products belongs to this category");
				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
	}
}
