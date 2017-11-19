using Nop.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tyc.Plugin.Eyeglass.Domain.Prescription
{
    /// <summary>
    /// Represents a prescription of users
    /// </summary>
    public partial class GlassPrescription : BaseEntity
    {

        /// <summary>
        /// Gets or sets the store identifier
        /// </summary>
        public int StoreId { get; set; }

        /// <summary>
        /// Gets or sets the customer identifier
        /// </summary>
        public int CustomerId { get; set; }

        /// <summary>
        /// Gets or sets the prescription summary name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the pictureId if user upload RX picture.
        /// </summary>
        public int PictureId { get; set; }

        /// <summary>
        ///  Gets or sets Right Eye (OD) Sphere (SPH)
        /// </summary>
        public string ODSphere { get; set; }

        /// <summary>
        ///  Gets or sets Right Eye (OD) Cylinder (CYL)
        /// </summary>
        public string ODCylinder { get; set; }

        /// <summary>
        ///  Gets or sets Right Eye (OD) Axis
        /// </summary>
        public string ODAxis { get; set; }

        /// <summary>
        ///  Gets or sets  Right Eye (OD) Addition (near) ADD
        /// </summary>
        public string ODAdd { get; set; }

        /// <summary>
        ///  Gets or sets Left Eye (OS)  Sphere (SPH)
        /// </summary>
        public string OSSphere { get; set; }

        /// <summary>
        ///  Gets or sets Left Eye (OS) Cylinder (CYL)
        /// </summary>
        public string OSCylinder { get; set; }

        /// <summary>
        ///  Gets or sets Left Eye (OS) Axis
        /// </summary>
        public string OSAxis { get; set; }

        /// <summary>
        /// Gets or sets  Left Eye (OS) Addition (near) ADD
        /// </summary>
        public string OSAdd { get; set; }

        /// <summary>
        /// PD (Pupillary Distance) Left Eye
        /// </summary>
        public string PDLeft { get; set; }

        /// <summary>
        /// Gets or sets PD (Pupillary Distance) Right Eye
        /// </summary>
        public string PDRight{ get; set; }

        /// <summary>
        /// Gets or sets user extra comments messages for this prescription.
        /// </summary>
        public string ExtraComment { get; set; }

    }
}
