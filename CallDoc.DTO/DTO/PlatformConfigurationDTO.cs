using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace CallDoc.DTO
{

    #region PlatformConfiguration

    public class PlatformConfigurationDTO
    {
        public string Value { get; set; }
        public string Name { get; set; }
    }

    #endregion

    #region DoctorSubSpecialties

    public class DoctorSpecialtiesCreateDTO
    {
        public string SubSpecialtyId { get; set; }
        public string DoctorId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class DoctorSpecialtiesDTO : DoctorSpecialtiesCreateDTO
    {
        public string DoctorSubSpecialties1 { get; set; }
    }

    #endregion

    #region InstitutionSpecialties

    public class InstitutionSpecialtiesCreateDTO
    {
        public string InstitutionBranchId { get; set; }
        public string SpecialtyId { get; set; }
        public bool IsActive { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class InstitutionSpecialtiesDTO : InstitutionSpecialtiesCreateDTO
    {
        public string InstitutionSpecialtiesId { get; set; }
    }

    #endregion

    #region InstitutionSubSpecialties

    public class InstitutionSubSpecialtiesCreateDTO
    {
        public string InstitutionBranchId { get; set; }
        public string SubSpecialtyId { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class InstitutionSubSpecialtiesDTO : InstitutionSubSpecialtiesCreateDTO
    {
        public string InstitutionSubSpecialtiesId { get; set; }
    }

    #endregion

    #region InstitutionServices

    public class InstitutionServicesMultipleCreateDTO
    {
        public string InstitutionDoctorId { get; set; }
        public string PlatformServiceId { get; set; }
    }
    public class InstitutionServicesCreateDTO
    {
        public string InstitutionBranchId { get; set; }
        public string ServicesId { get; set; }
        public string InstitutionDoctorId { get; set; }
        public DateTime DateCreated { get; set; }
    }
    public class InstitutionServicesDTO : InstitutionServicesCreateDTO
    {
        public string InstitutionServicesId { get; set; }
    }

    #endregion

    #region Temporary DTOs

    public class InstitutionSpecialtiesBodyDTO
    {
        public string InstitutitonBranchId { get; set; }
        public List<string> SpecialtiesIds { get; set; }
    }
    public class InstitutionSubSpecialtiesBodyDTO
    {
        public string InstitutitonBranchId { get; set; }
        public List<string> SubSpecialtiesIds { get; set; }
    }
    public class InstitutionServicesBodyDTO
    {
        public string InstitutitonBranchId { get; set; }
        public List<InstitutionServicesMultipleCreateDTO> Services { get; set; }

    }


    #endregion


    public class TestDTO
    {
        [Required]
        [StringLength(5)]
        public string Some { get; set; }
        public int Age { get; set; }
    }


}
