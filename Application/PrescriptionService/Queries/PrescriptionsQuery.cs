namespace PrescriptionService.Queries
{
    using System.Threading.Tasks;
    using HotChocolate;
    using PrescriptionService.Models;
    using PrescriptionService.Resolvers;

    public class PrescriptionsQuery
    {
        public async Task<Prescription> GetPrescription([Service] PrescriptionsResolver resolver, string id)
        {
            return await resolver.GetPrescription(id);
        }
    }
}