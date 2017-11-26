using System.Collections.Generic;
using Tyc.Plugin.Eyeglass.Domain.Prescription;

namespace Tyc.Plugin.Eyeglass.Services.Prescription
{
    public partial interface IPrescriptionService
    {
        /// <summary>
        /// Delete a GlassPrescription
        /// </summary>
        /// <param name="prescription">prescription</param>
        void DeletePrescription(GlassPrescription prescription);


        /// <summary>
        /// Inserts a GlassPrescription
        /// </summary>
        /// <param name="prescription">prescription</param>
        void InsertPrescription(GlassPrescription prescription);

        /// <summary>
        /// Updates the GlassPrescription
        /// </summary>
        /// <param name="prescription">GlassPrescription</param>
        void UpdatePrescription(GlassPrescription prescription);

        /// <summary>
        /// Gets prescription
        /// </summary>
        /// <param name="prescriptionId">prescription identifier</param>
        /// <returns>GlassPrescription</returns>
        GlassPrescription GetPrescriptionById(int prescriptionId);

        /// <summary>
        /// Gets prescription by cutomer id
        /// </summary>
        /// <param name="prescriptionId">prescription identifier</param>
        /// <returns>GlassPrescription</returns>
        IList<GlassPrescription> GetPrescriptionsByCustomerId(int customerId = 0);


        /// <summary>
        /// Gets all prescription
        /// </summary>
        /// <returns>All Prescription</returns>
        IList<GlassPrescription> GetAllPrescriptions();
    }
}
