using Nop.Core.Infrastructure.DependencyManagement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Nop.Core.Configuration;
using Nop.Core.Infrastructure;
using Autofac.Core;
using Nop.Data;
using Tyc.Plugin.Eyeglass.Services;
using Tyc.Plugin.Eyeglass.Data;
using Tyc.Plugin.Eyeglass.Domain;
using Nop.Web.Framework.Infrastructure;
using Nop.Core.Data;
using Tyc.Plugin.Eyeglass.Domain.Lenses;
using Tyc.Plugin.Eyeglass.Domain.Prescription;
using Nop.Services.Catalog;

namespace Tyc.Plugin.Eyeglass.Infrastructure
{
    public class DependencyRegistrar : IDependencyRegistrar
    {

        private const string CONTEXT_NAME = "nop_object_context_eye_glass";
        public void Register(ContainerBuilder builder, ITypeFinder typeFinder, NopConfig config)
        {
            builder.RegisterType<GlassService>().As<IGlassService>().InstancePerLifetimeScope();
            builder.RegisterType<LensPriceCalculationService>().As<IPriceCalculationService>().InstancePerLifetimeScope();
            builder.RegisterType<PrescriptionService>().As<IPrescriptionService>().InstancePerLifetimeScope();
            builder.RegisterType<LensesCheckoutService>().As<ILensesCheckoutService>().InstancePerLifetimeScope();


            //data context
            this.RegisterPluginDataContext<GlassObjectContext>(builder, CONTEXT_NAME);

            //Table (GlassLenses)
            //override required repository with our custom context 
            builder.RegisterType<EfRepository<GlassLenses>>()
                .As<IRepository<GlassLenses>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            //Table (GlassLensesAttribute)
            //override required repository with our custom context 
            builder.RegisterType<EfRepository<GlassLensesAttribute>>()
                .As<IRepository<GlassLensesAttribute>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();

            //Table (GlassLensesAttributeOption)
            //override required repository with our custom context 
            builder.RegisterType<EfRepository<GlassLensesAttributeOption>>()
                .As<IRepository<GlassLensesAttributeOption>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();


            //Table (GlassPrescription)
            //override required repository with our custom context 
            builder.RegisterType<EfRepository<GlassPrescription>>()
                .As<IRepository<GlassPrescription>>()
                .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                .InstancePerLifetimeScope();
        }
        public int Order => 100;

    }
}
