//using Microsoft.AspNetCore.Mvc.ModelBinding;
//using System.Globalization;

//namespace BakerySystem.Web.Infrastructure.ModelBinder
//{
//	public class DecimalModelBinder : IModelBinder
//	{
//		public Task BindModelAsync(ModelBindingContext? bindingContext)
//		{
//			if (bindingContext == null)
//			{
//				throw new ArgumentNullException(nameof(bindingContext));
//			}

//			ValueProviderResult valueResult = bindingContext.ValueProvider.GetValue(bindingContext.ModelName);

//			if (valueResult != ValueProviderResult.None && !string.IsNullOrWhiteSpace(valueResult.FirstValue))
//			{
//				decimal parseValue = 0m;
//				bool binderSucceded = false;

//				try
//				{
//					string formDecValue = valueResult.FirstValue;
//					formDecValue = formDecValue.Replace(",", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);
//					formDecValue = formDecValue.Replace(".", CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator);

//					parseValue = Convert.ToDecimal(valueResult);
//					binderSucceded = true;
//				}
//				catch (Exception ex)
//				{

//					bindingContext.ModelState.AddModelError(bindingContext.ModelName, ex, bindingContext.ModelMetadata);
//				}

//				if (binderSucceded)
//				{
//					bindingContext.Result = ModelBindingResult.Success(parseValue);
//				}
//			}
//			return Task.CompletedTask;
//		}
//	}
//}
