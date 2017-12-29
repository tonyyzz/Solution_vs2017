using System;
namespace ConsoleAppTest.Model
{
	/// <summary>
	/// 
	/// </summary>
	/// 由代码生成器生成，Created Time：2017-12-29 23:03:57
	public partial class PersonModel
	{
		/// <summary>
		/// 
		/// </summary>
		public PersonModel()
		{
			Id = 0;
			Name = "";
			Age = 0;
			Height = 0;
			Weight = 0;
		}
		/// <summary>
		/// Id
		/// </summary>
		public int Id { get; set; }
		/// <summary>
		/// Name
		/// </summary>
		public string Name { get; set; }
		/// <summary>
		/// Age
		/// </summary>
		public int Age { get; set; }
		/// <summary>
		/// Height
		/// </summary>
		public int Height { get; set; }
		/// <summary>
		/// Weight
		/// </summary>
		public float Weight { get; set; }
	}
}
