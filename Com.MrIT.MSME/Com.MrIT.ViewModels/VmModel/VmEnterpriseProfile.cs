using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Com.MrIT.ViewModels
{
    
    public class VmEnterpriseProfile : ViewModelItemBase
    {
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

        public VmAnnualIncomeRange AnnualIncomeRange { get; set; }
        public VmEmployeeRange EmployeeRange { get; set; }
        public VmEnterprise Enterprise { get; set; }
        public VmEnterpriseCategory EnterpriseCategory { get; set; }
        public VmNrcFirst NrcFirst { get; set; }
        public VmNrcSecond NrcSecond { get; set; }
        public VmNrcThird NrcThird { get; set; }
        public VmOwnerType OwnerType { get; set; }
        public VmSector Sector { get; set; }
        public VmStateRegion StateRegion { get; set; }
        public VmTownship Township { get; set; }
        public List<VmEnterpriseAttachment> EnterpriseAttachment { get; set; }
        public List<VmEnterpriseImproveSurvey> EnterpriseImproveSurvey { get; set; }
        public List<VmEnterprisePermit> EnterprisePermit { get; set; }
    }
}
