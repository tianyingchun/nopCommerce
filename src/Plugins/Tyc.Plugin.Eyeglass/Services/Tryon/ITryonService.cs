using Nop.Core.Domain.Media;
using System.Collections.Generic;
using Tyc.Plugin.Eyeglass.Domain.Tryon;

namespace Tyc.Plugin.Eyeglass.Services.Tryon
{
    public partial interface ITryonService
    {
        /// <summary>
        /// Delete a glassTryon
        /// </summary>
        /// <param name="glassTryon">glassTryon</param>
        void DeleteTryon(GlassTryon glassTryon);


        /// <summary>
        /// Inserts a glassTryon
        /// </summary>
        /// <param name="glassTryon">glassTryon</param>
        void InsertTryon(GlassTryon glassTryon);

        /// <summary>
        /// Updates the GlassPrescription
        /// </summary>
        /// <param name="glassTryon">glassTryon</param>
        void UpdateTryon(GlassTryon glassTryon);

        /// <summary>
        /// Gets prescription
        /// </summary>
        /// <param name="glassTryonId">glass tryon identifier</param>
        /// <returns>GlassTryon</returns>
        GlassTryon GetGlassTryonById(int glassTryonId);

        /// <summary>
        /// Gets glass try on by cutomer id
        /// </summary>
        /// <param name="identifier">glassTryon identifier</param>
        /// <returns>GlassPrescription</returns>
        IList<GlassTryon> GetTryonByCustomerId(int customerId = 0);


        /// <summary>
        /// Gets all glass tryon
        /// </summary>
        /// <returns>All glass tryon</returns>
        IList<GlassTryon> GetAllTryon();



        /// <summary>
        /// http://resizer.apphb.com/JCropSample/Basic.htm
        /// </summary>
        /// <param name="pictureBinary"></param>
        /// <param name="productId"></param>
        /// <param name="mimeType"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        /// <returns></returns>
        string UploadTryonCroppedPicture(byte[] pictureBinary, int productId, string mimeType, int x, int y, int x2, int y2);

        /// <summary>
        /// save tryon model
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="leftX"></param>
        /// <param name="leftY"></param>
        /// <param name="rightX"></param>
        /// <param name="rightY"></param>
        /// <param name="pd"></param>
        /// <returns></returns>
        GlassTryon SaveTryonModel(int productId, string leftX, string leftY, string rightX, string rightY, string pd);

    }
}
