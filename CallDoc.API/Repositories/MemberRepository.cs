using CallDoc.API.Models;
using CallDoc.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CallDoc.API.Repositories
{
    public class MemberRepository : IMemberRepository
    {

        #region Member

        public Member LoginMember(Member member)
        {
            using(var db = new CallDocContext())
            {
                member = db.Member.Where(m => m.MemberEmail == member.MemberEmail && m.MemberPassword == member.MemberPassword)
                    .Include(u => u.MemberStatus).Include(s => s.MemberType).FirstOrDefault();

                return member;
            }
        }
        public Member CreateMember(Member member)
        {
            using (var db = new CallDocContext())
            {
                db.Member.Add(member);
                db.SaveChanges();

                member = db.Member.Where(m => m.MemberId == member.MemberId)
                    .Include(u => u.MemberStatus).Include(s => s.MemberType).FirstOrDefault();

                return member;
            }
        }

        public Member UpdateMember(Member member)
        {
            using (var db = new CallDocContext())
            {
                Member editedMember = db.Member.Where(a => a.MemberId == member.MemberId)
                    .Include(u => u.MemberStatus).Include(q => q.MemberType).FirstOrDefault();

                if (editedMember != null)
                {
                    editedMember.MemberEmail = member.MemberEmail;
                    editedMember.MemberPassword = member.MemberPassword;
                    editedMember.MemberTypeId = member.MemberTypeId;
                    editedMember.MemberStatusId = member.MemberStatusId;

                    db.SaveChanges();
                }

                return editedMember;
            }
        }
        public Member SingleMember(int memberId)
        {
            using (var db = new CallDocContext())
            {
                Member member = db.Member.Where(a => a.MemberId == memberId)
                    .Include(u => u.MemberType).Include(q => q.MemberStatus).FirstOrDefault();

                return member;
            }
        }
        public Member DeleteMember(int memberId)
        {
            using (var db = new CallDocContext())
            {
                Member member = db.Member.Where(a => a.MemberId == memberId)
                    .Include(u => u.MemberStatus).Include(q => q.MemberType).FirstOrDefault();

                Member deletedMember = member;

                if (deletedMember != null)
                {
                    db.Member.Remove(deletedMember);
                    db.SaveChanges();

                    return member;
                }

                else return null;
            }
        }
        public List<Member> ListMembers(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<Member> memberes = db.Member.Include(u => u.MemberType).Include(q => q.MemberStatus)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            memberes = memberes.OrderBy(p => p.MemberId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            memberes = memberes.OrderByDescending(p => p.MemberId).ToList();
                            break;
                    }
                }

                return memberes;
            }
        }

        public List<Member> MembersByStatus(int statusId)
        {
            using(var db = new CallDocContext())
            {
                List<Member> members = db.Member.Where(m => m.MemberStatusId == statusId)
                    .Include(u => u.MemberType).Include(q => q.MemberStatus).ToList();

                return members;
            }
        }
        public List<Member> MembersByType(int typeId)
        {
            using (var db = new CallDocContext())
            {
                List<Member> members = db.Member.Where(m => m.MemberTypeId == typeId)
                    .Include(u => u.MemberType).Include(q => q.MemberStatus).ToList();

                return members;
            }
        }

        #endregion

        #region Member Details

        public MemberDetails CreateUpdateMemberDetails(MemberDetails memberDetails)
        {
            using (var db = new CallDocContext())
            {
                MemberDetails existing = null;

                existing = db.MemberDetails.Where(m => m.MemberId == memberDetails.MemberId)
                    .Include(a => a.Address).Include(u => u.Member).ThenInclude(ue => ue.MemberType).FirstOrDefault();

                if (existing == null)
                {
                    Member active = null;

                    active = db.Member.Where(m => m.MemberId == memberDetails.MemberId).FirstOrDefault();

                    if (active != null)
                    {
                        if (active.MemberStatusId == Convert.ToInt32(MEMBER_STATUS.Active) || active.MemberStatusId == Convert.ToInt32(MEMBER_STATUS.Inactive))
                        {
                            db.MemberDetails.Add(memberDetails);

                            active.MemberStatusId = Convert.ToInt32(MEMBER_STATUS.Active);

                            db.SaveChanges();

                            memberDetails = db.MemberDetails.Where(m => m.MemberId == memberDetails.MemberId)
                                .Include(a => a.Address).Include(u => u.Member).ThenInclude(ue => ue.MemberType).FirstOrDefault();
                        }

                        else return null;
                    }
                    else return null;
                }
                else
                {
                    existing.FirstName = memberDetails.FirstName;
                    existing.LastName = memberDetails.LastName;
                    existing.ProfilePicture = memberDetails.ProfilePicture;
                    existing.Embg = memberDetails.Embg;
                    existing.DateOfBirth = memberDetails.DateOfBirth;
                    existing.AddressId = memberDetails.AddressId;
                    existing.PhoneNumber = memberDetails.PhoneNumber;
                    existing.About = memberDetails.About;
                    existing.Gender = memberDetails.Gender;

                    db.SaveChanges();

                    memberDetails = existing;
                }

                return memberDetails;
            }
        }
        public MemberDetails SingleMemberDetails(int memberId)
        {
            using (var db = new CallDocContext())
            {
                MemberDetails memberDetails = db.MemberDetails.Where(a => a.MemberId == memberId)
                    .Include(a => a.Address).Include(u => u.Member).ThenInclude(ue => ue.MemberType).FirstOrDefault();

                return memberDetails;
            }
        }
        public MemberDetails DeleteMemberDetails(int memberId)
        {
            using (var db = new CallDocContext())
            {
                MemberDetails memberDetails = db.MemberDetails.Where(a => a.MemberId == memberId)
                    .Include(a => a.Address).Include(u => u.Member).ThenInclude(ue => ue.MemberType).FirstOrDefault();

                MemberDetails deletedMemberDetails = memberDetails;

                if (deletedMemberDetails != null)
                {
                    db.MemberDetails.Remove(deletedMemberDetails);
                    db.SaveChanges();

                    return memberDetails;
                }

                else return null;
            }
        }
        public List<MemberDetails> ListMembersDetails(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<MemberDetails> memberDetailses = db.MemberDetails.Include(a => a.Address).Include(u => u.Member).ThenInclude(ue => ue.MemberType)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            memberDetailses = memberDetailses.OrderBy(p => p.MemberId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            memberDetailses = memberDetailses.OrderByDescending(p => p.MemberId).ToList();
                            break;
                    }
                }

                return memberDetailses;
            }
        }

        #endregion

        #region MemberInvitation

        public MemberInvitation CreateMemberInvitation(MemberInvitation memberInvitation)
        {
            using (var db = new CallDocContext())
            {
                Member existing = null;

                existing = db.Member.Where(m => m.MemberId == memberInvitation.MemberId).FirstOrDefault();

                if (existing != null)
                {
                    memberInvitation.Email = existing.MemberEmail;

                    db.MemberInvitation.Add(memberInvitation);
                    db.SaveChanges();

                    memberInvitation = db.MemberInvitation.Where(m => m.MemberInvitationId == memberInvitation.MemberInvitationId)
                        .Include(u => u.Status).FirstOrDefault();

                    return memberInvitation;
                }

                else return null;
            }
        }

        public MemberInvitation UpdateMemberInvitation(MemberInvitation memberInvitation)
        {
            using (var db = new CallDocContext())
            {
                MemberInvitation editedMemberInvitation = db.MemberInvitation.Where(a => a.MemberInvitationId == memberInvitation.MemberInvitationId)
                    .Include(u => u.Status).FirstOrDefault();

                if (editedMemberInvitation != null)
                {
                    editedMemberInvitation.FirstName = memberInvitation.FirstName;
                    editedMemberInvitation.LastName = memberInvitation.LastName;
                    editedMemberInvitation.StatusId = memberInvitation.StatusId;
                    editedMemberInvitation.Phone = memberInvitation.Phone;
                    if (editedMemberInvitation.MemberId != memberInvitation.MemberId)
                    {
                        Member helper = db.Member.Where(m => m.MemberId == memberInvitation.MemberId).FirstOrDefault();
                        editedMemberInvitation.MemberId = memberInvitation.MemberId;
                        editedMemberInvitation.Email = helper.MemberEmail;
                    }

                    db.SaveChanges();

                    editedMemberInvitation = db.MemberInvitation.Where(a => a.MemberInvitationId == memberInvitation.MemberInvitationId)
                        .Include(u => u.Status).FirstOrDefault();
                }

                return editedMemberInvitation;
            }
        }
        public MemberInvitation SingleMemberInvitation(int memberInvitationId)
        {
            using (var db = new CallDocContext())
            {
                MemberInvitation memberInvitation = db.MemberInvitation.Where(a => a.MemberInvitationId == memberInvitationId)
                    .Include(u => u.Status).FirstOrDefault();

                return memberInvitation;
            }
        }
        public MemberInvitation DeleteMemberInvitation(int memberInvitationId)
        {
            using (var db = new CallDocContext())
            {
                MemberInvitation memberInvitation = db.MemberInvitation.Where(a => a.MemberInvitationId == memberInvitationId)
                    .Include(u => u.Status).FirstOrDefault();

                MemberInvitation deletedMemberInvitation = memberInvitation;

                if (deletedMemberInvitation != null)
                {
                    db.MemberInvitation.Remove(deletedMemberInvitation);
                    db.SaveChanges();

                    return memberInvitation;
                }

                else return null;
            }
        }
        public List<MemberInvitation> ListMemberInvitations(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<MemberInvitation> memberInvitationes = db.MemberInvitation.Include(u => u.Status)
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize)
                    .ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            memberInvitationes = memberInvitationes.OrderBy(p => p.MemberInvitationId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            memberInvitationes = memberInvitationes.OrderByDescending(p => p.MemberInvitationId).ToList();
                            break;
                    }
                }

                return memberInvitationes;
            }
        }
        public List<MemberInvitation> MemberInvitationsByStatus(int statusId)
        {
            using(var db = new CallDocContext())
            {
                List<MemberInvitation> memberInvitations = db.MemberInvitation.Where(m => m.StatusId == statusId)
                    .Include(u => u.Status).ToList();

                return memberInvitations;
            }
        }
        public List<MemberInvitation> MemberInvitationsByMember(int memberId)
        {
            using (var db = new CallDocContext())
            {
                List<MemberInvitation> memberInvitations = db.MemberInvitation.Where(m => m.MemberId == memberId)
                    .Include(u => u.Status).ToList();

                return memberInvitations;
            }
        }

        #endregion

        #region PatientHistory
        public PatientHistory CreateH(PatientHistory history)
        {
            using (var db = new CallDocContext())
            {
                db.PatientHistory.Add(history);
                db.SaveChanges();
                return history;
            }
        }
        public PatientHistory UpdateH(PatientHistory history)
        {
            using (var db = new CallDocContext())
            {
                PatientHistory update = db.PatientHistory.Where(a => a.PatientHistoryId == history.PatientHistoryId).FirstOrDefault();

                if (update != null)
                {
                    update.AppointmentId = history.AppointmentId;
                    update.DoctorInternNote = history.DoctorInternNote;
                    update.Diagnose = history.Diagnose;
                    update.FindingNote = history.FindingNote;
                    update.TreatmentNote = history.TreatmentNote;
                    db.SaveChanges();
                }
                return update;
            }
        }
        public PatientHistory SingleH(int Id)
        {
            using (var db = new CallDocContext())
            {
                PatientHistory institution = db.PatientHistory.Where(a => a.PatientHistoryId == Id).FirstOrDefault();

                return institution;
            }
        }
        public PatientHistory DeleteH(int Id)
        {
            using (var db = new CallDocContext())
            {
                PatientHistory institution = db.PatientHistory.Where(a => a.PatientHistoryId == Id).FirstOrDefault();
                PatientHistory delete = institution;

                if (delete != null)
                {
                    db.PatientHistory.Remove(delete);
                    db.SaveChanges();

                    return institution;
                }

                else return null;
            }
        }
        public List<PatientHistory> ListH(PaginationFilter filter)
        {
            using (var db = new CallDocContext())
            {
                List<PatientHistory> patientsHistory = db.PatientHistory
                    .Skip((filter.PageNumber - 1) * filter.PageSize)
                    .Take(filter.PageSize).ToList();

                if (filter.SortDirection.ToUpper() == "ASC")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            patientsHistory = patientsHistory.OrderBy(p => p.PatientHistoryId).ToList();
                            break;
                    }
                }
                if (filter.SortDirection.ToUpper() == "DES")
                {
                    switch (filter.SortColumn.ToLower())
                    {
                        default:
                            patientsHistory = patientsHistory.OrderByDescending(p => p.PatientHistoryId).ToList();
                            break;
                    }

                }

                return patientsHistory;
            }
        }

        public List<PatientHistory> HistoryByPatient(int patientId)
        {
            using(var db = new CallDocContext())
            {
                List<PatientHistory> patientHistories = db.PatientHistory.Where(p => p.Appointment.PatientId == patientId).ToList();

                return patientHistories;
            }
        }


        #endregion

    }
}
