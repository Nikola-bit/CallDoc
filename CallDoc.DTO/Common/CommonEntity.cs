using System;
using System.Collections.Generic;
using System.Text;

namespace CallDoc.DTO
{
    class CommonEntity
    {
    }
    public enum APPOINTMENT_STATUS
    {
        Scheduled = 1,
        Cancelled = 2,
        Maintaining = 3,
        Finished = 4
    }
    public enum INSTITUTION_STATUS
    {
        Pending = 11,
        Active = 12,
        Inactive = 13,
        Suspended = 14
    }
    public enum MEMBER_TYPE
    {
        Customer = 21,
        Doctor = 22
    }
    public enum MEMBER_STATUS
    {
        Pending = 41,
        Active = 42,
        Inactive = 43,
        Suspended = 44
    }
    public enum INVITATION_STATUS
    {
        Pending = 51,
        Accepted = 52,
        Declined = 53,
        Expired = 54
    }
    public enum CREDIT_CARD_TYPE
    {
        Visa = 61,
        Mastercard = 62,
        Amex = 63,
        Discover = 64
    }
    public enum PAYMENT_STATUS
    {
        Waiting = 71,
        Failed = 72,
        Partly = 73,
        Fully = 74
    }
    public enum INSTITUTION_TYPE
    {
        Private = 81
    }
}
