using System;
using System.Collections.Generic;
using System.Text;

namespace CallDoc.DTO.DTO
{
   public class InstitutionBranchCreateDTO
    {
        public string InstitutionId { get; set; }
        public string Name { get; set; }
        public string AddressId { get; set; }
        public string Biography { get; set; }
        public string PhoneNumber { get; set; }
        public string ContactEmail { get; set; }
        public string Website { get; set; }
        public string Logo { get; set; }
    }
    public class InstitutionBranchDTO : InstitutionBranchCreateDTO
    {
        public string InstitutionBranchId { get; set; }
    }
}