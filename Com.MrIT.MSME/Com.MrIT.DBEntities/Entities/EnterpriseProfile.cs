using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.DBEntities
{
    [Table("enterprise_profile")]
    public class EnterpriseProfile : GenericEntity
    {
        public EnterpriseProfile()
        {
            EnterpriseAttachment = new HashSet<EnterpriseAttachment>();
            EnterpriseImproveSurvey = new HashSet<EnterpriseImproveSurvey>();
            EnterprisePermit = new HashSet<EnterprisePermit>();
        }
         
        public int EnterpriseId { get; set; }
        public string NameMm { get; set; }
        public string NameEng { get; set; }
        public string PassportPhoto { get; set; }
        public string AddressEng { get; set; }
        public string AddressMm { get; set; }
        public string FaxNumber { get; set; }
        public string Email { get; set; }
        public string ContactPerson { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime EstablishedOn { get; set; }
        public DateTime BusinessLaunchedOn { get; set; }
        public string BrandNameOrTradeMark { get; set; }
        public string BrandImage { get; set; }
        public string OwnerNameEng { get; set; }
        public string OwnerNameMm { get; set; }
        public int NrcFirstId { get; set; }
        public int NrcSecondId { get; set; }
        public int NrcThirdId { get; set; }
        public string Nrcnumber { get; set; }
        public string OwnerGender { get; set; }
        public string ServiceTypes { get; set; }
        public string NumberOfCollaborativeCompany { get; set; }
        public string NumberOfSubCom { get; set; }
        public int NumberOfEmployee { get; set; }
        public decimal CapitalInvestment { get; set; }
        public decimal AnnualIncome { get; set; }
        public string MainBarrierIds { get; set; }
        public string ForeignBusinessConnectionIds { get; set; }
        public string IsoIds { get; set; }
        public string PrizeType { get; set; }
        public string PrizeCountry { get; set; }
        public string PrizeReason { get; set; }
        public string CooperationCondition { get; set; }
        public int EmployeeRangeId { get; set; }
        public int AnnualIncomeRangeId { get; set; }
        public int EnterpriseCategoryId { get; set; }
        public int OwnerTypeId { get; set; }
        public int SectorId { get; set; }
        public int StateRegionId { get; set; }
        public int TownshipId { get; set; }

        public virtual AnnualIncomeRange AnnualIncomeRange { get; set; }
        public virtual EmployeeRange EmployeeRange { get; set; }
        public virtual Enterprise Enterprise { get; set; }
        public virtual EnterpriseCategory EnterpriseCategory { get; set; }
        public virtual NrcFirst NrcFirst { get; set; }
        public virtual NrcSecond NrcSecond { get; set; }
        public virtual NrcThird NrcThird { get; set; }
        public virtual OwnerType OwnerType { get; set; }
        public virtual Sector Sector { get; set; }
        public virtual StateRegion StateRegion { get; set; }
        public virtual Township Township { get; set; }
        public virtual ICollection<EnterpriseAttachment> EnterpriseAttachment { get; set; }
        public virtual ICollection<EnterpriseImproveSurvey> EnterpriseImproveSurvey { get; set; }
        public virtual ICollection<EnterprisePermit> EnterprisePermit { get; set; }
    }
}
