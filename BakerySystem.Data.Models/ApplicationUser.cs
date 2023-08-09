﻿namespace BakerySystem.Data.Models
{
	using Microsoft.AspNetCore.Identity;

	public class ApplicationUser : IdentityUser<Guid>
	{
		public ApplicationUser()
		{
			Id = Guid.NewGuid();
		}

		
	}
}
