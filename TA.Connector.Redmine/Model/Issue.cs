//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TA.Connector.Redmine.Model
{
    using System;
    using System.Collections.Generic;
    
    public partial class Issue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Issue()
        {
            this.Words = new HashSet<Word>();
        }
    
        public int Id { get; set; }
        public int RedmineId { get; set; }
        public int ProjectId { get; set; }
        public int TrackerId { get; set; }
        public int StatusId { get; set; }
        public int PriorityId { get; set; }
        public Nullable<int> AuthorId { get; set; }
        public string Subject { get; set; }
        public string Description { get; set; }
        public System.DateTime Created { get; set; }
        public Nullable<System.DateTime> Updated { get; set; }
    
        public virtual Facet Facet { get; set; }
        public virtual Facet Facet1 { get; set; }
        public virtual Facet Facet2 { get; set; }
        public virtual Facet Facet3 { get; set; }
        public virtual Facet Facet4 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Word> Words { get; set; }
    }
}
