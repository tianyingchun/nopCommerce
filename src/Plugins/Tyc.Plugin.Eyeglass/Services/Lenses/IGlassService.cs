using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain;
using Tyc.Plugin.Eyeglass.Domain.Lenses;

namespace Tyc.Plugin.Eyeglass.Services.Lenses
{
    public partial interface IGlassService
    {
        /// <summary>
        /// Delete a glassLenses
        /// </summary>
        /// <param name="glassLenses">GlassLenses</param>
        void DeleteGlassLenses(GlassLenses glassLenses);


        /// <summary>
        /// Inserts a glassLenses
        /// </summary>
        /// <param name="glassLenses">GlassLenses</param>
        void InsertGlassLenses(GlassLenses glassLenses);

        /// <summary>
        /// Updates the glassLenses
        /// </summary>
        /// <param name="glassLenses">GlassLenses</param>
        void UpdateGlassLenses(GlassLenses glassLenses);


        /// <summary>
        /// Gets glassLenses
        /// </summary>
        /// <param name="glassLensesId">glassLenses identifier</param>
        /// <returns>GlassLenses</returns>
        GlassLenses GetGlassLensesById(int glassLensesId);

        /// <summary>
        /// Gets all glassLenses
        /// </summary>
        /// <returns>All GlassLenses</returns>
        IList<GlassLenses> GetAllGlassLenses();

    }
}
