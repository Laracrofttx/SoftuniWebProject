namespace BakerySystem.WebApi.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using BakerySystem.Services.Interfaces;
	using BakerySystem.Services.Statistics;

	[Route("api/statistics")]
	[ApiController]
	public class StatisticsApiController : ControllerBase
	{
		private readonly IProductService productService;

		public StatisticsApiController(IProductService productService)
		{
			this.productService = productService;
		}

		[HttpGet]
		[Produces("application/json")]
		[ProducesResponseType(200, Type = typeof(StatisticServiceModel))]
		[ProducesResponseType(400)]
		public async Task<IActionResult> GetStatistics()
		{
			try
			{
				StatisticServiceModel serviceModel = await this.productService.GetStatisticsAsynch();

				return this.Ok(serviceModel);
			}
			catch (Exception)
			{
				return this.BadRequest();
			}
		}
	}
}
