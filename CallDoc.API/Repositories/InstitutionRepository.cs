using CallDoc.API.Models;
using CallDoc.API.Utilities;
using CallDoc.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public class InstitutionRepository : IInstitutionRepository
    {

        #region Institution

        public Institution CreateInstitution(Institution institution)
        {
            using (var db = new CallDocContext())
            {
                db.Institution.Add(institution);
                db.SaveChanges();

                institution = db.Institution.Where(m => m.InstitutionId == institution.InstitutionId)
                    .Include(u => u.Status).Include(s => s.Type).FirstOrDefault();

                return institution;
            }
        }

        public Institution UpdateInstitution(Institution institution)
        {
            using (var db = new CallDocContext())
            {
                Institution editedInstitution = db.Institution.Where(a => a.InstitutionId == institution.InstitutionId)
                    .Include(u => u.Status).Include(q => q.Type).FirstOrDefault();

                if (editedInstitution != null)
                {
                    editedInstitution.Name = institution.Name;
                    editedInstitution.Logo = institution.Logo;
                    editedInstitution.StatusId = institution.StatusId;
                    editedInstitution.TypeId = institution.TypeId;

                    db.SaveChanges();

                    editedInstitution = db.Institution.Where(a => a.InstitutionId == institution.InstitutionId)
                        .Include(u => u.Status).Include(q => q.Type).FirstOrDefault();
                }

                return editedInstitution;
            }
        }
        public Institution SingleInstitution(int institutionId)
        {
            using (var db = new CallDocContext())
            {
                Institution institution = db.Institution.Where(a => a.InstitutionId == institutionId)
                    .Include(u => u.Status).Include(q => q.Type).FirstOrDefault();

                return institution;
            }
        }
        public Institution DeleteInstitution(int institutionId)
        {
            using (var db = new CallDocContext())
            {
                Institution institution = db.Institution.Where(a => a.InstitutionId == institutionId)
                    .Include(u => u.Status).Include(q => q.Type).FirstOrDefault();

                Institution deletedInstitution = institution;

                if (deletedInstitution != null)
                {
                    db.Institution.Remove(deletedInstitution);
                    db.SaveChanges();

                    return institution;
                }

                else return null;
            }
        }
        public List<Institution> ListInstitutions(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<Institution> institutiones = db.Institution.Include(u => u.Status).Include(q => q.Type)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutiones = institutiones.OrderBy(p => p.InstitutionId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutiones = institutiones.OrderByDescending(p => p.InstitutionId).ToList();
                            break;
                    }
                }

                return institutiones;
            }
        }
        public List<Institution> ListByTypeId(int Id)
        {
            using (var db = new CallDocContext())
            {
                List<Institution> institutions = db.Institution.Where(c => c.TypeId == Id)
                    .Include(u => u.Type).Include(u => u.Name).ToList();

                return institutions;
            }
        }
        public List<Institution> ListByStatusId(int Id)
        {
            using (var db = new CallDocContext())
            {
                List<Institution> institutions = db.Institution.Where(c => c.StatusId == Id)
                    .Include(u => u.Status).Include(u => u.Name).ToList();

                return institutions;
            }
        }

        #endregion

        #region PlatformSpecialty

        public PlatformSpecialty CreatePlatformSpecialty(PlatformSpecialty specialty)
        {
            using (var db = new CallDocContext())
            {
                db.PlatformSpecialty.Add(specialty);
                db.SaveChanges();

                return specialty;
            }
        }

        public PlatformSpecialty UpdatePlatformSpecialty(PlatformSpecialty specialty)
        {
            using (var db = new CallDocContext())
            {
                PlatformSpecialty editedPlatformSpecialty = db.PlatformSpecialty.Where(a => a.SpecialtyId == specialty.SpecialtyId).FirstOrDefault();

                if (editedPlatformSpecialty != null)
                {
                    editedPlatformSpecialty.Name = specialty.Name;
                    editedPlatformSpecialty.IsActive = specialty.IsActive;

                    db.SaveChanges();
                }

                return editedPlatformSpecialty;
            }
        }
        public PlatformSpecialty SinglePlatformSpecialty(int specialtyId)
        {
            using (var db = new CallDocContext())
            {
                PlatformSpecialty specialty = db.PlatformSpecialty.Where(a => a.SpecialtyId == specialtyId).FirstOrDefault();

                return specialty;
            }
        }
        public PlatformSpecialty DeletePlatformSpecialty(int specialtyId)
        {
            using (var db = new CallDocContext())
            {
                PlatformSpecialty specialty = db.PlatformSpecialty.Where(a => a.SpecialtyId == specialtyId).FirstOrDefault();

                PlatformSpecialty deletedPlatformSpecialty = specialty;

                if (deletedPlatformSpecialty != null)
                {
                    db.PlatformSpecialty.Remove(deletedPlatformSpecialty);
                    db.SaveChanges();

                    return specialty;
                }

                else return null;
            }
        }
        public List<PlatformSpecialty> ListSpecialties(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<PlatformSpecialty> specialties = db.PlatformSpecialty
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            specialties = specialties.OrderBy(p => p.SpecialtyId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            specialties = specialties.OrderByDescending(p => p.SpecialtyId).ToList();
                            break;
                    }
                }

                return specialties;
            }
        }
        #endregion

        #region PlatformSubSpecialty

        public PlatformSubSpecialty CreatePlatformSubSpecialty(PlatformSubSpecialty subSpecialty)
        {
            using (var db = new CallDocContext())
            {
                db.PlatformSubSpecialty.Add(subSpecialty);
                db.SaveChanges();

                subSpecialty = db.PlatformSubSpecialty.Where(s => s.SubSpecialtyId == subSpecialty.SubSpecialtyId)
                    .Include(s => s.Specialty).FirstOrDefault();

                return subSpecialty;
            }
        }

        public PlatformSubSpecialty UpdatePlatformSubSpecialty(PlatformSubSpecialty subSpecialty)
        {
            using (var db = new CallDocContext())
            {
                PlatformSubSpecialty editedPlatformSubSpecialty = db.PlatformSubSpecialty.Where(a => a.SubSpecialtyId == subSpecialty.SubSpecialtyId)
                    .Include(s => s.Specialty).FirstOrDefault();

                if (editedPlatformSubSpecialty != null)
                {
                    editedPlatformSubSpecialty.Name = subSpecialty.Name;
                    editedPlatformSubSpecialty.SpecialtyId = subSpecialty.SpecialtyId;
                    editedPlatformSubSpecialty.IsActive = subSpecialty.IsActive;

                    db.SaveChanges();
                }

                return editedPlatformSubSpecialty;
            }
        }
        public PlatformSubSpecialty SinglePlatformSubSpecialty(int subSpecialtyId)
        {
            using (var db = new CallDocContext())
            {
                PlatformSubSpecialty subSpecialty = db.PlatformSubSpecialty.Where(a => a.SubSpecialtyId == subSpecialtyId)
                    .Include(s => s.Specialty).FirstOrDefault();

                return subSpecialty;
            }
        }
        public PlatformSubSpecialty DeletePlatformSubSpecialty(int subSpecialtyId)
        {
            using (var db = new CallDocContext())
            {
                PlatformSubSpecialty subSpecialty = db.PlatformSubSpecialty.Where(a => a.SubSpecialtyId == subSpecialtyId)
                    .Include(s => s.Specialty).FirstOrDefault();

                PlatformSubSpecialty deletedPlatformSubSpecialty = subSpecialty;

                if (deletedPlatformSubSpecialty != null)
                {
                    db.PlatformSubSpecialty.Remove(deletedPlatformSubSpecialty);
                    db.SaveChanges();

                    return subSpecialty;
                }

                else return null;
            }
        }
        public List<PlatformSubSpecialty> ListSubSpecialties(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<PlatformSubSpecialty> subSpecialties = db.PlatformSubSpecialty.Include(s => s.Specialty)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            subSpecialties = subSpecialties.OrderBy(p => p.SubSpecialtyId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            subSpecialties = subSpecialties.OrderByDescending(p => p.SubSpecialtyId).ToList();
                            break;
                    }
                }

                return subSpecialties;
            }
        }
        public List<PlatformSubSpecialty> ListSubSpecialtiesUnderSpecialty(UnderSpecialtyPaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<PlatformSubSpecialty> subSpecialties = db.PlatformSubSpecialty.Where(c => c.SpecialtyId == Convert.ToInt32(filter.SpecialtyId))
                    .Include(s => s.Specialty)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            subSpecialties = subSpecialties.OrderBy(p => p.SubSpecialtyId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            subSpecialties = subSpecialties.OrderByDescending(p => p.SubSpecialtyId).ToList();
                            break;
                    }
                }

                return subSpecialties;
            }
        }

        #endregion

        #region PlatformService

        public PlatformService CreatePlatformService(PlatformService service)
        {
            using (var db = new CallDocContext())
            {
                db.PlatformService.Add(service);
                db.SaveChanges();

                service = db.PlatformService.Where(s => s.SpecialtyId == service.SpecialtyId)
                    .Include(s => s.Specialty).Include(ss => ss.SubSpecialty).FirstOrDefault();

                return service;
            }
        }

        public PlatformService UpdatePlatformService(PlatformService service)
        {
            using (var db = new CallDocContext())
            {
                PlatformService edit = db.PlatformService.Where(a => a.PlatformServiceId == service.PlatformServiceId)
                    .Include(s => s.Specialty).Include(ss => ss.SubSpecialty).FirstOrDefault();

                if (edit != null)
                {
                    edit.Name = service.Name;
                    edit.SpecialtyId = service.SpecialtyId;
                    edit.IsActive = service.IsActive;
                    edit.SubSpecialtyId = service.SubSpecialtyId;

                    db.SaveChanges();
                }

                return edit;
            }
        }
        public PlatformService SinglePlatformService(int serviceId)
        {
            using (var db = new CallDocContext())
            {
                PlatformService service = db.PlatformService.Where(a => a.PlatformServiceId == serviceId)
                    .Include(s => s.Specialty).Include(ss => ss.SubSpecialty).FirstOrDefault();

                return service;
            }
        }
        public PlatformService DeletePlatformService(int serviceId)
        {
            using (var db = new CallDocContext())
            {
                PlatformService service = db.PlatformService.Where(a => a.PlatformServiceId == serviceId)
                    .Include(s => s.Specialty).Include(ss => ss.SubSpecialty).FirstOrDefault();

                PlatformService deleted = service;

                if (deleted != null)
                {
                    db.PlatformService.Remove(deleted);
                    db.SaveChanges();

                    return service;
                }

                else return null;
            }
        }
        public List<PlatformService> ListServices(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<PlatformService> services = db.PlatformService.Include(s => s.Specialty).Include(ss => ss.SubSpecialty)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            services = services.OrderBy(p => p.PlatformServiceId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            services = services.OrderByDescending(p => p.PlatformServiceId).ToList();
                            break;
                    }
                }

                return services;
            }
        }
        public List<PlatformService> ListServicesUnderSpecialtySubSpecialty(UnderSpecialtySubSpecialtyPaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<PlatformService> platformServices = new List<PlatformService>();

                if (filter.SpecialtyId != null && filter.SpecialtyId != "string" && !string.IsNullOrEmpty(filter.SpecialtyId))
                {
                    platformServices = db.PlatformService.Where(c => c.SpecialtyId == Convert.ToInt32(filter.SpecialtyId))
                        .Include(s => s.Specialty).Include(ss => ss.SubSpecialty).ToList();
                }
                if (filter.SubSpecialtyId != null && filter.SubSpecialtyId != "string" && !string.IsNullOrEmpty(filter.SubSpecialtyId))
                {
                    if (platformServices.Count() == 0)
                    {
                        platformServices = db.PlatformService.Where(c => c.SubSpecialtyId == Convert.ToInt32(filter.SubSpecialtyId))
                            .Include(s => s.Specialty).Include(ss => ss.SubSpecialty).ToList();
                    }
                    else
                    {
                        platformServices = platformServices.Where(c => c.SubSpecialtyId == Convert.ToInt32(filter.SubSpecialtyId)).ToList();
                    }
                }

                platformServices = platformServices
                        .Skip((filter.PageNumber - 1) * filter.PageSize)
                        .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            platformServices = platformServices.OrderBy(p => p.PlatformServiceId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            platformServices = platformServices.OrderByDescending(p => p.PlatformServiceId).ToList();
                            break;
                    }
                }

                return platformServices;
            }
        }

        #endregion

        #region InstitutionBranch

        public InstitutionBranch Create(InstitutionBranch institution)
        {
            using (var db = new CallDocContext())
            {
                db.InstitutionBranch.Add(institution);
                db.SaveChanges();
                return institution;
            }
        }
        public InstitutionBranch UpdateBranch(InstitutionBranch institution)
        {
            using (var db = new CallDocContext())
            {
                InstitutionBranch updateB = db.InstitutionBranch.Where(a => a.InstitutionBranchId == institution.InstitutionBranchId).FirstOrDefault();

                if (updateB != null)
                {
                    updateB.InstitutionId = institution.InstitutionId;
                    updateB.AddressId = institution.AddressId;
                    updateB.Name = institution.Name;
                    updateB.Biography = institution.Biography;
                    updateB.PhoneNumber = institution.PhoneNumber;
                    updateB.ContactEmail = institution.ContactEmail;
                    updateB.Website = institution.Website;
                    updateB.Logo = institution.Logo;

                    db.SaveChanges();
                }
                return updateB;
            }
        }
        public InstitutionBranch SingleBranch(int institutionBranchId)
        {
            using (var db = new CallDocContext())
            {
                InstitutionBranch institution = db.InstitutionBranch.Where(a => a.InstitutionBranchId == institutionBranchId).FirstOrDefault();

                return institution;
            }
        }
        public InstitutionBranch DeleteBranch(int branchId)
        {
            using (var db = new CallDocContext())
            {
                InstitutionBranch institution = db.InstitutionBranch.Where(a => a.InstitutionBranchId == branchId).FirstOrDefault();
                InstitutionBranch deletedbranch = institution;

                if (deletedbranch != null)
                {
                    db.InstitutionBranch.Remove(deletedbranch);
                    db.SaveChanges();

                    return institution;
                }

                else return null;
            }
        }
        public List<InstitutionBranch> ListBranch(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionBranch> institutions = db.InstitutionBranch
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutions = institutions.OrderBy(p => p.InstitutionBranchId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutions = institutions.OrderByDescending(p => p.InstitutionBranchId).ToList();
                            break;
                    }
                }

                return institutions;
            }
        }
        public List<InstitutionBranch> ListbranchByInstId(int Id)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionBranch> institutions = db.InstitutionBranch.Where(c => c.InstitutionId == Id)
                    .Include(u => u.Institution).Include(u => u.InstitutionSpecialties).ToList();

                return institutions;
            }
        }
        public InstitutionBranch SingleBranchByAddrId(int addressId)
        {
            using (var db = new CallDocContext())
            {
                InstitutionBranch institution = db.InstitutionBranch
                    .Where(a => a.AddressId == addressId).Include(c => c.Address).FirstOrDefault();

                return institution;
            }
        }
        #endregion

    }
}
