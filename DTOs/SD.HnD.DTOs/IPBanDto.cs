﻿//------------------------------------------------------------------------------
// <auto-generated>This code was generated by LLBLGen Pro v5.7.</auto-generated>
//------------------------------------------------------------------------------
using System;
using System.ComponentModel;
using System.Runtime.Serialization;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;	

namespace SD.HnD.DTOs.DtoClasses
{ 
	/// <summary> DTO class which is derived from the entity 'IPBan'.</summary>
	public partial class IPBanDto
	{
		/// <summary>Gets or sets the IPBanID field. Derived from Entity Model Field 'IPBan.IPBanID'</summary>
		[Required]
		public System.Int32 IPBanID { get; set; }
		/// <summary>Gets or sets the IPBanSetByUserID field. Derived from Entity Model Field 'IPBan.IPBanSetByUserID (FK)'</summary>
		public System.Int32 IPBanSetByUserID { get; set; }
		/// <summary>Gets or sets the IPBanSetOn field. Derived from Entity Model Field 'IPBan.IPBanSetOn'</summary>
		[Required]
		public System.DateTime IPBanSetOn { get; set; }
		/// <summary>Gets or sets the IPSegment1 field. Derived from Entity Model Field 'IPBan.IPSegment1'</summary>
		[Required]
		[Range(1, 255)]
		public System.Byte IPSegment1 { get; set; }
		/// <summary>Gets or sets the IPSegment2 field. Derived from Entity Model Field 'IPBan.IPSegment2'</summary>
		[Required]
		[Range(1,255)]
		public System.Byte IPSegment2 { get; set; }
		/// <summary>Gets or sets the IPSegment3 field. Derived from Entity Model Field 'IPBan.IPSegment3'</summary>
		[Required]
		[Range(1,255)]
		public System.Byte IPSegment3 { get; set; }
		/// <summary>Gets or sets the IPSegment4 field. Derived from Entity Model Field 'IPBan.IPSegment4'</summary>
		[Required]
		[Range(1, 255)]
		public System.Byte IPSegment4 { get; set; }
		/// <summary>Gets or sets the Range field. Derived from Entity Model Field 'IPBan.Range'</summary>
		[Required]
		public System.Byte Range { get; set; }
		/// <summary>Gets or sets the Reason field. Derived from Entity Model Field 'IPBan.Reason'</summary>
		[Required]
		public System.String Reason { get; set; }
		/// <summary>Gets or sets the SetByUserNickName field. Derived from Entity Model Field 'User.NickName (SetByUser)'</summary>
		[StringLength(20)]
		public System.String SetByUserNickName { get; set; }
	}

}



