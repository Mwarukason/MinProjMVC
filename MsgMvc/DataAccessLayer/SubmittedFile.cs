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
    
    public partial class SubmittedFile
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SubmittedFile()
        {
            this.Messages = new HashSet<Message>();
        }
    
        public int Id { get; set; }
        public byte[] Stream { get; set; }
        public System.Guid RowGuid { get; set; }
        public string FileName { get; set; }
        public string ContentType { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Message> Messages { get; set; }
    }
}
