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
	public class CustomerController : ApiController
	{
		[HttpPost]   // api/Customer/InsertCustomer
		public HttpResponseMessage InsertCustomer(Customer customer)
		{
			try
			{
				using (ISkillsEntities entities = new ISkillsEntities())
				{
					entities.Customers.Add(customer);
					entities.SaveChanges();
					var message = Request.CreateResponse(HttpStatusCode.Created);
					return message;
				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
		[HttpDelete]    // api/DeleteCustomer/id
		public HttpResponseMessage DeleteCustomer(int id)
		{
			try
			{
				using (ISkillsEntities entities = new ISkillsEntities())
				{
					Customer entity = entities.Customers.FirstOrDefault(x => x.CustomerID == id);
					if (entity != null)
					{
						entities.Customers.Remove((Customer)entity);
						entities.SaveChanges();
						return Request.CreateResponse(HttpStatusCode.OK, "Entity with id =" + id + "deleted Sucessfully");
					}
					else
					{
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Entity with Id=" + id + "not found");
					}
				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}

		[HttpPut]   // api/UpdateCustomer/id
		public HttpResponseMessage UpdateCustomer(int id, Customer customer)
		{
			try
			{
				using (ISkillsEntities entities = new ISkillsEntities())
				{
					Customer entity = entities.Customers.FirstOrDefault(x => x.CustomerID == id);
					if (entity != null)
					{
						Customer cust = new Customer()
						{
							CustomerID = entity.CustomerID,
							FirstName = entity.FirstName,
							LastName = entity.LastName,
							Address = entity.Address,
							City = entity.City,
							Country = entity.Country,
							Phone = entity.Phone,
							State = entity.State,
							PostalCode = entity.PostalCode
						};
						entities.SaveChanges();
						return Request.CreateResponse(HttpStatusCode.OK);
					}
					else
					{
						return Request.CreateErrorResponse(HttpStatusCode.NotFound, "entity with id = " + id + "not found");
					}
				}
			}
			catch (Exception ex)
			{
				return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
			}
		}
	}
}
