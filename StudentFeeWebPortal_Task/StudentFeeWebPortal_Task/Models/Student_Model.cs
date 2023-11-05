using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentFeeWebPortal_Task.Models
{
	[Table("Tbl_Student")]
	public class Student_Model
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public decimal ID { get; set; }
		public string Name { get; set; }
		public string FatherName { get; set; }
		public string FatherCNIC { get; set; }
		public string ContactNo { get; set; }
		public decimal RollNo { get; set; }
		[Column("ClassID")]
		public decimal ClassID { get; set; }
		public decimal Fee { get; set; }
		public string ResidenceAddress { get; set; }
		public DateTime AdminDate { get; set; }
		public DateTime LastUpdateDate { get; set; }
		public decimal AddedBy { get; set; }
		public string Gender { get; set; }

		public Class_Model Classes { get; set; }
		//public virtual Class_Model Classes { get; set; }
	}
}