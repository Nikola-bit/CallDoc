using CallDoc.API.Models;
using CallDoc.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public class LookupRepository : ILookupRepository
    {

        #region Platform Configuration

        public List<PlatformConfiguration> AppointmentStatuses()
        {
            using (var db = new CallDocContext())
            {
                List<PlatformConfiguration> response = db.PlatformConfiguration.Where(p => p.ProgramCode == "APPOINTMENT_STATUS").ToList();

                return response;
            }
        }
        public List<PlatformConfiguration> InstitutionStatuses()
        {
            using (var db = new CallDocContext())
            {
                List<PlatformConfiguration> response = db.PlatformConfiguration.Where(p => p.ProgramCode == "INSTITUTION_STATUS").ToList();

                return response;
            }
        }
        public List<PlatformConfiguration> MemberTypes()
        {
            using (var db = new CallDocContext())
            {
                List<PlatformConfiguration> response = db.PlatformConfiguration.Where(p => p.ProgramCode == "MEMBER_TYPE").ToList();

                return response;
            }
        }
        public List<PlatformConfiguration> MemberStatuses()
        {
            using (var db = new CallDocContext())
            {
                List<PlatformConfiguration> response = db.PlatformConfiguration.Where(p => p.ProgramCode == "MEMBER_STATUS").ToList();

                return response;
            }
        }
        public List<PlatformConfiguration> InvitationStatuses()
        {
            using (var db = new CallDocContext())
            {
                List<PlatformConfiguration> response = db.PlatformConfiguration.Where(p => p.ProgramCode == "INVITATION_STATUS").ToList();

                return response;
            }
        }
        public List<PlatformConfiguration> CreditCardTypes()
        {
            using (var db = new CallDocContext())
            {
                List<PlatformConfiguration> response = db.PlatformConfiguration.Where(p => p.ProgramCode == "CREDIT_CARD_TYPE").ToList();

                return response;
            }
        }
        public List<PlatformConfiguration> PaymentStatuses()
        {
            using (var db = new CallDocContext())
            {
                List<PlatformConfiguration> response = db.PlatformConfiguration.Where(p => p.ProgramCode == "PAYMENT_STATUS").ToList();

                return response;
            }
        }
        public List<PlatformConfiguration> InstitutionTypes()
        {
            using (var db = new CallDocContext())
            {
                List<PlatformConfiguration> response = db.PlatformConfiguration.Where(p => p.ProgramCode == "INSTITUTION_TYPE").ToList();

                return response;
            }
        }

        #endregion

        #region DoctorSubSpecialties

        public DoctorSubSpecialties CreateDoctorSpecialties(DoctorSubSpecialties specialties)
        {
            using (var db = new CallDocContext())
            {
                db.DoctorSubSpecialties.Add(specialties);
                db.SaveChanges();

                specialties = db.DoctorSubSpecialties.Where(s => s.DoctorSubSpecialties1 == specialties.DoctorSubSpecialties1)
                    .Include(s => s.SubSpecialty).FirstOrDefault();

                return specialties;
            }
        }
        public DoctorSubSpecialties UpdateDoctorSpecialties(DoctorSubSpecialties specialties)
        {
            using (var db = new CallDocContext())
            {
                DoctorSubSpecialties update = db.DoctorSubSpecialties
                    .Where(a => a.DoctorSubSpecialties1 == specialties.DoctorSubSpecialties1)
                    .Include(s => s.SubSpecialty).FirstOrDefault();

                if (update != null)
                {
                    update.SubSpecialtyId = specialties.SubSpecialtyId;
                    update.DoctorId = specialties.DoctorId;
                    update.IsActive = specialties.IsActive;

                    db.SaveChanges();
                }

                return update;
            }
        }
        public DoctorSubSpecialties SingleDoctorSpecialties(int Id)
        {
            using (var db = new CallDocContext())
            {
                DoctorSubSpecialties specialties = db.DoctorSubSpecialties.Where(a => a.DoctorSubSpecialties1 == Id)
                    .Include(s => s.SubSpecialty).FirstOrDefault();

                return specialties;
            }
        }
        public DoctorSubSpecialties DeleteDoctorSpecialties(int Id)
        {
            using (var db = new CallDocContext())
            {
                DoctorSubSpecialties specialties = db.DoctorSubSpecialties.Where(a => a.DoctorSubSpecialties1 == Id)
                    .Include(s => s.SubSpecialty).FirstOrDefault();

                DoctorSubSpecialties deletedSpecialties = specialties;

                if (deletedSpecialties != null)
                {
                    db.DoctorSubSpecialties.Remove(deletedSpecialties);
                    db.SaveChanges();

                    return specialties;
                }

                else return null;
            }
        }
        public List<DoctorSubSpecialties> ListDoctorSpecialties(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<DoctorSubSpecialties> specialties = db.DoctorSubSpecialties.Include(s => s.SubSpecialty)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            specialties = specialties.OrderBy(p => p.DoctorSubSpecialties1).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            specialties = specialties.OrderByDescending(p => p.DoctorSubSpecialties1).ToList();
                            break;
                    }
                }

                return specialties;
            }
        }

        #endregion

        #region InstitutionSpecialties

        public InstitutionSpecialties CreateSp(InstitutionSpecialties institution)
        {
            using (var db = new CallDocContext())
            {
                db.InstitutionSpecialties.Add(institution);
                db.SaveChanges();
                return institution;
            }
        }
        public InstitutionSpecialties UpdateSp(InstitutionSpecialties institution)
        {
            using (var db = new CallDocContext())
            {
                InstitutionSpecialties update = db.InstitutionSpecialties.Where(a => a.InstitutionSpecialtiesId == institution.InstitutionSpecialtiesId).FirstOrDefault();

                if (update != null)
                {
                    update.InstitutionBranchId = institution.InstitutionBranchId;
                    update.SpecialtyId = institution.SpecialtyId;
                    update.IsActive = institution.IsActive;
                    db.SaveChanges();
                }
                return update;
            }
        }
        public InstitutionSpecialties SingleSp(int Id)
        {
            using (var db = new CallDocContext())
            {
                InstitutionSpecialties institution = db.InstitutionSpecialties.Where(a => a.InstitutionSpecialtiesId == Id).FirstOrDefault();

                return institution;
            }
        }
        public InstitutionSpecialties DeleteSp(int Id)
        {
            using (var db = new CallDocContext())
            {
                InstitutionSpecialties institution = db.InstitutionSpecialties.Where(a => a.InstitutionSpecialtiesId == Id).FirstOrDefault();
                InstitutionSpecialties delete = institution;

                if (delete != null)
                {
                    db.InstitutionSpecialties.Remove(delete);
                    db.SaveChanges();

                    return institution;
                }

                else return null;
            }
        }
        public List<InstitutionSpecialties> ListSp(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionSpecialties> institutions = db.InstitutionSpecialties
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutions = institutions.OrderBy(p => p.InstitutionSpecialtiesId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutions = institutions.OrderByDescending(p => p.InstitutionSpecialtiesId).ToList();
                            break;
                    }
                }

                return institutions;
            }
        }
        public List<InstitutionSpecialties> AddMultipleSpecialties(int institutionBranchId, List<int> specialtiesIds)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionSpecialties> newSpecialties = new List<InstitutionSpecialties>();

                InstitutionSpecialties newSpecialty = new InstitutionSpecialties();

                foreach (int specialtyId in specialtiesIds)
                {
                    if (db.InstitutionSpecialties.Where(i => i.InstitutionBranchId == institutionBranchId && i.SpecialtyId == specialtyId).FirstOrDefault() == null)
                    {
                        newSpecialty = new InstitutionSpecialties()
                        {
                            DateCreated = DateTime.Now,
                            IsActive = true,
                            InstitutionBranchId = institutionBranchId,
                            SpecialtyId = specialtyId,
                        };

                        db.InstitutionSpecialties.Add(newSpecialty);
                        db.SaveChanges();

                        newSpecialties.Add(db.InstitutionSpecialties.Where(i => i.InstitutionBranchId == institutionBranchId && i.SpecialtyId == specialtyId)
                            .Include(s => s.Specialty).Include(i => i.InstitutionBranch).FirstOrDefault());
                    }
                }

                return newSpecialties;
            }
        }
        public List<InstitutionSpecialties> RemoveMultipleSpecialties(int institutionBranchId, List<int> specialtiesIds)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionSpecialties> deletedSpecialties = new List<InstitutionSpecialties>();

                InstitutionSpecialties deletedSpecialty = new InstitutionSpecialties();

                foreach (int specialtyId in specialtiesIds)
                {
                    if (db.InstitutionSpecialties.Where(i => i.InstitutionBranchId == institutionBranchId && i.SpecialtyId == specialtyId).FirstOrDefault() != null)
                    {

                        deletedSpecialty = db.InstitutionSpecialties.Where(i => i.InstitutionBranchId == institutionBranchId && i.SpecialtyId == specialtyId)
                            .Include(s => s.Specialty).Include(i => i.InstitutionBranch).FirstOrDefault();

                        db.InstitutionSpecialties.Remove(deletedSpecialty);
                        db.SaveChanges();

                        deletedSpecialties.Add(deletedSpecialty);
                    }
                }

                return deletedSpecialties;
            }
        }


        #endregion

        #region InstitutionSubSpecialties

        public InstitutionSubSpecialties CreateSubSp(InstitutionSubSpecialties institution)
        {
            using (var db = new CallDocContext())
            {
                db.InstitutionSubSpecialties.Add(institution);
                db.SaveChanges();
                return institution;
            }
        }
        public InstitutionSubSpecialties UpdateSubSp(InstitutionSubSpecialties institution)
        {
            using (var db = new CallDocContext())
            {
                InstitutionSubSpecialties update = db.InstitutionSubSpecialties.Where(a => a.InstintutionSubSpecialtyId == institution.InstintutionSubSpecialtyId).FirstOrDefault();

                if (update != null)
                {
                    update.InstitutionBranchId = institution.InstitutionBranchId;
                    update.PlatformSubSpecialtyId = institution.PlatformSubSpecialtyId;
                    db.SaveChanges();
                }
                return update;
            }
        }
        public InstitutionSubSpecialties SingleSubSp(int Id)
        {
            using (var db = new CallDocContext())
            {
                InstitutionSubSpecialties institution = db.InstitutionSubSpecialties.Where(a => a.InstintutionSubSpecialtyId == Id).FirstOrDefault();

                return institution;
            }
        }
        public InstitutionSubSpecialties DeleteSubSp(int Id)
        {
            using (var db = new CallDocContext())
            {
                InstitutionSubSpecialties institution = db.InstitutionSubSpecialties.Where(a => a.InstintutionSubSpecialtyId == Id).FirstOrDefault();
                InstitutionSubSpecialties delete = institution;

                if (delete != null)
                {
                    db.InstitutionSubSpecialties.Remove(delete);
                    db.SaveChanges();

                    return institution;
                }

                else return null;
            }
        }
        public List<InstitutionSubSpecialties> ListSubSp(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionSubSpecialties> institutions = db.InstitutionSubSpecialties
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutions = institutions.OrderBy(p => p.InstintutionSubSpecialtyId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutions = institutions.OrderByDescending(p => p.InstintutionSubSpecialtyId).ToList();
                            break;
                    }
                }

                return institutions;
            }
        }
        public List<InstitutionSubSpecialties> AddMultipleSubSpecialties(int institutionBranchId, List<int> subSpecialtiesIds)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionSubSpecialties> newSubSpecialties = new List<InstitutionSubSpecialties>();

                InstitutionSubSpecialties newSubSpecialty = new InstitutionSubSpecialties();

                foreach (int subSpecialtyId in subSpecialtiesIds)
                {
                    if (db.InstitutionSubSpecialties.Where(i => i.InstitutionBranchId == institutionBranchId && i.PlatformSubSpecialtyId == subSpecialtyId).FirstOrDefault() == null)
                    {
                        newSubSpecialty = new InstitutionSubSpecialties()
                        {
                            DateCreated = DateTime.Now,
                            InstitutionBranchId = institutionBranchId,
                            PlatformSubSpecialtyId = subSpecialtyId,
                        };

                        db.InstitutionSubSpecialties.Add(newSubSpecialty);
                        db.SaveChanges();

                        newSubSpecialties.Add(db.InstitutionSubSpecialties.Where(i => i.InstitutionBranchId == institutionBranchId && i.PlatformSubSpecialtyId == subSpecialtyId)
                            .Include(s => s.PlatformSubSpecialty).Include(i => i.InstitutionBranch).FirstOrDefault());
                    }
                }

                return newSubSpecialties;
            }
        }
        public List<InstitutionSubSpecialties> RemoveMultipleSubSpecialties(int institutionBranchId, List<int> subSpecialtiesIds)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionSubSpecialties> deletedSubSpecialties = new List<InstitutionSubSpecialties>();

                InstitutionSubSpecialties deletedSubSpecialty = new InstitutionSubSpecialties();

                foreach (int subSpecialtyId in subSpecialtiesIds)
                {
                    if (db.InstitutionSubSpecialties.Where(i => i.InstitutionBranchId == institutionBranchId && i.PlatformSubSpecialtyId == subSpecialtyId).FirstOrDefault() != null)
                    {

                        deletedSubSpecialty = db.InstitutionSubSpecialties.Where(i => i.InstitutionBranchId == institutionBranchId && i.PlatformSubSpecialtyId == subSpecialtyId)
                            .Include(s => s.PlatformSubSpecialty).Include(i => i.InstitutionBranch).FirstOrDefault();

                        db.InstitutionSubSpecialties.Remove(deletedSubSpecialty);
                        db.SaveChanges();

                        deletedSubSpecialties.Add(deletedSubSpecialty);
                    }
                }

                return deletedSubSpecialties;
            }
        }


        #endregion

        #region InstitutionServices

        public InstitutionServices CreateService(InstitutionServices institution)
        {
            using (var db = new CallDocContext())
            {
                db.InstitutionServices.Add(institution);
                db.SaveChanges();
                return institution;
            }
        }
        public InstitutionServices UpdateService(InstitutionServices institution)
        {
            using (var db = new CallDocContext())
            {
                InstitutionServices update = db.InstitutionServices.Where(a => a.InstitutionServiceId == institution.InstitutionServiceId).FirstOrDefault();

                if (update != null)
                {
                    update.InstitutionBranchId = institution.InstitutionBranchId;
                    update.PlatformServiceId = institution.PlatformServiceId;
                    db.SaveChanges();
                }
                return update;
            }
        }
        public InstitutionServices SingleService(int Id)
        {
            using (var db = new CallDocContext())
            {
                InstitutionServices institution = db.InstitutionServices.Where(a => a.InstitutionServiceId == Id).FirstOrDefault();

                return institution;
            }
        }
        public InstitutionServices DeleteService(int Id)
        {
            using (var db = new CallDocContext())
            {
                InstitutionServices institution = db.InstitutionServices.Where(a => a.InstitutionServiceId == Id).FirstOrDefault();
                InstitutionServices delete = institution;

                if (delete != null)
                {
                    db.InstitutionServices.Remove(delete);
                    db.SaveChanges();

                    return institution;
                }

                else return null;
            }
        }
        public List<InstitutionServices> ListService(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionServices> institutions = db.InstitutionServices
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutions = institutions.OrderBy(p => p.InstitutionServiceId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            institutions = institutions.OrderByDescending(p => p.InstitutionServiceId).ToList();
                            break;
                    }
                }

                return institutions;
            }
        }
        public List<InstitutionServices> AddMultipleServices(int institutionBranchId, List<InstitutionServices> services)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionServices> newServices = new List<InstitutionServices>();

                InstitutionServices newService = new InstitutionServices();

                foreach (InstitutionServices service in services)
                {
                    if (db.InstitutionServices
                        .Where(i => i.InstitutionBranchId == institutionBranchId && i.PlatformServiceId == service.PlatformServiceId && i.InstitutionDoctorId == service.InstitutionDoctorId)
                        .FirstOrDefault() == null)
                    {
                        newService = new InstitutionServices()
                        {
                            DateCreated = DateTime.Now,
                            InstitutionBranchId = institutionBranchId,
                            PlatformServiceId = service.PlatformServiceId,
                            InstitutionDoctorId = service.InstitutionDoctorId
                        };

                        db.InstitutionServices.Add(newService);
                        db.SaveChanges();

                        newServices.Add(db.InstitutionServices
                            .Where(i => i.InstitutionBranchId == institutionBranchId && i.PlatformServiceId == service.PlatformServiceId && i.InstitutionDoctorId == service.InstitutionDoctorId)
                            .Include(s => s.PlatformService).Include(i => i.InstitutionBranch).Include(d => d.InstitutionDoctor).FirstOrDefault());
                    }
                }

                return newServices;
            }
        }
        public List<InstitutionServices> RemoveMultipleServices(int institutionBranchId, List<InstitutionServices> services)
        {
            using (var db = new CallDocContext())
            {
                List<InstitutionServices> deletedServices = new List<InstitutionServices>();

                InstitutionServices deletedService = new InstitutionServices();

                foreach (InstitutionServices service in services)
                {
                    if (db.InstitutionServices.Where(i => i.InstitutionBranchId == institutionBranchId && i.PlatformServiceId == service.PlatformServiceId && i.InstitutionDoctorId == service.InstitutionDoctorId)
                        .FirstOrDefault() != null)
                    {

                        deletedService = db.InstitutionServices
                            .Where(i => i.InstitutionBranchId == institutionBranchId && i.PlatformServiceId == service.PlatformServiceId && i.InstitutionDoctorId == service.InstitutionDoctorId)
                            .Include(s => s.PlatformService).Include(i => i.InstitutionBranch).Include(d => d.InstitutionDoctor).FirstOrDefault();

                        db.InstitutionServices.Remove(deletedService);
                        db.SaveChanges();

                        deletedServices.Add(deletedService);
                    }
                }

                return deletedServices;
            }
        }


        #endregion

    }
}
