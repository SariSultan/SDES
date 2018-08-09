using System;

namespace ForensicsCourseToolkit.Framework_Project.Security
{
    [Serializable]
    public enum FilterationResult : short
    {
        Accepted = 1,
        InvalidSharedExamKey,
        StudentIsNotListedInFirewallRules,
        InvalidSharedStudentKeyIS,
        InvalidStdID_ImpersonationAttack, // protects against impersonation attack value inside encrypted is different that the payload
        InvalidSrcIP,
        InvalidSequenceNumber,
        InvalidSubmissionInstructorValidation,
        SubmissionTimeOutinInstructorV,
        DroppedUnknown,
    }
}