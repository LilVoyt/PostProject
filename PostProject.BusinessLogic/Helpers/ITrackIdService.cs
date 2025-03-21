namespace PostProject.Application.Helpers
{
    public interface ITrackIdService
    {
        string GenerateNumericTrackId(int length = 12);
    }
}