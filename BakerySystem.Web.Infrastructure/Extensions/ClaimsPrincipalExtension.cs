namespace BakerySystem.Web.Infrastructure.Extensions
{
	using System.Security.Claims;

	using static Common.GeneralApplicationConstants;
	public static class ClaimsPrincipalExtension
	{
		public static bool isAdmin(this ClaimsPrincipal user)
		{

			return user.IsInRole(AdminRoleName);

			
		}
	}
}
