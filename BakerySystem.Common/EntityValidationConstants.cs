﻿namespace BakerySystem.Common
{
	public static class EntityValidationConstants
	{
		public static class IdentityUser
		{
			public const int FullNameMaxLength = 40;
		}

		public static class Category
		{
			public const int NameMinLength = 4;
			public const int NameMaxLength = 50;

			public const int DescriptionMinLength = 20;
			public const int DescriptionMaxLength = 150;
		}

		public static class OrderDetails 
		{
			public const int FirstNameMinLength = 5;
			public const int FirstNameMaxLength = 20;

			public const int LastNameMinLength = 5;
			public const int LastNameMaxLength = 20;

			public const int AddressMinLength = 30;
			public const int AddressMaxLength = 150;

			public const int PhoneNumberMinLength = 11;
			public const int PhoneNumberMaxLength = 12;
		}
		public static class Products
		{
			public const int NameMinLength = 5;
			public const int NameMaxLength = 50;

			public const string PriceMinValue = "0";
			public const string PriceMaxValue = "2000";

			public const int DescriptionMinLength = 20;
			public const int DescriptionMaxLength = 250;

			public const int ImageUrlMaxLength = 2048;
		}

		public static class DailyOfferts
		{
			public const int NameMinLength = 5;
			public const int NameMaxLength = 20;

			public const int DescriptionMinLength = 20;
			public const int DescriptionMaxLength = 100;
		}
		public static class WeAreHiring
		{
			public const int PositionNameMinLength = 10;
			public const int PositionNameMaxLength = 30;

			public const int JobDescriptionMinLength = 30;
			public const int JobDescriptionMaxLength = 150;
		}
		public static class ContactUs
		{
			public const int FullNameMinLength = 10;
			public const int FullNameMaxLength = 30;

			public const int PhoneNumberMinLength = 10;
			public const int PhoneNumberMaxLength = 13;

			public const int EmailMinLength = 10;
			public const int EmailMaxLength = 30;

			public const int MessageMinLength = 10;
			public const int MessageMaxLength = 100;
		}
		public static class JobApplication
		{

			public const int FullNameMinLength = 5;
			public const int FullNameMaxLength = 25;

			public const int EmailMinLength = 10;
			public const int EmailMaxLength = 30;

			public const int SelfDescriptionMinLength = 30;
			public const int SelfDescriptionMaxLength = 150;
		}

		public static class FeedBack
		{
			public const int FeedBackMinLength = 15;
			public const int FeedBackMaxLength = 100;
		}
		public static class User
		{
			public const int UserNameMinLength = 3;
			public const int UserNameMaxLength = 15;

			public const int PasswordMinLength = 3;
			public const int PasswordMaxLength = 100;

			public const int FirstNameMinLength = 2;
			public const int FirstNameMaxLength = 15;
			
			public const int LastNameMinLength = 2;
			public const int LastNameMaxLength = 15;
		}
	}
}
