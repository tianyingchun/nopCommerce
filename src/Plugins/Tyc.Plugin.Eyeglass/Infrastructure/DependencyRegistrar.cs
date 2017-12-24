using Autofac;
using Autofac.Core;
using Nop.Core.Configuration;
using Nop.Core.Data;
using Nop.Core.Infrastructure;
using Nop.Core.Infrastructure.DependencyManagement;
using Nop.Data;
using Nop.Services.Catalog;
using Nop.Web.Framework.Infrastructure;
using Tyc.Plugin.Eyeglass.Data;
using Tyc.Plugin.Eyeglass.Domain.Lenses;
using Tyc.Plugin.Eyeglass.Domain.Prescription;
using Tyc.Plugin.Eyeglass.Domain.Tryon;
using Tyc.Plugin.Eyeglass.Services.Checkout;
using Tyc.Plugin.Eyeglass.Services.Lenses;
using Tyc.Plugin.Eyeglass.Services.Prescription;
using Tyc.Plugin.Eyeglass.Services.Tryon;

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
            builder.RegisterType<TryonService>().As<ITryonService>().InstancePerLifetimeScope();


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

            //Table (GlassTryon)
            //override required repository with our custom context 
            builder.RegisterType<EfRepository<GlassTryon>>()
                    .As<IRepository<GlassTryon>>()
                    .WithParameter(ResolvedParameter.ForNamed<IDbContext>(CONTEXT_NAME))
                    .InstancePerLifetimeScope();
        }
        public int Order => 100;

    }
}
