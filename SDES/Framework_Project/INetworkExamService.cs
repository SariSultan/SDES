using Hik.Communication.ScsServices.Service;

namespace ForensicsCourseToolkit.Framework_Project
{
    [ScsService(Version = "1.0.0.0")]
    public interface INetworkExamService
    {
        string GetExamCopyEncryptedZipped(RequiredDetails details);

        bool SubmitExamEncryptedZipped(string anExamSubmission, RequiredDetails details);
    }
}