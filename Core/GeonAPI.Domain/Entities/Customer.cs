using System;
using GeonAPI.Domain.Entities.Common;

namespace GeonAPI.Domain.Entities
{
	public class Customer :  BaseEntity
	{
		public string NameSurname { get; set; }
		public string Phone { get; set; }
		public string Address { get; set; }
    }
}