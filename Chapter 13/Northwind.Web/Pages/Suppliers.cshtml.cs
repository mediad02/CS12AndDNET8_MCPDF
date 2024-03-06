using Microsoft.AspNetCore.Mvc.RazorPages; // To use PageModel.
using Northwind.EntityModels.Sqlite; // To use NorthwindContext.

namespace Northwind.Web.Pages;

public class SuppliersModel : PageModel
{
	public IEnumerable<Supplier>? Suppliers { get; set; }
	private NorthwindContext _db;

	public SuppliersModel(NorthwindContext db)
	{
		_db = db;
	}

	public void OnGet()
	{
		ViewData["Title"] = "Northwind B2B - Suppliers";

		Suppliers = _db.Suppliers
		.OrderBy(c => c.Country)
		.ThenBy(c => c.CompanyName);
	}
}