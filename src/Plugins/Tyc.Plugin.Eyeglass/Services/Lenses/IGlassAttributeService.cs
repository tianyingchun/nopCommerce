using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tyc.Plugin.Eyeglass.Domain;
using Tyc.Plugin.Eyeglass.Domain.Lenses;

namespace Tyc.Plugin.Eyeglass.Services.Lenses
{
    public partial interface IGlassAttributeService
    {
        /// <summary>
        /// Delete a glassLensesAttribute
        /// </summary>
        /// <param name="glassLensesAttribute">glassLensesAttribute</param>
        void DeleteGlassLensesAttribute(GlassLensesAttribute glassLensesAttribute);


        /// <summary>
        /// Inserts a glassLensesAttributeId
        /// </summary>
        /// <param name="glassLensesAttribute">glassLensesAttribute</param>
        void InsertGlassLensesAttribute(GlassLensesAttribute glassLensesAttribute);

        /// <summary>
        /// Updates the glassLensesAttributeId
        /// </summary>
        /// <param name="glassLensesAttribute">glassLensesAttribute</param>
        void UpdateGlassLensesAttribute(GlassLensesAttribute glassLensesAttribute);


        /// <summary>
        /// Gets glassLensesAttributeId
        /// </summary>
        /// <param name="glassLensesAttributeId">glassLensesAttribute identifier</param>
        /// <returns>glassLensesAttribute</returns>
        GlassLensesAttribute GetGlassLensesAttributeById(int glassLensesAttributeId);

        /// <summary>
        /// Gets all glassLenses attributes
        /// </summary>
        /// <returns>All GlassLenses Attribute</returns>
        IList<GlassLensesAttribute> GetAllGlassLensesAttributes(int glassLensesId);

        /// <summary>
        /// Gets all glassLenses attributes
        /// </summary>
        /// <param name="glassLensesId">the identifier of table GlassLenses</param>
        /// <param name="glassLensesAttributeType">enum GlassLensesAttributeTypeId Color, Thickness, ...</param>
        /// <returns>All GlassLenses Attributes</returns>
        IList<GlassLensesAttribute> GetAllGlassLensesAttributes(int glassLensesId, GlassLensesAttributeType glassLensesAttributeType = GlassLensesAttributeType.LensThickness);

 
    }
}
