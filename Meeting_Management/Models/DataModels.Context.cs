namespace Meeting_Management.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class MeetingInfoDbContext : DbContext
    {
        public MeetingInfoDbContext()
            : base("name=MeetingInfoDbContext")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Corporate_Custoer_Tbl> Corporate_Custoer_Tbl { get; set; }
        public virtual DbSet<Individual_Customer_Tbl> Individual_Customer_Tbl { get; set; }
        public virtual DbSet<Meeting_Minutes_Master_Tbl> Meeting_Minutes_Master_Tbl { get; set; }
        public virtual DbSet<Products_Service_Tbl> Products_Service_Tbl { get; set; }
    
        public virtual int Meeting_Minutes_Master_Save_SP(string customerName, Nullable<System.DateTime> date, Nullable<System.TimeSpan> time, string meetingPlace, string attendsFromClientSide, string attendsFromHostSide, string meetingAgenda, string meetingDiscussion, string meetingDecision)
        {
            var customerNameParameter = customerName != null ?
                new ObjectParameter("CustomerName", customerName) :
                new ObjectParameter("CustomerName", typeof(string));
    
            var dateParameter = date.HasValue ?
                new ObjectParameter("Date", date) :
                new ObjectParameter("Date", typeof(System.DateTime));
    
            var timeParameter = time.HasValue ?
                new ObjectParameter("Time", time) :
                new ObjectParameter("Time", typeof(System.TimeSpan));
    
            var meetingPlaceParameter = meetingPlace != null ?
                new ObjectParameter("MeetingPlace", meetingPlace) :
                new ObjectParameter("MeetingPlace", typeof(string));
    
            var attendsFromClientSideParameter = attendsFromClientSide != null ?
                new ObjectParameter("AttendsFromClientSide", attendsFromClientSide) :
                new ObjectParameter("AttendsFromClientSide", typeof(string));
    
            var attendsFromHostSideParameter = attendsFromHostSide != null ?
                new ObjectParameter("AttendsFromHostSide", attendsFromHostSide) :
                new ObjectParameter("AttendsFromHostSide", typeof(string));
    
            var meetingAgendaParameter = meetingAgenda != null ?
                new ObjectParameter("MeetingAgenda", meetingAgenda) :
                new ObjectParameter("MeetingAgenda", typeof(string));
    
            var meetingDiscussionParameter = meetingDiscussion != null ?
                new ObjectParameter("MeetingDiscussion", meetingDiscussion) :
                new ObjectParameter("MeetingDiscussion", typeof(string));
    
            var meetingDecisionParameter = meetingDecision != null ?
                new ObjectParameter("MeetingDecision", meetingDecision) :
                new ObjectParameter("MeetingDecision", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("Meeting_Minutes_Master_Save_SP", customerNameParameter, dateParameter, timeParameter, meetingPlaceParameter, attendsFromClientSideParameter, attendsFromHostSideParameter, meetingAgendaParameter, meetingDiscussionParameter, meetingDecisionParameter);
        }
    }
}
