using Hik.Communication.ScsServices.Service;

namespace ForensicsCourseToolkit.Framework_Project
{
    [ScsService(Version = "1.0.0.0")]
    public interface INetworkExamServiceTesting
    {
        string GetExamCopyEncryptedZipped(RequiredDetails details, int numberOfQuestions, int numberOfStds);

        bool SubmitExamEncryptedZipped(string anExamSubmission, RequiredDetails details, int numberofQuestions, int numberOfStds);
    }
}