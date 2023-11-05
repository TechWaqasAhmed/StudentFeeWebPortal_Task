using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace StudentFeeWebPortal_Task.Models
{
	[Table("Tbl_Fee")]
	public class Fee_Model
    {
		[Key]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public decimal ID { get; set; }
		public decimal StudentID { get; set; }
		public string FeeMonth { get; set; }
		public decimal FeeAmount { get; set; }
		public DateTime SubmittedDate { get; set; }
		public decimal AddedBy { get; set; }

	}
}