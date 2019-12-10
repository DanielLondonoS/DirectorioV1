using System;
using System.Collections.Generic;
using System.Text;
using DirectorioV1.Api.Aplication.Contracts.Services;
using DirectorioV1.Api.Aplication.Services;
using DirectorioV1.Api.DataAccess.Contracts.Repositories;
using DirectorioV1.Api.DataAccess.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DirectorioV1.Api.CrossCutting.Register
{
    public static class IoCRegister
    {
        public static IServiceCollection AddRegistration(this IServiceCollection services)
        {
            RegistrationRepositories(services);
            RegistrationServices(services);
            return services;
        }

        private static IServiceCollection RegistrationServices(IServiceCollection services)
        {
            services.AddTransient<IBarriosServices, BarriosServices>();
            services.AddTransient<ICiudadesServices, CiudadesServices>();
            services.AddTransient<IDepartamentosServices, DepartamentosServices>();
            services.AddTransient<IMunicipiosServices, MunicipiosServices>();
            services.AddTransient<IPaisesServices, PaisesServices>();

            return services;
        }

        private static IServiceCollection RegistrationRepositories(IServiceCollection services)
        {
            services.AddTransient<IBarriosRepository, BarriosRepository>();
            services.AddTransient<ICategoriasRepository, CategoriasRepository>();
            services.AddTransient<ICiudadesRepository, CiudadesRepository>();
            services.AddTransient<IClientesRepository, ClientesRepository>();
            services.AddTransient<IClientesDireccionesRepository, ClientesDireccionesRepository>();
            services.AddTransient<IDepartamentosRepository, DepartamentosRepository>();
            services.AddTransient<IMunicipioRepository, MunicipiosRepository>();
            services.AddTransient<IPaisesRepository, PaisesRepository>();
            services.AddTransient<IUsuariosRepository, UsuariosRepository>();
            return services;
        }

    }
}
