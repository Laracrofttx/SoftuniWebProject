namespace BakerySystem.Data.Models
{
	using Microsoft.AspNetCore.Identity;
	using System.ComponentModel.DataAnnotations;

	public class Review
	{
		public int Id { get; set; }

		public string UserName { get; set; } = null!;

        public string FeedBack { get; set; } = null!;

	}


	
}
