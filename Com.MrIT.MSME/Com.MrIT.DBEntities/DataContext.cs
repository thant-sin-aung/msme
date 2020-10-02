using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Com.MrIT.DBEntities
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        { }

        public virtual DbSet<LoginLog> LoginLogs { get; set; }

        public virtual DbSet<ChangeLog> ChangeLogs { get; set; }

        public virtual DbSet<EmailTemplate> EmailTemplates { get; set; }

        public virtual DbSet<EmailLog> EmailLogs { get; set; }

        public virtual DbSet<ErrorLog> ErrorLogs { get; set; }


        public virtual DbSet<AnnualIncomeRange> AnnualIncomeRange { get; set; }
        public virtual DbSet<Application> Application { get; set; }
        public virtual DbSet<ApplicationPayment> ApplicationPayment { get; set; }
        public virtual DbSet<ApplicationType> ApplicationType { get; set; }
        public virtual DbSet<ApplicationWorkflow> ApplicationWorkflow { get; set; }
        public virtual DbSet<EmailTemplate> EmailTemplate { get; set; }
        public virtual DbSet<EmployeeRange> EmployeeRange { get; set; }
        public virtual DbSet<Enterprise> Enterprise { get; set; }
        public virtual DbSet<EnterpriseAttachment> EnterpriseAttachment { get; set; }
        public virtual DbSet<EnterpriseBarrier> EnterpriseBarrier { get; set; }
        public virtual DbSet<EnterpriseCategory> EnterpriseCategory { get; set; }
        public virtual DbSet<EnterpriseImproveSurvey> EnterpriseImproveSurvey { get; set; }
        public virtual DbSet<EnterprisePermit> EnterprisePermit { get; set; }
        public virtual DbSet<EnterpriseProfile> EnterpriseProfile { get; set; }
        public virtual DbSet<ForeignBusinessConnection> ForeignBusinessConnection { get; set; }
        public virtual DbSet<ImproveSurveyType> ImproveSurveyType { get; set; }
        public virtual DbSet<IsoType> IsoType { get; set; }
       
        public virtual DbSet<NrcFirst> NrcFirst { get; set; }
        public virtual DbSet<NrcSecond> NrcSecond { get; set; }
        public virtual DbSet<NrcThird> NrcThird { get; set; }
        public virtual DbSet<OwnerType> OwnerType { get; set; }
        public virtual DbSet<PermitType> PermitType { get; set; }
        public virtual DbSet<Sector> Sector { get; set; }
        public virtual DbSet<StateRegion> StateRegion { get; set; }
        public virtual DbSet<SubAgency> SubAgency { get; set; }
        public virtual DbSet<SubAgencyPermission> SubAgencyPermission { get; set; }
        public virtual DbSet<SysUser> SysUser { get; set; }
        public virtual DbSet<Township> Township { get; set; }
        public virtual DbSet<UserOtp> UserOtp { get; set; }
        public virtual DbSet<WorkflowAssignment> WorkflowAssignment { get; set; }
        public virtual DbSet<WorkflowAssignmentApprover> WorkflowAssignmentApprover { get; set; }
    }
}
