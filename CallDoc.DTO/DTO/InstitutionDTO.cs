using System;
using System.Collections.Generic;
using System.Text;

namespace CallDoc.DTO
{

    #region Institution

    public class InstitutionCreateDTO
    {
        public string Name { get; set; }
        public string Logo { get; set; }
        public string TypeId { get; set; }
    }
    public class InstitutionUpdateDTO : InstitutionCreateDTO
    {
        public string InstitutionId { get; set; }
        public string StatusId { get; set; }
    }
    public class InstitutionDTO : InstitutionUpdateDTO
    {
        public string Type { get; set; }
        public string Status { get; set; }
        public DateTime DateCreated { get; set; }
    }

    #endregion

    #region PlatformSpecialty

    public class PlatformSpecialtyCreateDTO
    {
        public string Name { get; set; }
    }
    public class PlatformSpecialtyUpdateDTO : PlatformSpecialtyCreateDTO
    {
        public string SpecialtyId { get; set; }
        public bool IsActive { get; set; }

    }
    public class PlatformSpecialtyDTO : PlatformSpecialtyUpdateDTO
    {
        public DateTime DateCreated { get; set; }
    }

    #endregion

    #region PlatformSubSpecialty

    public class PlatformSubSpecialtyCreateDTO
    {
        public string SpecialtyId { get; set; }
        public string Name { get; set; }

    }
    public class PlatformSubSpecialtyUpdateDTO : PlatformSubSpecialtyCreateDTO
    {
        public string SubSpecialtyId { get; set; }
        public bool IsActive { get; set; }
    }
    public class PlatformSubSpecialtyDTO : PlatformSubSpecialtyUpdateDTO
    {
        public DateTime DateCreated { get; set; }
        public string Specialty { get; set; }
    }
    public class UnderSpecialtyPaginationFilter : PaginationFilter
    {
        public string SpecialtyId { get; set; }
    }

    #endregion

    #region PlatformService

    public class PlatformServiceCreateDTO
    {
        public string SpecialtyId { get; set; }
        public string? SubSpecialtyId { get; set; }
        public string Name { get; set; }
    }
    public class PlatformServiceUpdateDTO : PlatformServiceCreateDTO
    {
        public string PlatformServiceId { get; set; }
        public bool IsActive { get; set; }

    }
    public class PlatformServiceDTO : PlatformServiceUpdateDTO
    {
        public DateTime DateCreated { get; set; }
        public string Specialty { get; set; }
        public string SubSpecialty { get; set; }
    }
    public class UnderSpecialtySubSpecialtyPaginationFilter : PaginationFilter
    {
        public string SpecialtyId { get; set; }
        public string SubSpecialtyId { get; set; }
    }

    #endregion

}
