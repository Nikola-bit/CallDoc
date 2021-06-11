using CallDoc.API.Models;
using CallDoc.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public class DoctorRepository : IDoctorRepository
    {

        #region Service

        public Service CreateService(Service service)
        {
            using (var db = new CallDocContext())
            {
                db.Service.Add(service);
                db.SaveChanges();

                service = db.Service.Where(m => m.ServiceId == service.ServiceId)
                    .Include(u => u.Doctor).ThenInclude(s => s.MemberDetails).FirstOrDefault();

                return service;
            }
        }

        public Service UpdateService(Service service)
        {
            using (var db = new CallDocContext())
            {
                Service editedService = db.Service.Where(a => a.ServiceId == service.ServiceId)
                    .Include(u => u.Doctor).ThenInclude(s => s.MemberDetails).FirstOrDefault();

                if (editedService != null)
                {
                    editedService.Title = service.Title;
                    editedService.Description = service.Description;
                    editedService.IsActive = service.IsActive;
                    editedService.Price = service.Price;
                    editedService.DoctorId = service.DoctorId;

                    db.SaveChanges();

                    editedService = db.Service.Where(a => a.ServiceId == service.ServiceId)
                        .Include(u => u.Doctor).ThenInclude(s => s.MemberDetails).FirstOrDefault();
                }

                return editedService;
            }
        }
        public Service SingleService(int serviceId)
        {
            using (var db = new CallDocContext())
            {
                Service service = db.Service.Where(a => a.ServiceId == serviceId)
                    .Include(u => u.Doctor).ThenInclude(s => s.MemberDetails).FirstOrDefault();

                return service;
            }
        }
        public Service DeleteService(int serviceId)
        {
            using (var db = new CallDocContext())
            {
                Service service = db.Service.Where(a => a.ServiceId == serviceId)
                    .Include(u => u.Doctor).ThenInclude(s => s.MemberDetails).FirstOrDefault();

                Service deletedService = service;

                if (deletedService != null)
                {
                    db.Service.Remove(deletedService);
                    db.SaveChanges();

                    return service;
                }

                else return null;
            }
        }
        public List<Service> ListServices(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<Service> services = db.Service.Include(u => u.Doctor).ThenInclude(s => s.MemberDetails)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            services = services.OrderBy(p => p.ServiceId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            services = services.OrderByDescending(p => p.ServiceId).ToList();
                            break;
                    }
                }

                return services;
            }
        }
        public List<Service> byDoctorId(int Id)
        {
            using (var db = new CallDocContext())
            {
                List<Service> institutions = db.Service.Where(c => c.DoctorId == Id)
                    .Include(u => u.Doctor).Include(u => u.Price).ToList();

                return institutions;
            }
        }

        #endregion

    }
}
