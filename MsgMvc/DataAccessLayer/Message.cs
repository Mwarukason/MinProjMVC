//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MinProjMVC.DataAccessLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class Message
    {
        public int Id { get; set; }
        public string MessageText { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public System.DateTime CreatedDateUTC { get; set; }
        public int FileId { get; set; }
    
        public virtual SubmittedFile SubmittedFile { get; set; }
    }
}
